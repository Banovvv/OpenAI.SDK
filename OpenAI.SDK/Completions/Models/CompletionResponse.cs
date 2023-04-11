using System.Text.Json.Serialization;

namespace OpenAI.SDK.Completions.Models
{
    public class CompletionResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("choices")]
        public Choice[]? Choices { get; set; }

        [JsonPropertyName("usage")]
        public Usage? TokenUsage { get; set; }

        /// <summary>
        /// Represents a completion choice returned by the API.  
        /// </summary>
        public class Choice
        {
            [JsonPropertyName("text")]
            public string? Text { get; set; }

            [JsonPropertyName("index")]
            public int? Index { get; set; }

            [JsonPropertyName("logprobs")]
            public object? LogProbs { get; set; }

            [JsonPropertyName("finish_reason")]
            public string? FinishReason { get; set; }
        }

        /// <summary>
		/// The usage statistics for the interaction
		/// </summary>
        public class Usage
        {
            [JsonPropertyName("prompt_tokens")]
            public int? PromptTokens { get; set; }

            [JsonPropertyName("completion_tokens")]
            public int? CompletionTokens { get; set; }

            [JsonPropertyName("total_tokens")]
            public int? TotalTokens { get; set; }
        }
    }
}
