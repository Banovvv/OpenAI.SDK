using OpenAI.SDK.Chat.Models;

namespace OpenAI.SDK.Chat.Builders
{
    public class ChatRequestBuilder
    {
        private string? Model { get; set; }
        private IEnumerable<ChatMessage>? Messages { get; set; }
        private int? MaxTokens { get; set; }
        private double? Temperature { get; set; }
        private double? TopP { get; set; }
        private int? N { get; set; }
        private bool? Stream { get; set; }
        private string? Stop { get; set; }
        private double? FrequencyPenalty { get; set; }
        private double? PresencePenalty { get; set; }
        private string? User { get; set; }

        /// <summary>
        /// ID of the model to use.
        /// </summary>
        public ChatRequestBuilder WithModel(string model)
        {
            Model = model;
            return this;
        }

        /// <summary>
        /// The messages to generate chat completions for, in the chat format.
        /// </summary>
        public ChatRequestBuilder WithMessages(IEnumerable<ChatMessage> messages)
        {
            Messages = messages;
            return this;
        }

        /// <summary>
        /// The maximum number of tokens to generate in the completion.
        /// Defaults to 16.
        /// </summary>
        public ChatRequestBuilder WithMaxTokens(int maxTokens)
        {
            MaxTokens = maxTokens;
            return this;
        }

        /// <summary>
        /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
        /// Defaults to 1.
        /// </summary>
        public ChatRequestBuilder WithTemperature(double temperature)
        {
            Temperature = temperature;
            return this;
        }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// Defaults to 1.
        /// </summary>
        public ChatRequestBuilder WithTopP(double topP)
        {
            TopP = topP;
            return this;
        }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Defaults to 1.
        /// </summary>
        public ChatRequestBuilder WithN(int n)
        {
            N = n;
            return this;
        }

        /// <summary>
        /// Whether to stream back partial progress. If set, tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        public ChatRequestBuilder WithStream(bool stream)
        {
            Stream = stream;
            return this;
        }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        public ChatRequestBuilder WithStop(string stop)
        {
            Stop = stop;
            return this;
        }

        /// <summary>
        /// Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <param name="frequencyPenalty">Number between -2.0 and 2.0. Defaults to 0.</param>
        public ChatRequestBuilder WithFrequencyPenalty(double frequencyPenalty)
        {
            FrequencyPenalty = frequencyPenalty;
            return this;
        }

        /// <summary>
        /// Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
        /// </summary>
        /// <param name="presencePenalty">Number between -2.0 and 2.0. Defaults to 0.</param>
        public ChatRequestBuilder WithPresencePenalty(double presencePenalty)
        {
            PresencePenalty = presencePenalty;
            return this;
        }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        public ChatRequestBuilder WithUser(string user)
        {
            User = user;
            return this;
        }

        public ChatRequest Build()
        {
            ArgumentNullException.ThrowIfNull(Model, nameof(Model));
            ArgumentNullException.ThrowIfNull(Messages, nameof(Messages));

            return new ChatRequest(
                Model,
                Messages,
                MaxTokens,
                Temperature,
                TopP,
                N,
                Stream,
                FrequencyPenalty,
                PresencePenalty,
                User);
        }
    }
}
