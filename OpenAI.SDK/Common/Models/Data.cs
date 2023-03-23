using System.Text.Json.Serialization;

namespace OpenAI.SDK.Common.Models
{
    /// <summary>
    /// Data returned from the API.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// The url of the image returned by the API.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// The base64-encoded image returned by the API.
        /// </summary>
        [JsonPropertyName("b64_json")]
        public string? Base64Data { get; set; }
    }
}
