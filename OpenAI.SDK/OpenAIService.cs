using OpenAI.SDK.Completions.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OpenAI.SDK
{
    public class OpenAIService : IOpenAIService
    {
        private readonly string _token;
        private readonly HttpClient _httpClient;
        private string BaseAddress = "https://api.openai.com/v1/{0}";
        private const string? CompletionsEndpoint = "completions";

        public OpenAIService(string token)
        {
            _token = token;
            _httpClient = new HttpClient();
        }

        public IOpenAIService ConfigureForAzure(string resourceName, string deploymentName)
        {
            BaseAddress = $"https://{resourceName}.openai.azure.com/openai/deployments/{deploymentName}/{0}?api-version=2022-12-01";
            return this;
        }

        public async Task<CompletionResponse?> GetCompletionAsync(
            CompletionRequest request,
            CancellationToken cancellationToken)
        {
            var json = JsonSerializer.Serialize(request);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            var response = await _httpClient
                .PostAsync(string.Format(BaseAddress, CompletionsEndpoint), content, cancellationToken);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync($"The request failed with the following error: {ex.Message}");
            }

            var result = JsonSerializer
                    .Deserialize<CompletionResponse>(await response.Content.ReadAsStringAsync(cancellationToken));

            return result;
        }
    }
}
