using System.Text.Json.Serialization;

namespace OpenAI.SDK.Images.Models
{
    public class ImageRequest
    {
        public ImageRequest(string prompt)
        {
            Prompt = prompt;
        }

        public ImageRequest(
            string prompt,
            int? n = null,
            string? size = null,
            string? responseFormat = null)
        {
            Prompt = prompt;
            N = n;
            Size = size;
            ResponseFormat = responseFormat;
        }

        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Must be between 1 and 10.
        /// Defaults to 1.
        /// </summary>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// Defaults to 1024x1024.
        /// </summary>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        /// <summary>
        /// The format in which the generated images are returned. Must be one of <paramref name="url"/> or <paramref name="b64_json"/>.
        /// </summary>
        [JsonPropertyName("response_format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResponseFormat { get; set; }
    }
}
