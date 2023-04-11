using System.Text.Json.Serialization;

namespace OpenAI.SDK.Chat.Models
{
    public class ChatResponse
    {
        /// <summary>
        /// The identifier of the result, which may be used during troubleshooting
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The list of choices that the user was presented with during the chat interaction
        /// </summary>
        [JsonPropertyName("choices")]
        public IReadOnlyList<Choice> Choices { get; set; }

        /// <summary>
        /// The usage statistics for the chat interaction
        /// </summary>
        [JsonPropertyName("usage")]
        public Usage TokenUsage { get; set; }

        /// <summary>
        /// Represents a completion choice returned by the API.  
        /// </summary>
        public class Choice
        {
            /// <summary>
            /// The index of the choice in the list of choices
            /// </summary>
            [JsonPropertyName("index")]
            public int Index { get; set; }

            /// <summary>
            /// The message that was presented to the user as the choice
            /// </summary>
            [JsonPropertyName("message")]
            public ChatMessage Message { get; set; }

            /// <summary>
            /// The reason why the chat interaction ended after this choice was presented to the user
            /// </summary>
            [JsonPropertyName("finish_reason")]
            public string FinishReason { get; set; }
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
