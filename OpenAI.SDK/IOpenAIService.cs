using OpenAI.SDK.Completions.Models;
using OpenAI.SDK.Images.Models;

namespace OpenAI.SDK
{
    public interface IOpenAIService
    {
        IOpenAIService ConfigureForAzure(
            string resourceName,
            string deploymentName);

        IOpenAIService ConfigureForAzure(
            string resourceName,
            string deploymentName,
            string apiVersion);

        Task<CompletionResponse?> GetCompletionAsync(
            CompletionRequest request,
            CancellationToken cancellationToken);

        Task<ImageResponse?> GetImageAsync(
            ImageRequest request,
            CancellationToken cancellationToken);
    }
}
