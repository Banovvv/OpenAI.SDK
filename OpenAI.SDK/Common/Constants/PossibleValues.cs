namespace OpenAI.SDK.Common.Constants
{
    internal static class PossibleValues
    {
        internal static class Images
        {
            internal static IReadOnlyCollection<string> Size = new List<string>
            {
                "256x256",
                "512x512",
                "1024x1024"
            }.AsReadOnly();

            internal static IReadOnlyCollection<string> ResponseFormat = new List<string>
            {
                "url",
                "b64_json"
            }.AsReadOnly();
        }
    }
}
