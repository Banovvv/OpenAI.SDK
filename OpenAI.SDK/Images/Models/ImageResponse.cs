using OpenAI.SDK.Common.Models;
using System.Text.Json.Serialization;

namespace OpenAI.SDK.Images.Models
{
    /// <summary>
	/// Represents an image response returned by the API.  
	/// </summary>
    public class ImageResponse
    {
        /// <summary>
        /// List of results of the embedding
        /// </summary>
        [JsonPropertyName("data")]
        public List<Data>? Data { get; set; }
    }
}
