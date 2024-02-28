using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes;

namespace lab_04_ai_document_search
{
    public class Avaliacao
    {
        [JsonPropertyName("locations")]
        public string [] Locations { get; set; }

        [JsonPropertyName("sentiment")]
        [SearchableField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
        public string Sentimento { get; set; }

        [JsonPropertyName("merged_content")]
        public string MergedContent { get; set; }
    }
}
