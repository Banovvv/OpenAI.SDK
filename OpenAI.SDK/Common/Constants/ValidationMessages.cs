namespace OpenAI.SDK.Common.Constants
{
    public static class ValidationMessages
    {
        public static class Images
        {
            public const string Prompt = "Prompt must not be null or empty!";
            public const string N = "Number of images to generate must be between 1 and 10";
            public const string Size = "Image size must be one of 256x256, 512x512, or 1024x1024";
            public const string ResponseFormat = "Response format must be either 'url' or 'b64_json'";
        }
    }
}
