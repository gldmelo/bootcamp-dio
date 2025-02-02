using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace fnPostDataStorage
{
    public class SaveMovieMedia
    {
        private readonly ILogger<SaveMovieMedia> _logger;

        public SaveMovieMedia(ILogger<SaveMovieMedia> logger)
        {
            _logger = logger;
        }

        [Function("SaveMovieMedia")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (!req.Headers.TryGetValue("file-type", out var fileTypeHeader))
                return new BadRequestObjectResult("file-type header not found!");

            var fileType = fileTypeHeader.ToString();
            var form = await req.ReadFormAsync();
            var file = req.Form.Files["file"];

            if (file == null || file.Length==0)
				return new BadRequestObjectResult("file not sent!");

            var storageConnectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage")!;
            string containerName = fileType;

            var blobClient = new BlobClient(storageConnectionString, containerName, file.FileName);
            var containerClient = new BlobContainerClient(storageConnectionString, containerName);

            await containerClient.CreateIfNotExistsAsync();
            await containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);

            string blobName = file.FileName;
            var blob = containerClient.GetBlobClient(blobName);
            using var stream = file.OpenReadStream();
            await blob.UploadAsync(stream, true);

			return new OkObjectResult(new
            {
                Message = "File was successfully stored!",
                BlobUri = blob.Uri
            });
        }
    }
}
