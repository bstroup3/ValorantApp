using System.Text;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ValorantApp.Shared;

namespace ValorantApp.Features.Pages;

public partial class Agents : IDisposable
{
    [Inject] private IMediator Mediator {get; set;} = null;

    private readonly CancellationTokenSource _cts = new();
    private readonly AgentRequest _request = new();
    private AgentResponse _response = new();
    private bool _isLoading;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        _response = await Mediator.Send(_request, _cts.Token);
        _isLoading = false;
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}

public class AgentRequest : IRequest<AgentResponse>
{
}

public class AgentRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<AgentRequest, AgentResponse>
{
    public async Task<AgentResponse> Handle(AgentRequest request, CancellationToken cancellationToken = default)
    {
        var agents = await valorantApiService.GetAgentsAsync(new GetAgentsRequest(), cancellationToken);

        return new AgentResponse { Agents = agents };
    }
}

public class AgentResponse
{
    public IEnumerable<Agent> Agents { get; set; } = [];
}