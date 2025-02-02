using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace fnGetMovies
{
	public class GetMovies
    {
        private readonly ILogger<GetMovies> _logger;
		private readonly CosmosClient _cosmosClient;

		public GetMovies(ILogger<GetMovies> logger, CosmosClient cosmosClient)
        {
            _logger = logger;
			_cosmosClient = cosmosClient;
		}

        [Function("GetMovies")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
			
            var id = req.Query["id"];
            var databaseName = Environment.GetEnvironmentVariable("DatabaseName");
            var containerName = Environment.GetEnvironmentVariable("ContainerName");

			var container = _cosmosClient.GetContainer(databaseName, containerName);
            var queryDefinition = new QueryDefinition("select * from c where c.id = @id").WithParameter("@id", id);
            var result = container.GetItemQueryIterator<MovieResult>(queryDefinition);

            var movieList = new List<MovieResult>();

            while (result.HasMoreResults)
            {
                foreach (var item in await result.ReadNextAsync())
                {
                    movieList.Add(item);
                }
            }

            var responseMessage = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await responseMessage.WriteAsJsonAsync(movieList);

            return responseMessage;
        }
    }
}
