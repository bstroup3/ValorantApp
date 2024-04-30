using Microsoft.AspNetCore.WebUtilities;
using ValorantApp.Features.Pages;

namespace ValorantApp.Shared;
public interface IValorantApiService
{
    public Task<Agents[]> GetAgents(GetAgentsRequest request, CancellationToken cancellationToken);
}
public class ValorantApiService(ValorantApiSettings valorantApiSettings, HttpClient httpClient, CancellationToken cancellationToken) : IValorantApiService
{
    public async Task<Agents[]> GetAgents(GetAgentsRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"/agents/{request.AgentId}/", nameof(GetAgentsRequest.Limit), request.Limit.ToString());
        var getAgentResponse = await httpClient.GetFromJsonAsync<GetAgentsResponse>(requestUrl, cancellationToken);

        return getAgentResponse!.;
    }
}

public class ValorantApiSettings
{
    public const string ValorantApi = nameof(ValorantApi);
    public string BaseUrl => "https://valorant-api.com/v1/";
}

public class GetAgentsRequest
{
    public int Limit { get; set; } = int.MaxValue;
    public required string AgentId { get; set;}
}

public class GetAgentsResponse
{
    public Agent[] Agents { get; set; } = [];
}

//Need to create object