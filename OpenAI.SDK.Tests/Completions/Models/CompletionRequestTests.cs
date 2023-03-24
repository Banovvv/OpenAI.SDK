using FluentAssertions;
using OpenAI.SDK.Common.Constants;
using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK.Tests.Completions.Models
{
    public class CompletionRequestTests
    {
        [Theory]
        [InlineData("text-ada-001")]
        [InlineData("text-curie-001")]
        [InlineData("text-babbage-001")]
        [InlineData("text-davinci-001")]
        [InlineData("text-davinci-002")]
        [InlineData("text-davinci-003")]
        public void GivenValidModelAndPrompt_WhenConstructorIsInvoked_ThenCompletionRequestIsReturned(string model)
        {
            var prompt = "Why is Grogu so cute?";

            var request = new CompletionRequest(model, prompt);

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(CompletionRequest));
            request.Model.Should().Be(model);
            request.Prompt.Should().Be(prompt);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Grogu")]
        [InlineData("text-davinci-005")]
        public void GivenInvalidModel_WhenConstructorIsInvoked_ThenArgumentExceptionIsThrown(string model)
        {
            var prompt = "Why is Grogu so cute?";

            Action action = () => new CompletionRequest(model, prompt);

            action.Should()
                .Throw<ArgumentException>()
                .WithMessage(string.Format($"{ValidationMessages.Completions.Model} (Parameter '{nameof(model)}')", model));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GivenInvalidPromp_WhenConstructorIsInvoked_ThenArgumentNullExceptionIsThrown(string prompt)
        {
            var model = "text-davinci-003";

            Action action = () => new CompletionRequest(model, prompt);

            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage($"{ValidationMessages.Completions.Prompt} (Parameter '{nameof(prompt)}')");
        }
    }
}
