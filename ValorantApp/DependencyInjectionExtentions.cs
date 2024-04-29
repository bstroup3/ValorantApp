using MudBlazor.Services;
using ValorantApp.Features.Pages;
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
        
    }
}
