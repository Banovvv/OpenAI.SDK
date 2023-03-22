using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK
{
    public class OpenAIService : IOpenAIService
    {
        public Task<CompletionResponse> GetCompletionAsync(
            CompletionRequest request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
