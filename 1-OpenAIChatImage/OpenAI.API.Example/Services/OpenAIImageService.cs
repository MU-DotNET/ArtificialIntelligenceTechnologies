using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.Interfaces;

namespace OpenAI.API.Example.Services;

public sealed class OpenAIImageService(IOpenAIService _openAIService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            Console.Write("::");
            var result = await _openAIService.Image.CreateImage(new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ImageCreateRequest()
            {
                Prompt = Console.ReadLine(),
                N = 2,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "test"
            });

            Console.WriteLine(string.Join("\n", result.Results.Select(r => r.Url)));
        }
    }
}
