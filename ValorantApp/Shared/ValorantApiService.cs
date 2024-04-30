﻿using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ValorantApp.Shared;
public interface IValorantApiService
{
    public Task<Agent[]> GetAgentsAsync(GetAgentsRequest request, CancellationToken cancellationToken);
}
public class ValorantApiService(ValorantApiSettings valorantApiSettings, HttpClient httpClient, CancellationToken cancellationToken = default) : IValorantApiService
{
    public async Task<Agent[]> GetAgentsAsync(GetAgentsRequest request, CancellationToken cancellationToken)
    {
        var requestUrl = QueryHelpers.AddQueryString(valorantApiSettings.BaseUrl + $"agents/", nameof(GetAgentsRequest.Limit), request.Limit.ToString());
        var getAgentResponse = await httpClient.GetFromJsonAsync<GetAgentsResponse>(requestUrl, cancellationToken);

        return getAgentResponse!.Agents;
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
}

public class GetAgentsResponse
{
    public Agent[] Agents { get; set; } = [];
}

public partial class AgentResponse
{
    [JsonProperty("status")]
    public long Status { get; set; }

    [JsonProperty("data")]
    public Agent[] Agents { get; set; }
}

public partial class Agent
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("developerName")]
    public string DeveloperName { get; set; }

    [JsonProperty("characterTags")]
    public string[] CharacterTags { get; set; }

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; }

    [JsonProperty("displayIconSmall")]
    public Uri DisplayIconSmall { get; set; }

    [JsonProperty("bustPortrait")]
    public Uri BustPortrait { get; set; }

    [JsonProperty("fullPortrait")]
    public Uri FullPortrait { get; set; }

    [JsonProperty("fullPortraitV2")]
    public Uri FullPortraitV2 { get; set; }

    [JsonProperty("killfeedPortrait")]
    public Uri KillfeedPortrait { get; set; }

    [JsonProperty("background")]
    public Uri Background { get; set; }

    [JsonProperty("backgroundGradientColors")]
    public string[] BackgroundGradientColors { get; set; }

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; }

    [JsonProperty("isFullPortraitRightFacing")]
    public bool IsFullPortraitRightFacing { get; set; }

    [JsonProperty("isPlayableCharacter")]
    public bool IsPlayableCharacter { get; set; }

    [JsonProperty("isAvailableForTest")]
    public bool IsAvailableForTest { get; set; }

    [JsonProperty("isBaseContent")]
    public bool IsBaseContent { get; set; }

    [JsonProperty("role")]
    public Role Role { get; set; }

    [JsonProperty("recruitmentData")]
    public RecruitmentData RecruitmentData { get; set; }

    [JsonProperty("abilities")]
    public Ability[] Abilities { get; set; }

    [JsonProperty("voiceLine")]
    public object VoiceLine { get; set; }
}

public partial class Ability
{
    [JsonProperty("slot")]
    public Slot Slot { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; }
}

public partial class RecruitmentData
{
    [JsonProperty("counterId")]
    public Guid CounterId { get; set; }

    [JsonProperty("milestoneId")]
    public Guid MilestoneId { get; set; }

    [JsonProperty("milestoneThreshold")]
    public long MilestoneThreshold { get; set; }

    [JsonProperty("useLevelVpCostOverride")]
    public bool UseLevelVpCostOverride { get; set; }

    [JsonProperty("levelVpCostOverride")]
    public long LevelVpCostOverride { get; set; }

    [JsonProperty("startDate")]
    public DateTimeOffset StartDate { get; set; }

    [JsonProperty("endDate")]
    public DateTimeOffset EndDate { get; set; }
}

public partial class Role
{
    [JsonProperty("uuid")]
    public Guid Uuid { get; set; }

    [JsonProperty("displayName")]
    public DisplayName DisplayName { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("displayIcon")]
    public Uri DisplayIcon { get; set; }

    [JsonProperty("assetPath")]
    public string AssetPath { get; set; }
}

public enum Slot { Ability1, Ability2, Grenade, Passive, Ultimate };

public enum DisplayName { Controller, Duelist, Initiator, Sentinel };

public partial class AgentResponse
{
    public static AgentResponse FromJson(string json) => JsonConvert.DeserializeObject<AgentResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this AgentResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                SlotConverter.Singleton,
                DisplayNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}

internal class SlotConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Slot) || t == typeof(Slot?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "Ability1":
                return Slot.Ability1;
            case "Ability2":
                return Slot.Ability2;
            case "Grenade":
                return Slot.Grenade;
            case "Passive":
                return Slot.Passive;
            case "Ultimate":
                return Slot.Ultimate;
        }
        throw new Exception("Cannot unmarshal type Slot");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Slot)untypedValue;
        switch (value)
        {
            case Slot.Ability1:
                serializer.Serialize(writer, "Ability1");
                return;
            case Slot.Ability2:
                serializer.Serialize(writer, "Ability2");
                return;
            case Slot.Grenade:
                serializer.Serialize(writer, "Grenade");
                return;
            case Slot.Passive:
                serializer.Serialize(writer, "Passive");
                return;
            case Slot.Ultimate:
                serializer.Serialize(writer, "Ultimate");
                return;
        }
        throw new Exception("Cannot marshal type Slot");
    }

    public static readonly SlotConverter Singleton = new SlotConverter();
}

internal class DisplayNameConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(DisplayName) || t == typeof(DisplayName?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "Controller":
                return DisplayName.Controller;
            case "Duelist":
                return DisplayName.Duelist;
            case "Initiator":
                return DisplayName.Initiator;
            case "Sentinel":
                return DisplayName.Sentinel;
        }
        throw new Exception("Cannot unmarshal type DisplayName");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (DisplayName)untypedValue;
        switch (value)
        {
            case DisplayName.Controller:
                serializer.Serialize(writer, "Controller");
                return;
            case DisplayName.Duelist:
                serializer.Serialize(writer, "Duelist");
                return;
            case DisplayName.Initiator:
                serializer.Serialize(writer, "Initiator");
                return;
            case DisplayName.Sentinel:
                serializer.Serialize(writer, "Sentinel");
                return;
        }
        throw new Exception("Cannot marshal type DisplayName");
    }

    public static readonly DisplayNameConverter Singleton = new DisplayNameConverter();
}