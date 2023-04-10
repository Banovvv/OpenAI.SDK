using OpenAI.SDK.Completions.Models;
using System.Text.Json.Serialization;

namespace OpenAI.SDK.Chat.Models
{
    public class ChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }


        [JsonPropertyName("messages")]
        public IEnumerable<ChatMessage> Messages { get; set; }
    }
}
