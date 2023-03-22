using FluentAssertions;
using OpenAI.SDK.Completions.Builders;
using OpenAI.SDK.Completions.Models;

namespace OpenAI.SDK.Tests.Completions.Models.Builders
{
    public class CompletionRequestBuilderTests
    {
        [Fact]
        public void GivenModelAndPrompt_WhenBuildIsInvoked_ThenCompletionRequestIsReturned()
        {
            var model = "some model";
            var prompt = "some prompt";

            var request = new CompletionRequestBuilder()
                .WithModel(model)
                .WithPrompt(prompt)
                .Build();

            request.Should().NotBeNull();
            request.GetType().Should().Be(typeof(CompletionRequest));
        }
    }
}
