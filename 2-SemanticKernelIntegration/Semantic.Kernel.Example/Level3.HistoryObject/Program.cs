using Codeblaze.SemanticKernel.Connectors.Ollama;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion("deepseek-r1:latest", "http://localhost:11434");

builder.Services.AddScoped<HttpClient>();

Kernel? kernel = builder.Build();

ChatHistory? history = new ChatHistory();
//İlk mesaj eklenmektedir.
history.AddUserMessage("Merhaba! Bu gün hava nasıl?");

//Model çağrısı yapılmaktadır.
IChatCompletionService? chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
ChatMessageContent? response = await chatCompletionService.GetChatMessageContentAsync(history);

//Response history'e eklenmektedir.
history.AddAssistantMessage(response.ToString());

//Aynı şekilde yeni mesajda history'e eklenerek devam edilir.
history.AddUserMessage("Peki, hafta sonu için hava tahmini nedir?");
ChatMessageContent? response2 = await chatCompletionService.GetChatMessageContentAsync(history);
history.AddAssistantMessage(response2.ToString());

Console.WriteLine(response2.ToString());

Console.Read();