using OpenAI.SDK.Chat.Models;
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

        Task<ChatResponse?> GetChatResponseAsync(
            ChatRequest request,
            CancellationToken cancellationToken);

        Task<CompletionResponse?> GetCompletionAsync(
            CompletionRequest request,
            CancellationToken cancellationToken);

        Task<ImageResponse?> GetImageAsync(
            ImageRequest request,
            CancellationToken cancellationToken);
    }
}
