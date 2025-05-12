using Betalgo.Ranul.OpenAI.Interfaces;
using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels;

namespace OpenAI.API.Example.Services;

public sealed class OpenAICompletionService(IOpenAIService _openAIService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            Console.Write("::");
            CompletionCreateResponse? result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = Console.ReadLine(),
                MaxTokens = 500
            }, Models.Gpt_3_5_Turbo);

            Console.WriteLine(result.Choices[0].Text);
        }
    }
}
