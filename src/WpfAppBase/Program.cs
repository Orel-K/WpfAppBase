
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using WpfAppBase;
using WpfAppBase.Services;

var builder = App.CreateBuilder();

builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

builder.Services.AddViewModelsFromCurrentAssembly();

builder.Services.AddHostedService<BackgroundTicker>();

var app = builder.Build();

app.Run();

