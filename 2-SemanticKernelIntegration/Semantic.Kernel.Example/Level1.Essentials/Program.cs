using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

IKernelBuilder? builder = Kernel.CreateBuilder()
    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

Kernel? kernel = builder.Build();

while (true)
{
    Console.WriteLine("Soru Sor : ");
    string input = Console.ReadLine();
    FunctionResult? response = await kernel.InvokePromptAsync(input);
    Console.WriteLine($"Cevap : \n------------------------------------\n{response}\n------------------------------------");
}