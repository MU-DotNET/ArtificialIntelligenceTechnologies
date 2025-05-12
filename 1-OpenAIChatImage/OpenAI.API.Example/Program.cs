using Betalgo.Ranul.OpenAI.Extensions;
using OpenAI.API.Example.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddOpenAIService(settings => settings.ApiKey = builder.Configuration["OpenAIApiKey"].ToString());
//builder.Services.AddHostedService<OpenAICompletionService>();
builder.Services.AddHostedService<OpenAIImageService>();

var host = builder.Build();
host.Run();
