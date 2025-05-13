using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

IKernelBuilder? builder = Kernel.CreateBuilder()
    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

Kernel? kernel = builder.Build();

string? promptTemplate = "Yandaki işlemi hesapla: {{$input}}";
KernelFunction? function = kernel.CreateFunctionFromPrompt(promptTemplate);
KernelArguments? arguments = new KernelArguments { ["input"] = "1 + 2 + 5 * 3" };
FunctionResult? result = await function.InvokeAsync(kernel, arguments);
Console.WriteLine(result);

Console.Read();