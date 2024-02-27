using Azure;
using Azure.AI.TextAnalytics;

string endpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT")!;
string key = Environment.GetEnvironmentVariable("LANGUAGE_KEY")!;

try
{
    TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(key));

    string textoParaAnalise = args[0];

    Response<DocumentSentiment> response = client.AnalyzeSentiment(textoParaAnalise, "pt-BR");
    DocumentSentiment docSentiment = response.Value;

    var sentimento = docSentiment.Sentiment switch
    {
        TextSentiment.Positive => "Positivo",
        TextSentiment.Negative => "Negativo",
        _ => "Neutro"
    };

    Console.WriteLine($"Sentimento do texto é: { sentimento }");
    Console.WriteLine($"Score de confiança Positivo: { docSentiment.ConfidenceScores.Positive }");
    Console.WriteLine($"Score de confiança Neutro: { docSentiment.ConfidenceScores.Neutral }");
    Console.WriteLine($"Score de confiança Negativo: { docSentiment.ConfidenceScores.Negative }");
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
