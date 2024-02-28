using Azure.Search.Documents;
using Azure;
using lab_04_ai_document_search;
using Azure.Search.Documents.Models;

try
{
    var endpoint = Environment.GetEnvironmentVariable("SEARCH_ENDPOINT");
    var key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
    var indexName = "coffee-index";

    SearchOptions searchOptions = new();
    searchOptions.Select.Add("locations");
    searchOptions.Select.Add("sentiment");
    searchOptions.Select.Add("merged_content");

    SearchClient client = new(new Uri(endpoint), indexName, new AzureKeyCredential(key));
    SearchResults<Avaliacao> searchResult = client.Search<Avaliacao>("sentiment: 'negative'", searchOptions);
    Pageable<SearchResult<Avaliacao>> results = searchResult.GetResults();

    // Itera sobre os comentários de cada página da pesquisa
    foreach (var avaliacao in results.AsPages())
    {
        foreach (var av in avaliacao.Values.ToList())
        {
            Console.WriteLine($"Sentimento: {av.Document.Sentimento}");
            Console.WriteLine($"Locais: {string.Join(", ", av.Document.Locations)}");
            Console.WriteLine($"Comentário: {av.Document.MergedContent}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
