﻿using MediatR;
using Microsoft.AspNetCore.Components;
using ValorantApp.Shared;
using ValorantApp.Infrastructure.Weapons;

namespace ValorantApp.Features.Pages;

public partial class Armory : IDisposable
{
    [Inject] private IMediator Mediator {get; set;} = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly ArmoryRequest _request = new();
    private ArmoryResponse _response = new();
    private bool _isLoading;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
    try
    {
        _response = await Mediator.Send(_request, _cts.Token);
    }
    catch (Exception ex)
    {
        // Handle any errors here, e.g., logging or displaying an error message
        Console.WriteLine($"Error fetching data: {ex.Message}");
    }
    finally
    {
        _isLoading = false;
    }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}

public class ArmoryRequest : IRequest<ArmoryResponse>
{
}

public class ArmoryRequestHandler(IValorantApiService valorantApiService) : IRequestHandler<ArmoryRequest, ArmoryResponse>
{
    public async Task<ArmoryResponse> Handle(ArmoryRequest request, CancellationToken cancellationToken = default)
    {
        var weapons = await valorantApiService.GetWeaponsAsync(new GetDataRequest(), cancellationToken);

        return new ArmoryResponse { Weapons = weapons };
    }
}

public class ArmoryResponse
{
    public IEnumerable<Weapon> Weapons { get; set; } = [];
}