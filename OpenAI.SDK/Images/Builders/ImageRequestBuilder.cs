using OpenAI.SDK.Images.Models;

namespace OpenAI.SDK.Images.Builders
{
    public class ImageRequestBuilder
    {
        private string? Prompt { get; set; }
        private int? N { get; set; }
        private string? Size { get; set; }
        private string? ResponseFormat { get; set; }

        /// <summary>
        /// A text description of the desired image(s).
        /// The maximum length is 1000 characters.
        /// </summary>
        public ImageRequestBuilder WithPrompt(string prompt)
        {
            Prompt = prompt;
            return this;
        }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Must be between 1 and 10.
        /// Defaults to 1.
        /// </summary>
        public ImageRequestBuilder WithN(int n)
        {
            N = n;
            return this;
        }

        /// <summary>
        /// The size of the generated images.
        /// Must be one of 256x256, 512x512, or 1024x1024.
        /// Defaults to 1024x1024.
        /// </summary>
        public ImageRequestBuilder WithSize(string size)
        {
            Size = size;
            return this;
        }

        /// <summary>
        /// The format in which the generated images are returned.
        /// Must be one of <paramref name="url"/> or <paramref name="b64_json"/>.
        /// </summary>
        public ImageRequestBuilder WithResponseFormat(string responseFormat)
        {
            ResponseFormat = responseFormat;
            return this;
        }

        /// <summary>
		/// Creates a new <see cref="ImageRequest"/> with the specified parameters
		/// </summary>
        public ImageRequest Build()
        {
            ArgumentNullException.ThrowIfNull(Prompt, nameof(Prompt));

            return new ImageRequest(
                Prompt,
                N,
                Size,
                ResponseFormat);
        }
    }
}
