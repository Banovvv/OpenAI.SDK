namespace OpenAI.SDK.Common.Constants
{
    internal static class PossibleValues
    {
        internal static class Chat
        {
            internal static IReadOnlyCollection<string> Model = new List<string>
            {
                "gpt-4",
                "gpt-4-0314",
                "gpt-4-32k",
                "gpt-4-32k-0314",
                "gpt-3.5-turbo",
                "gpt-3.5-turbo-0301"
            }.AsReadOnly();
        }

        internal static class Completions
        {
            internal static IReadOnlyCollection<string> Model = new List<string>
            {
                "text-davinci-001",
                "text-davinci-002",
                "text-davinci-003",
                "text-babbage-001",
                "text-curie-001",
                "text-ada-001"
            }.AsReadOnly();
        }

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
