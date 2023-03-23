using OpenAI.SDK.Completions.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
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

                var result = JsonSerializer
                        .Deserialize<CompletionResponse>(await response.Content.ReadAsStringAsync(cancellationToken));

                return result;
            }
            catch (Exception ex)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new AuthenticationException("OpenAI rejected your authorization. Try checking your API Key.");
                }
                else if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new HttpRequestException("OpenAI had an internal server error. Please retry your request.");
                }
                else
                {
                    throw new HttpRequestException(ex.ToString());
                }
            }
        }
    }
}
