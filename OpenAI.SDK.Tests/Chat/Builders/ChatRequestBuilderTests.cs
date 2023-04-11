using FluentAssertions;
using OpenAI.SDK.Chat.Builders;
using OpenAI.SDK.Chat.Models;

namespace OpenAI.SDK.Tests.Chat.Builders
{
    public class ChatRequestBuilderTests
    {
        private readonly string _model = "gpt-3.5-turbo";
        private readonly IEnumerable<ChatMessage> _messages;
        private readonly int _maxTokens = 1;
        private readonly double _temperature = 1.0;
        private readonly double _topP = 1.0;
        private readonly int _n = 1;
        private readonly bool _stream = true;
        private readonly string _stop = "some stop";
        private readonly double _frequencyPenalty = 0.5;
        private readonly double _presencePenalty = 1.5;
        private readonly string _user = "Din Djarin";

        private readonly ChatRequestBuilder _builder;

        public ChatRequestBuilderTests()
        {
            _builder = new ChatRequestBuilder();
            _messages = new List<ChatMessage>()
            {
                new ChatMessage(
                    ChatMessageRole.System,
                    "Why is Grogu so cute?")
            };
        }

        [Fact]
        public void GivenModelAndPrompt_WhenBuildIsInvoked_ThenChatRequestIsReturned()
        {
            var request = _builder
                .WithModel(_model)
                .WithMessages(_messages)
                .Build();

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(ChatRequest));
        }

        [Fact]
        public void GivenValidParameters__WhenBuildIsInvoked_ThenChatRequestIsReturned()
        {
            var request = _builder
                .WithModel(_model)
                .WithMessages(_messages)
                .WithMaxTokens(_maxTokens)
                .WithTemperature(_temperature)
                .WithTopP(_topP)
                .WithN(_n)
                .WithStream(_stream)
                .WithStop(_stop)
                .WithFrequencyPenalty(_frequencyPenalty)
                .WithPresencePenalty(_presencePenalty)
                .WithUser(_user)
                .Build();

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(ChatRequest));
            request.Model.Should().Be(_model);
            request.Messages.Should().BeEquivalentTo(_messages);
            request.MaxTokens.Should().Be(_maxTokens);
            request.Temperature.Should().Be(_temperature);
            request.TopP.Should().Be(_topP);
            request.N.Should().Be(_n);
            request.Stream.Should().Be(_stream);
            request.Stop.Should().Be(_stop);
            request.FrequencyPenalty.Should().Be(_frequencyPenalty);
            request.PresencePenalty.Should().Be(_presencePenalty);
            request.User.Should().Be(_user);
        }
    }
}
