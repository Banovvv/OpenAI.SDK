using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK.Completions.Builders
{
    public class CompletionRequestBuilder
    {
        private string? Model { get; set; }
        private string? Prompt { get; set; }
        private int? MaxTokens { get; set; }
        private double? Temperature { get; set; }
        private double? TopP { get; set; }
        private int? N { get; set; }
        private bool? Stream { get; set; }
        private int? LogProbs { get; set; }
        private string? Stop { get; set; }

        /// <summary>
        /// ID of the model to use.
        /// </summary>
        public CompletionRequestBuilder WithModel(string model)
        {
            Model = model;
            return this;
        }

        /// <summary>
        /// The prompt to generate completions for, encoded as a string.
        /// </summary>
        public CompletionRequestBuilder WithPrompt(string prompt)
        {
            Prompt = prompt;
            return this;
        }

        /// <summary>
        /// The maximum number of tokens to generate in the completion.
        /// Defaults to 16.
        /// </summary>
        public CompletionRequestBuilder WithMaxTokens(int maxTokens)
        {
            MaxTokens = maxTokens;
            return this;
        }

        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// Defaults to 1.
        /// </summary>
        public CompletionRequestBuilder WithTemperature(double temperature)
        {
            Temperature = temperature;
            return this;
        }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// Defaults to 1.
        /// </summary>
        public CompletionRequestBuilder WithTopP(double topP)
        {
            TopP = topP;
            return this;
        }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Defaults to 1.
        /// </summary>
        public CompletionRequestBuilder WithN(int n)
        {
            N = n;
            return this;
        }

        /// <summary>
        /// Whether to stream back partial progress. If set, tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        public CompletionRequestBuilder WithStream(bool stream)
        {
            Stream = stream;
            return this;
        }

        /// <summary>
        /// Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens. For example, if logprobs is 5, the API will return a list of the 5 most likely tokens. The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the response.
        /// The maximum value for logprobs is 5.
        /// </summary>
        public CompletionRequestBuilder WithLogProbs(int logProbs)
        {
            LogProbs = logProbs;
            return this;
        }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        public CompletionRequestBuilder WithStop(string stop)
        {
            Stop = stop;
            return this;
        }

        /// <summary>
		/// Creates a new <see cref="CompletionRequest"/> with the specified parameters
		/// </summary>
        public CompletionRequest Build()
        {
            ArgumentNullException.ThrowIfNull(Model, nameof(Model));
            ArgumentNullException.ThrowIfNull(Prompt, nameof(Prompt));

            return new CompletionRequest(
                Model,
                Prompt,
                MaxTokens,
                Temperature,
                TopP,
                N,
                Stream,
                LogProbs,
                Stop);
        }
    }
}
