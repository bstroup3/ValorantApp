namespace ValorantApp.Features.Pages
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Data
    {
        [JsonProperty("version")]
        public string Version { get; set; } = null!;

        [JsonProperty("characters")]
        public Act[] Characters { get; set; }

        [JsonProperty("weapons")]
        public Weapon[] Weapons { get; set; }

        [JsonProperty("weaponSkins")]
        public WeaponSkin[] WeaponSkins { get; set; }

        [JsonProperty("maps")]
        public Map[] Maps { get; set; }

        [JsonProperty("playerCards")]
        public Act[] PlayerCards { get; set; }

        [JsonProperty("playerTitles")]
        public Act[] PlayerTitles { get; set; }

        [JsonProperty("charms")]
        public Act[] Charms { get; set; }

        [JsonProperty("sprays")]
        public Act[] Sprays { get; set; }

        [JsonProperty("gameModes")]
        public Act[] GameModes { get; set; }

        [JsonProperty("acts")]
        public Act[] Acts { get; set; }

        [JsonProperty("characterRoles")]
        public Act[] CharacterRoles { get; set; }

        [JsonProperty("matchmakingQueues")]
        public Act[] MatchmakingQueues { get; set; }
    }

    public partial class Abilities
    {
        [JsonProperty("Ability1")]
        public Act Ability1 { get; set; }

        [JsonProperty("Ability2")]
        public Act Ability2 { get; set; }

        [JsonProperty("Grenade")]
        public Act Grenade { get; set; }

        [JsonProperty("Ultimate")]
        public Act Ultimate { get; set; }

        [JsonProperty("Passive", NullValueHandling = NullValueHandling.Ignore)]
        public Act Passive { get; set; }
    }

    public partial class Act
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public TypeEnum? Type { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public Description Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public Description Description { get; set; }

        [JsonProperty("abilities", NullValueHandling = NullValueHandling.Ignore)]
        public Abilities Abilities { get; set; }

        [JsonProperty("levels", NullValueHandling = NullValueHandling.Ignore)]
        public Act[] Levels { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public Description Duration { get; set; }

        [JsonProperty("titleText", NullValueHandling = NullValueHandling.Ignore)]
        public Description TitleText { get; set; }
    }

    public partial class Description
    {
        [JsonProperty("defaultText")]
        public string DefaultText { get; set; }

        [JsonProperty("localizedByCulture")]
        public Dictionary<string, string> LocalizedByCulture { get; set; }
    }

    public partial class Map
    {
        [JsonProperty("coordinates")]
        public Description Coordinates { get; set; }

        [JsonProperty("xScalarToAdd")]
        public double XScalarToAdd { get; set; }

        [JsonProperty("xMultiplier")]
        public double XMultiplier { get; set; }

        [JsonProperty("yScalarToAdd")]
        public double YScalarToAdd { get; set; }

        [JsonProperty("yMultiplier")]
        public double YMultiplier { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public Description Name { get; set; }
    }

    public partial class WeaponSkin
    {
        [JsonProperty("weaponId")]
        public WeaponId WeaponId { get; set; }

        [JsonProperty("defaultChromaId")]
        public string DefaultChromaId { get; set; }

        [JsonProperty("chromas")]
        public Act[] Chromas { get; set; }

        [JsonProperty("levels")]
        public Act[] Levels { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public Description Name { get; set; }
    }

    public partial class Weapon
    {
        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public Description Name { get; set; }
    }

    public partial class Stats
    {
        [JsonProperty("fireMode")]
        public FireMode FireMode { get; set; }

        [JsonProperty("fireRate")]
        public double FireRate { get; set; }

        [JsonProperty("magazineSize")]
        public long MagazineSize { get; set; }

        [JsonProperty("runSpeedMultiplier")]
        public double RunSpeedMultiplier { get; set; }

        [JsonProperty("equipTimeSeconds")]
        public double EquipTimeSeconds { get; set; }

        [JsonProperty("reloadTimeSeconds")]
        public double ReloadTimeSeconds { get; set; }

        [JsonProperty("firstBulletAccuracy")]
        public double FirstBulletAccuracy { get; set; }

        [JsonProperty("shotgunPelletCount")]
        public long ShotgunPelletCount { get; set; }

        [JsonProperty("wallPenetration")]
        public WallPenetration WallPenetration { get; set; }

        [JsonProperty("damageRanges")]
        public DamageRange[] DamageRanges { get; set; }

        [JsonProperty("altFireType")]
        public AltFireType AltFireType { get; set; }

        [JsonProperty("aDSStats")]
        public ADsStats ADsStats { get; set; }

        [JsonProperty("airBurstStats")]
        public AirBurstStats AirBurstStats { get; set; }

        [JsonProperty("altShotgunStats")]
        public AltShotgunStats AltShotgunStats { get; set; }

        [JsonProperty("feature")]
        public Feature Feature { get; set; }
    }

    public partial class ADsStats
    {
        [JsonProperty("zoomMultiplier")]
        public double ZoomMultiplier { get; set; }

        [JsonProperty("fireRate")]
        public double FireRate { get; set; }

        [JsonProperty("runSpeedMultiplier")]
        public double RunSpeedMultiplier { get; set; }

        [JsonProperty("burstCount")]
        public long BurstCount { get; set; }

        [JsonProperty("firstBulletAccuracy")]
        public double FirstBulletAccuracy { get; set; }
    }

    public partial class AirBurstStats
    {
        [JsonProperty("burstDistance")]
        public double BurstDistance { get; set; }

        [JsonProperty("shotgunPelletCount")]
        public long ShotgunPelletCount { get; set; }
    }

    public partial class AltShotgunStats
    {
        [JsonProperty("shotgunPelletCount")]
        public long ShotgunPelletCount { get; set; }

        [JsonProperty("burstRate")]
        public double BurstRate { get; set; }
    }

    public partial class DamageRange
    {
        [JsonProperty("rangeStartMeters")]
        public long RangeStartMeters { get; set; }

        [JsonProperty("rangeEndMeters")]
        public long RangeEndMeters { get; set; }

        [JsonProperty("headDamage")]
        public double HeadDamage { get; set; }

        [JsonProperty("bodyDamage")]
        public long BodyDamage { get; set; }

        [JsonProperty("legDamage")]
        public double LegDamage { get; set; }
    }

    public enum TypeEnum { Act, Episode };

    public enum WeaponId { A03B24D34319996D0F8C94Bbfba1Dfc7, Ae3De1424D852547Dd264E90Bed35Cf7, C4883E504494202C3Ec36B8A9284F00B, E336C6B8418D9340D77F7A9E4Cfe0702, Ec845Bf44F79DddaA3Da0Db3774B2794, Ee8E8D15496B07AcE5F68Fae5D4C7B1A, F7E1B4544Ad41063Ec0A159E56B58941, The1Baa85B44C70128464Bb6481Dfc3Bb4E, The29A0Cfab485BF5D5779AB59F85E204A8, The2F59173C4BedB6C32191Dea9B58Be9C7, The42Da8Ccc40D5AffcBeec15Aa47B42Eda, The44D4E95C4157003781B217841Bf2E8E3, The462080D1403529377C0927Aa2A5C27A7, The4Ade7Faa4Cf1837695Ef39884480959B, The55D8A0F44274Ca67Fe2C06Ab45Efdf58, The63E6C2B64A8E869C3D4CE38355226584, The910Be174449BC412Ab22D0873436B21B, The9C82E19D457502001A813Eacf00Cf872 };

    public enum AltFireType { Ads, AirBurst, None, Shotgun };

    public enum Feature { DualZoom, None, RofIncrease, Silenced };

    public enum FireMode { FullyAutomatic, SemiAutomatic };

    public enum WallPenetration { High, Low, Medium, None };

    public partial class Data
    {
        public static Data FromJson(string json) => JsonConvert.DeserializeObject<Data>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Data self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                TypeEnumConverter.Singleton,
                WeaponIdConverter.Singleton,
                AltFireTypeConverter.Singleton,
                FeatureConverter.Singleton,
                FireModeConverter.Singleton,
                WallPenetrationConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "act":
                    return TypeEnum.Act;
                case "episode":
                    return TypeEnum.Episode;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.Act:
                    serializer.Serialize(writer, "act");
                    return;
                case TypeEnum.Episode:
                    serializer.Serialize(writer, "episode");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class WeaponIdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WeaponId) || t == typeof(WeaponId?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1BAA85B4-4C70-1284-64BB-6481DFC3BB4E":
                    return WeaponId.The1Baa85B44C70128464Bb6481Dfc3Bb4E;
                case "29A0CFAB-485B-F5D5-779A-B59F85E204A8":
                    return WeaponId.The29A0Cfab485BF5D5779AB59F85E204A8;
                case "2F59173C-4BED-B6C3-2191-DEA9B58BE9C7":
                    return WeaponId.The2F59173C4BedB6C32191Dea9B58Be9C7;
                case "42DA8CCC-40D5-AFFC-BEEC-15AA47B42EDA":
                    return WeaponId.The42Da8Ccc40D5AffcBeec15Aa47B42Eda;
                case "44D4E95C-4157-0037-81B2-17841BF2E8E3":
                    return WeaponId.The44D4E95C4157003781B217841Bf2E8E3;
                case "462080D1-4035-2937-7C09-27AA2A5C27A7":
                    return WeaponId.The462080D1403529377C0927Aa2A5C27A7;
                case "4ADE7FAA-4CF1-8376-95EF-39884480959B":
                    return WeaponId.The4Ade7Faa4Cf1837695Ef39884480959B;
                case "55D8A0F4-4274-CA67-FE2C-06AB45EFDF58":
                    return WeaponId.The55D8A0F44274Ca67Fe2C06Ab45Efdf58;
                case "63E6C2B6-4A8E-869C-3D4C-E38355226584":
                    return WeaponId.The63E6C2B64A8E869C3D4CE38355226584;
                case "910BE174-449B-C412-AB22-D0873436B21B":
                    return WeaponId.The910Be174449BC412Ab22D0873436B21B;
                case "9C82E19D-4575-0200-1A81-3EACF00CF872":
                    return WeaponId.The9C82E19D457502001A813Eacf00Cf872;
                case "A03B24D3-4319-996D-0F8C-94BBFBA1DFC7":
                    return WeaponId.A03B24D34319996D0F8C94Bbfba1Dfc7;
                case "AE3DE142-4D85-2547-DD26-4E90BED35CF7":
                    return WeaponId.Ae3De1424D852547Dd264E90Bed35Cf7;
                case "C4883E50-4494-202C-3EC3-6B8A9284F00B":
                    return WeaponId.C4883E504494202C3Ec36B8A9284F00B;
                case "E336C6B8-418D-9340-D77F-7A9E4CFE0702":
                    return WeaponId.E336C6B8418D9340D77F7A9E4Cfe0702;
                case "EC845BF4-4F79-DDDA-A3DA-0DB3774B2794":
                    return WeaponId.Ec845Bf44F79DddaA3Da0Db3774B2794;
                case "EE8E8D15-496B-07AC-E5F6-8FAE5D4C7B1A":
                    return WeaponId.Ee8E8D15496B07AcE5F68Fae5D4C7B1A;
                case "F7E1B454-4AD4-1063-EC0A-159E56B58941":
                    return WeaponId.F7E1B4544Ad41063Ec0A159E56B58941;
            }
            throw new Exception("Cannot unmarshal type WeaponId");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WeaponId)untypedValue;
            switch (value)
            {
                case WeaponId.The1Baa85B44C70128464Bb6481Dfc3Bb4E:
                    serializer.Serialize(writer, "1BAA85B4-4C70-1284-64BB-6481DFC3BB4E");
                    return;
                case WeaponId.The29A0Cfab485BF5D5779AB59F85E204A8:
                    serializer.Serialize(writer, "29A0CFAB-485B-F5D5-779A-B59F85E204A8");
                    return;
                case WeaponId.The2F59173C4BedB6C32191Dea9B58Be9C7:
                    serializer.Serialize(writer, "2F59173C-4BED-B6C3-2191-DEA9B58BE9C7");
                    return;
                case WeaponId.The42Da8Ccc40D5AffcBeec15Aa47B42Eda:
                    serializer.Serialize(writer, "42DA8CCC-40D5-AFFC-BEEC-15AA47B42EDA");
                    return;
                case WeaponId.The44D4E95C4157003781B217841Bf2E8E3:
                    serializer.Serialize(writer, "44D4E95C-4157-0037-81B2-17841BF2E8E3");
                    return;
                case WeaponId.The462080D1403529377C0927Aa2A5C27A7:
                    serializer.Serialize(writer, "462080D1-4035-2937-7C09-27AA2A5C27A7");
                    return;
                case WeaponId.The4Ade7Faa4Cf1837695Ef39884480959B:
                    serializer.Serialize(writer, "4ADE7FAA-4CF1-8376-95EF-39884480959B");
                    return;
                case WeaponId.The55D8A0F44274Ca67Fe2C06Ab45Efdf58:
                    serializer.Serialize(writer, "55D8A0F4-4274-CA67-FE2C-06AB45EFDF58");
                    return;
                case WeaponId.The63E6C2B64A8E869C3D4CE38355226584:
                    serializer.Serialize(writer, "63E6C2B6-4A8E-869C-3D4C-E38355226584");
                    return;
                case WeaponId.The910Be174449BC412Ab22D0873436B21B:
                    serializer.Serialize(writer, "910BE174-449B-C412-AB22-D0873436B21B");
                    return;
                case WeaponId.The9C82E19D457502001A813Eacf00Cf872:
                    serializer.Serialize(writer, "9C82E19D-4575-0200-1A81-3EACF00CF872");
                    return;
                case WeaponId.A03B24D34319996D0F8C94Bbfba1Dfc7:
                    serializer.Serialize(writer, "A03B24D3-4319-996D-0F8C-94BBFBA1DFC7");
                    return;
                case WeaponId.Ae3De1424D852547Dd264E90Bed35Cf7:
                    serializer.Serialize(writer, "AE3DE142-4D85-2547-DD26-4E90BED35CF7");
                    return;
                case WeaponId.C4883E504494202C3Ec36B8A9284F00B:
                    serializer.Serialize(writer, "C4883E50-4494-202C-3EC3-6B8A9284F00B");
                    return;
                case WeaponId.E336C6B8418D9340D77F7A9E4Cfe0702:
                    serializer.Serialize(writer, "E336C6B8-418D-9340-D77F-7A9E4CFE0702");
                    return;
                case WeaponId.Ec845Bf44F79DddaA3Da0Db3774B2794:
                    serializer.Serialize(writer, "EC845BF4-4F79-DDDA-A3DA-0DB3774B2794");
                    return;
                case WeaponId.Ee8E8D15496B07AcE5F68Fae5D4C7B1A:
                    serializer.Serialize(writer, "EE8E8D15-496B-07AC-E5F6-8FAE5D4C7B1A");
                    return;
                case WeaponId.F7E1B4544Ad41063Ec0A159E56B58941:
                    serializer.Serialize(writer, "F7E1B454-4AD4-1063-EC0A-159E56B58941");
                    return;
            }
            throw new Exception("Cannot marshal type WeaponId");
        }

        public static readonly WeaponIdConverter Singleton = new WeaponIdConverter();
    }

    internal class AltFireTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AltFireType) || t == typeof(AltFireType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ADS":
                    return AltFireType.Ads;
                case "AirBurst":
                    return AltFireType.AirBurst;
                case "None":
                    return AltFireType.None;
                case "Shotgun":
                    return AltFireType.Shotgun;
            }
            throw new Exception("Cannot unmarshal type AltFireType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AltFireType)untypedValue;
            switch (value)
            {
                case AltFireType.Ads:
                    serializer.Serialize(writer, "ADS");
                    return;
                case AltFireType.AirBurst:
                    serializer.Serialize(writer, "AirBurst");
                    return;
                case AltFireType.None:
                    serializer.Serialize(writer, "None");
                    return;
                case AltFireType.Shotgun:
                    serializer.Serialize(writer, "Shotgun");
                    return;
            }
            throw new Exception("Cannot marshal type AltFireType");
        }

        public static readonly AltFireTypeConverter Singleton = new AltFireTypeConverter();
    }

    internal class FeatureConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Feature) || t == typeof(Feature?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "DualZoom":
                    return Feature.DualZoom;
                case "None":
                    return Feature.None;
                case "ROFIncrease":
                    return Feature.RofIncrease;
                case "Silenced":
                    return Feature.Silenced;
            }
            throw new Exception("Cannot unmarshal type Feature");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Feature)untypedValue;
            switch (value)
            {
                case Feature.DualZoom:
                    serializer.Serialize(writer, "DualZoom");
                    return;
                case Feature.None:
                    serializer.Serialize(writer, "None");
                    return;
                case Feature.RofIncrease:
                    serializer.Serialize(writer, "ROFIncrease");
                    return;
                case Feature.Silenced:
                    serializer.Serialize(writer, "Silenced");
                    return;
            }
            throw new Exception("Cannot marshal type Feature");
        }

        public static readonly FeatureConverter Singleton = new FeatureConverter();
    }

    internal class FireModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FireMode) || t == typeof(FireMode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "FullyAutomatic":
                    return FireMode.FullyAutomatic;
                case "SemiAutomatic":
                    return FireMode.SemiAutomatic;
            }
            throw new Exception("Cannot unmarshal type FireMode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FireMode)untypedValue;
            switch (value)
            {
                case FireMode.FullyAutomatic:
                    serializer.Serialize(writer, "FullyAutomatic");
                    return;
                case FireMode.SemiAutomatic:
                    serializer.Serialize(writer, "SemiAutomatic");
                    return;
            }
            throw new Exception("Cannot marshal type FireMode");
        }

        public static readonly FireModeConverter Singleton = new FireModeConverter();
    }

    internal class WallPenetrationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(WallPenetration) || t == typeof(WallPenetration?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "High":
                    return WallPenetration.High;
                case "Low":
                    return WallPenetration.Low;
                case "Medium":
                    return WallPenetration.Medium;
                case "None":
                    return WallPenetration.None;
            }
            throw new Exception("Cannot unmarshal type WallPenetration");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (WallPenetration)untypedValue;
            switch (value)
            {
                case WallPenetration.High:
                    serializer.Serialize(writer, "High");
                    return;
                case WallPenetration.Low:
                    serializer.Serialize(writer, "Low");
                    return;
                case WallPenetration.Medium:
                    serializer.Serialize(writer, "Medium");
                    return;
                case WallPenetration.None:
                    serializer.Serialize(writer, "None");
                    return;
            }
            throw new Exception("Cannot marshal type WallPenetration");
        }

        public static readonly WallPenetrationConverter Singleton = new WallPenetrationConverter();
    }
}
