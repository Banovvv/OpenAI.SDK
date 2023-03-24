using OpenAI.SDK.Common.Constants;
using System.Text.Json.Serialization;

namespace OpenAI.SDK.Completions.Models
{
    public class CompletionRequest
    {
        public CompletionRequest(
            string model,
            string prompt)
        {
            if (!PossibleValues.Completions.Model.Contains(model))
            {
                throw new ArgumentException(
                    string.Format(ValidationMessages.Completions.Model, model),
                    nameof(model));
            }

            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentNullException(
                    nameof(prompt),
                    ValidationMessages.Completions.Prompt);
            }

            Model = model;
            Prompt = prompt;
        }

        public CompletionRequest(
            string model,
            string prompt,
            int? maxTokens = null,
            double? temperature = null,
            double? topP = null,
            int? n = null,
            bool? stream = null,
            int? logProbs = null,
            string? stop = null)
            : this(model, prompt)
        {
            if (temperature < 0 ||
                temperature > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    ValidationMessages.Completions.Temperature);
            }

            if (topP < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(n),
                    ValidationMessages.Completions.TopP);
            }

            if (logProbs < 0 ||
                logProbs > 5)
            {
                throw new ArgumentOutOfRangeException
                    (nameof(n),
                    ValidationMessages.Completions.LogProbs);
            }

            MaxTokens = maxTokens;
            Temperature = temperature;
            TopP = topP;
            N = n;
            Stream = stream;
            LogProbs = logProbs;
            Stop = stop;
        }

        /// <summary>
        /// ID of the model to use.
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// The prompt to generate completions for, encoded as a string.
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The maximum number of tokens to generate in the completion.
        /// Defaults to 16.
        /// </summary>
        [JsonPropertyName("max_tokens")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// Defaults to 1.
        /// </summary>
        [JsonPropertyName("temperature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Temperature { get; set; }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// Defaults to 1.
        /// </summary>
        [JsonPropertyName("top_p")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TopP { get; set; }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Defaults to 1.
        /// </summary>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// Whether to stream back partial progress. If set, tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        [JsonPropertyName("stream")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Stream { get; set; }

        /// <summary>
        /// Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens. For example, if logprobs is 5, the API will return a list of the 5 most likely tokens. The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the response.
        /// The maximum value for logprobs is 5.
        /// </summary>
        [JsonPropertyName("logprobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? LogProbs { get; set; }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        [JsonPropertyName("stop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Stop { get; set; }
    }
}
