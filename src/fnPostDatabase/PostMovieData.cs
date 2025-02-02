using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace fnPostDatabase
{
	public class PostMovieData
	{
		private readonly ILogger<PostMovieData> _logger;

		public PostMovieData(ILogger<PostMovieData> logger)
		{
			_logger = logger;
		}

		[Function("PostMovieData")]
		[CosmosDBOutput("%DatabaseName%", "%ContainerName%", Connection = "CosmosDBConnection", CreateIfNotExists = true, PartitionKey ="id")]
		public async Task<object?> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
		{
			_logger.LogInformation("C# HTTP trigger function processed a request.");

			MovieRequest movie = null;
			var content = await new StreamReader(req.Body).ReadToEndAsync();

			try
			{
				movie = JsonConvert.DeserializeObject<MovieRequest>(content);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult("Serialization error: " + ex.Message);
			}

			return JsonConvert.SerializeObject(movie);
		}

	}
}
