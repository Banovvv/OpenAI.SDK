using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

    }
}
