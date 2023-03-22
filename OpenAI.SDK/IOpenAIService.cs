using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK
{
    public interface IOpenAIService
    {
        Task<CompletionResponse?> GetCompletionAsync(
            CompletionRequest request,
            CancellationToken cancellationToken);
    }
}
