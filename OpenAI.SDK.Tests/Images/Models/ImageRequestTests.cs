using FluentAssertions;
using OpenAI.SDK.Common.Constants;
using OpenAI.SDK.Images.Models;
using System.Reflection.Metadata;

namespace OpenAI.SDK.Tests.Images.Models
{
    public class ImageRequestTests
    {
        [Fact]
        public void GivenValidPrompt_WhenConstructorIsInvoked_ThenImageRequestIsReturned()
        {
            var prompt = "Generage a cute Grogu image";

            var request = new ImageRequest(prompt);

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(ImageRequest));
            request.Prompt.Should().Be(prompt);
        }

        [Fact]
        public void GivenValidParameters_WhenConstructorIsInvoked_ThenImageRequestIsReturned()
        {
            var prompt = "Generage a cute Grogu image";
            var n = 1;
            var size = "1024x1024";
            var responseFormat = "url";

            var request = new ImageRequest(
                prompt,
                n,
                size,
                responseFormat);

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(ImageRequest));
            request.Prompt.Should().Be(prompt);
            request.N.Should().Be(n);
            request.Size.Should().Be(size);
            request.ResponseFormat.Should().Be(responseFormat);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GivenInvalidPrompt_WhenConstructorIsInvoked_ThenArgumentNullExceptionIsThrown(string prompt)
        {
            var n = 1;
            var size = "1024x1024";
            var responseFormat = "url";

            Action action = () => new ImageRequest(prompt, n, size, responseFormat);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage($"{ValidationMessages.Images.Prompt} (Parameter '{nameof(prompt)}')");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(11)]
        public void GivenInvalidN_WhenConstructorIsInvoked_ThenArgumentOutOfRangeExceptionIsThrown(int n)
        {
            var prompt = "prompt";
            var size = "1024x1024";
            var responseFormat = "url";

            Action action = () => new ImageRequest(prompt, n, size, responseFormat);

            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage($"{ValidationMessages.Images.N} (Parameter '{nameof(n)}')");
        }

        [Theory]
        [InlineData("Grogu")]
        [InlineData("2048x2048")]
        [InlineData("Size doesn't matter")]
        public void GivenInvalidSize_WhenConstructorIsInvoked_ThenArgumentOutOfRangeExceptionIsThrown(string size)
        {
            var prompt = "prompt";
            var n = 1;
            var responseFormat = "url";

            Action action = () => new ImageRequest(prompt, n, size, responseFormat);

            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage($"{ValidationMessages.Images.Size} (Parameter '{nameof(size)}')");
        }

        [Theory]
        [InlineData("jpeg")]
        [InlineData(".png")]
        [InlineData("Grogu")]
        public void GivenInvalidResponseFormat_WhenConstructorIsInvoked_ThenArgumentOutOfRangeExceptionIsThrown(string responseFormat)
        {
            var prompt = "prompt";
            var n = 1;
            var size = "1024x1024";

            Action action = () => new ImageRequest(prompt, n, size, responseFormat);

            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage($"{ValidationMessages.Images.ResponseFormat} (Parameter '{nameof(responseFormat)}')");
        }
    }
}
