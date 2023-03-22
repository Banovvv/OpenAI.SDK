using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK
{
    public interface IOpenAIService
    {
        IOpenAIService ConfigureForAzure(
            string resourceName,
            string deploymentName);

        Task<CompletionResponse?> GetCompletionAsync(
            CompletionRequest request,
            CancellationToken cancellationToken);
    }
}
