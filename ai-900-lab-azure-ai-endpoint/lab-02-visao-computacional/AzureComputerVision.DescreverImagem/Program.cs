using Azure;
using Azure.AI.Vision.ImageAnalysis;

try
{
    string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT")!;
    string key = Environment.GetEnvironmentVariable("VISION_KEY")!;

    ImageAnalysisClient client = new(new Uri(endpoint), new AzureKeyCredential(key));

    ImageAnalysisResult result = client.Analyze(
                new Uri("https://github.com/gldmelo/dio-lab-azure-ai-endpoint/blob/main/lab-02-visao-computacional/inputs/input-eu-shark.jpg?raw=true"),
                VisualFeatures.Caption,
                new ImageAnalysisOptions { GenderNeutralCaption = false });

    Console.WriteLine($"Legenda (caption): \"{result.Caption.Text}\". Confiança: {result.Caption.Confidence:F4}");
}
catch(Exception ex)
{
    Console.WriteLine($"Erro ao analisar a imagem: {ex.Message}");
}
