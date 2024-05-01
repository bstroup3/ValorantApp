using Microsoft.AspNetCore.WebUtilities;
using ValorantApp.Shared.Agents;
using ValorantApp.Shared.Maps;

namespace ValorantApp.Shared;
public interface IValorantApiService
{
    public Task<Agent[]> GetAgentsAsync(GetDataRequest request, CancellationToken cancellationToken);
    public Task<Map[]> GetMapsAsync(GetDataRequest request, CancellationToken cancellationToken);
}
public class ValorantApiService(ValorantApiSettings valorantApiSettings, HttpClient httpClient, CancellationToken cancellationToken = default) : IValorantApiService
{
    public async Task<Agent[]> GetAgentsAsync(GetDataRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"agents/", nameof(GetDataRequest.Limit), request.Limit.ToString());
        //var getAgentResponse = await httpClient.GetFromJsonAsync<GetAgentsResponse>(requestUrl, cancellationToken);
        var json = await httpClient.GetStringAsync(requestUrl, cancellationToken);
        var getAgentResponse = GetAgentsResponse.FromJson(json);

        return getAgentResponse!.Data;
    }

    public async Task<Map[]> GetMapsAsync(GetDataRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"maps/", nameof(GetDataRequest.Limit), request.Limit.ToString());
        //var getAgentResponse = await httpClient.GetFromJsonAsync<GetAgentsResponse>(requestUrl, cancellationToken);
        var json = await httpClient.GetStringAsync(requestUrl, cancellationToken);
        var getMapResponse = GetMapResponse.FromJson(json);

        return getMapResponse!.Data;
    }
}

public class ValorantApiSettings
{
    public const string ValorantApi = nameof(ValorantApi);
    public string BaseUrl => "https://valorant-api.com/v1/";
}

public class GetDataRequest
{
    public int Limit { get; set; } = int.MaxValue;
}