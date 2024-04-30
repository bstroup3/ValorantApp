using MudBlazor.Services;
using ValorantApp.Features.Pages;
using ValorantApp.Shared;
namespace ValorantApp;

public static class DependencyInjectionExtentions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddMudServices();
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<AgentRequestHandler>());
        builder.Services.AddSingleton<IValorantApiService, ValorantApiService>();
        builder.Services.AddSingleton<ValorantApiSettings>();
        builder.Services.AddHttpClient();
    }
}
