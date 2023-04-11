using OpenAI.SDK.Common.Constants;
using System.Text.Json.Serialization;

namespace OpenAI.SDK.Chat.Models
{
    public class ChatRequest
    {
        public ChatRequest(
            string model,
            IEnumerable<ChatMessage> messages)
        {
            if (!PossibleValues.Chat.Model.Contains(model))
            {
                throw new ArgumentException(
                    string.Format(ValidationMessages.Chat.Model, model),
                    nameof(model));
            }

            Model = model;
            Messages = messages;
        }

        public ChatRequest(
            string model,
            IEnumerable<ChatMessage> messages,
            int? maxTokens = null,
            double? temperature = null,
            double? topP = null,
            int? n = null,
            bool? stream = null,
            string? stop = null,
            double? frequencyPenalty = null,
            double? presencePenalty = null,
            string? user = null)
            : this(model, messages)
        {
            if (temperature != null &&
                temperature < 0 ||
                temperature > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(temperature),
                    ValidationMessages.Chat.Temperature);
            }

            if (topP != null &&
                topP < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(topP),
                    ValidationMessages.Chat.TopP);
            }

            if (frequencyPenalty != null &&
                frequencyPenalty < -2 ||
                frequencyPenalty > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(presencePenalty),
                    ValidationMessages.Chat.FrequencyPenalty);
            }

            if (presencePenalty != null &&
                presencePenalty < -2 ||
                presencePenalty > 2)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(presencePenalty),
                    ValidationMessages.Chat.PresencePenalty);
            }

            MaxTokens = maxTokens;
            Temperature = temperature;
            TopP = topP;
            N = n;
            Stream = stream;
            Stop = stop;
            FrequencyPenalty = frequencyPenalty;
            PresencePenalty = presencePenalty;
            User = user;
        }

        /// <summary>
        /// ID of the model to use.
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// The messages to generate chat completions for, in the chat format.
        /// </summary>
        [JsonPropertyName("messages")]
        public IEnumerable<ChatMessage> Messages { get; set; }

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
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        [JsonPropertyName("stop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Stop { get; set; }

        /// <summary>
		/// Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim. Number between -2.0 and 2.0. Defaults to 0.
		/// </summary>
		[JsonPropertyName("frequency_penalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FrequencyPenalty { get; set; }

        /// <summary>
        /// Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics. Number between -2.0 and 2.0. Defaults to 0.
        /// </summary>
        [JsonPropertyName("presence_penalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PresencePenalty { get; set; }

        /// <summary>
		/// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
		/// </summary>
		[JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }
    }
}
