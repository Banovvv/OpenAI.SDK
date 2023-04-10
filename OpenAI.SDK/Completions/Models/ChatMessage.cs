using System.Text.Json.Serialization;

namespace OpenAI.SDK.Completions.Models
{
    public class ChatMessage
    {
        /// <summary>
        /// Constructor for a new Chat Message
        /// </summary>
        /// <param name="role">The role of the message</param>
        /// <param name="content">The text to send in the message</param>
        public ChatMessage(ChatMessageRole role, string content)
        {
            Role = role.ToString();
            Content = content;
        }

        /// <summary>
        /// The role of the message
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// The content of the message
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
