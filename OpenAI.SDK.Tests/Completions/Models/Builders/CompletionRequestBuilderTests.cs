using FluentAssertions;
using OpenAI.SDK.Completions.Builders;
using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK.Tests.Completions.Models.Builders
{
    public class CompletionRequestBuilderTests
    {
        private readonly string _model = "some model";
        private readonly string _prompt = "some prompt";
        private readonly int _maxTokens = 1;
        private readonly double _temperature = 1.0;
        private readonly double _topP = 1.0;
        private readonly int _n = 1;
        private readonly bool _stream = true;
        private readonly int _logProbs = 1;
        private readonly string _stop = "some stop";

        private readonly CompletionRequestBuilder _builder;

        public CompletionRequestBuilderTests()
        {
            _builder = new CompletionRequestBuilder();
        }

        [Fact]
        public void GivenModelAndPrompt_WhenBuildIsInvoked_ThenCompletionRequestIsReturned()
        {
            var request = _builder
                .WithModel(_model)
                .WithPrompt(_prompt)
                .Build();

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(CompletionRequest));
        }

        [Fact]
        public void GivenValidParameters__WhenBuildIsInvoked_ThenCompletionRequestIsReturned()
        {
            var request = _builder
                .WithModel(_model)
                .WithPrompt(_prompt)
                .WithMaxTokens(_maxTokens)
                .WithTemperature(_temperature)
                .WithTopP(_topP)
                .WithN(_n)
                .WithStream(_stream)
                .WithLogProbs(_logProbs)
                .WithStop(_stop)
                .Build();

            request.Should().NotBeNull();
            request.Model.Should().Be(_model);
            request.Prompt.Should().Be(_prompt);
            request.MaxTokens.Should().Be(_maxTokens);
            request.Temperature.Should().Be(_temperature);
            request.TopP.Should().Be(_topP);
            request.N.Should().Be(_n);
            request.Stream.Should().Be(_stream);
            request.LogProbs.Should().Be(_logProbs);
            request.Stop.Should().Be(_stop);
        }

        [Fact]
        public void GivenNoModel_WhenBuildIsInvoked_ThenArgumentNullExceptionIsThrown()
        {
            Action action = () => _builder
                .WithPrompt(_prompt)
                .Build();

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GivenNoPrompt_WhenBuildIsInvoked_ThenArgumentNullExceptionIsThrown()
        {
            Action action = () => _builder
                .WithModel(_model)
                .Build();

            action.Should().Throw<ArgumentNullException>();
        }
    }
}
