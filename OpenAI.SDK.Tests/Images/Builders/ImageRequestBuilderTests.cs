using FluentAssertions;
using OpenAI.SDK.Images.Builders;
using OpenAI.SDK.Images.Models;

namespace OpenAI.SDK.Tests.Images.Builders
{
    public class ImageRequestBuilderTests
    {
        private readonly string _prompt = "Why is Grogu so cute?";
        private readonly int _n = 1;
        private readonly string _size = "1024x1024";
        private readonly string _responseFormat = "url";

        private readonly ImageRequestBuilder _builder;

        public ImageRequestBuilderTests()
        {
            _builder = new ImageRequestBuilder();
        }

        [Fact]
        public void GivenValidPrompt_WhenBuildIsInvoked_ThenImageRequestIsReturned()
        {
            var request = _builder
                .WithPrompt(_prompt)
                .Build();

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(ImageRequest));
        }

        [Fact]
        public void GivenInvalidPrompt_WhenBuildIsInvoked_ThenArgumentNullExceptionIsThrown()
        {
            Action action = () => _builder
                .WithPrompt(null)
                .Build();

            action.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void GivenValidParameters_WhenBuildIsInvoked_ThenImageRequestIsReturned()
        {
            var request = _builder
                .WithPrompt(_prompt)
                .WithN(_n)
                .WithSize(_size)
                .WithResponseFormat(_responseFormat)
                .Build();

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(ImageRequest));
            request.Prompt.Should().Be(_prompt);
            request.N.Should().Be(_n);
            request.Size.Should().Be(_size);
            request.ResponseFormat.Should().Be(_responseFormat);
        }
    }
}
