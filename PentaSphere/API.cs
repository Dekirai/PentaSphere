
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;

namespace PentaSphere
{
    public partial class Room
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("CreationTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? CreationTimestamp { get; set; }

        [JsonProperty("MasterId", NullValueHandling = NullValueHandling.Ignore)]
        public long? MasterId { get; set; }

        [JsonProperty("HostId", NullValueHandling = NullValueHandling.Ignore)]
        public long? HostId { get; set; }

        [JsonProperty("Map", NullValueHandling = NullValueHandling.Ignore)]
        public Map Map { get; set; }

        [JsonProperty("GameRule", NullValueHandling = NullValueHandling.Ignore)]
        public int GameRule { get; set; }

        [JsonProperty("State", NullValueHandling = NullValueHandling.Ignore)]
        public int State { get; set; }

        [JsonProperty("TimeState", NullValueHandling = NullValueHandling.Ignore)]
        public int TimeState { get; set; }

        [JsonProperty("PlayerLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerLimit { get; set; }

        [JsonProperty("SpectatorLimit", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpectatorLimit { get; set; }

        [JsonProperty("Password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("TimeLimit", NullValueHandling = NullValueHandling.Ignore)]
        public int TimeLimit { get; set; }

        [JsonProperty("ScoreLimit", NullValueHandling = NullValueHandling.Ignore)]
        public int ScoreLimit { get; set; }

        [JsonProperty("IsFriendly", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsFriendly { get; set; }

        [JsonProperty("IsBalanced", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBalanced { get; set; }

        [JsonProperty("MinLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int MinLevel { get; set; }

        [JsonProperty("MaxLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxLevel { get; set; }

        [JsonProperty("EquipLimit", NullValueHandling = NullValueHandling.Ignore)]
        public int EquipLimit { get; set; }

        [JsonProperty("IsNoIntrusion", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsNoIntrusion { get; set; }

        [JsonProperty("Players", NullValueHandling = NullValueHandling.Ignore)]
        public List<Player> Players { get; set; }
    }

    public partial class Map
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("GameRules", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> GameRules { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("TeamId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamId { get; set; }

        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("Username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty("Nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string Nickname { get; set; }

        [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }

        [JsonProperty("TotalExperience", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalExperience { get; set; }

        [JsonProperty("PEN", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pen { get; set; }

        [JsonProperty("AP", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ap { get; set; }

        [JsonProperty("ActiveCharacter", NullValueHandling = NullValueHandling.Ignore)]
        public long? ActiveCharacter { get; set; }

        [JsonProperty("Characters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Character> Characters { get; set; }

        [JsonProperty("Inventory", NullValueHandling = NullValueHandling.Ignore)]
        public List<Inventory> Inventory { get; set; }

        [JsonProperty("ChannelId")]
        public object ChannelId { get; set; }

        [JsonProperty("RoomId")]
        public object RoomId { get; set; }
    }

    public partial class Character
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public double? Id { get; set; }

        [JsonProperty("Slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("Gender", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gender { get; set; }

        [JsonProperty("Hair", NullValueHandling = NullValueHandling.Ignore)]
        public Face Hair { get; set; }

        [JsonProperty("Face", NullValueHandling = NullValueHandling.Ignore)]
        public Face Face { get; set; }

        [JsonProperty("Shirt", NullValueHandling = NullValueHandling.Ignore)]
        public Face Shirt { get; set; }

        [JsonProperty("Pants", NullValueHandling = NullValueHandling.Ignore)]
        public Face Pants { get; set; }

        [JsonProperty("Gloves", NullValueHandling = NullValueHandling.Ignore)]
        public Face Gloves { get; set; }

        [JsonProperty("Shoes", NullValueHandling = NullValueHandling.Ignore)]
        public Face Shoes { get; set; }

        [JsonProperty("Weapons", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Weapons { get; set; }

        [JsonProperty("Skills", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Skills { get; set; }

        [JsonProperty("Costumes", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Costumes { get; set; }
    }

    public partial class Face
    {
        [JsonProperty("Item", NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }

        [JsonProperty("Variation", NullValueHandling = NullValueHandling.Ignore)]
        public long? Variation { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }

        [JsonProperty("MasterLevel", NullValueHandling = NullValueHandling.Ignore)]
        public long? MasterLevel { get; set; }

        [JsonProperty("License", NullValueHandling = NullValueHandling.Ignore)]
        public long? License { get; set; }

        [JsonProperty("Gender", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gender { get; set; }
    }

    public partial class Inventory
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public double? Id { get; set; }

        [JsonProperty("Item", NullValueHandling = NullValueHandling.Ignore)]
        public Item Item { get; set; }

        [JsonProperty("PriceType", NullValueHandling = NullValueHandling.Ignore)]
        public long? PriceType { get; set; }

        [JsonProperty("PeriodType", NullValueHandling = NullValueHandling.Ignore)]
        public long? PeriodType { get; set; }

        [JsonProperty("Period", NullValueHandling = NullValueHandling.Ignore)]
        public long? Period { get; set; }

        [JsonProperty("Color", NullValueHandling = NullValueHandling.Ignore)]
        public long? Color { get; set; }

        [JsonProperty("Effect", NullValueHandling = NullValueHandling.Ignore)]
        public long? Effect { get; set; }

        [JsonProperty("PurchaseTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseTimestamp { get; set; }

        [JsonProperty("Durability", NullValueHandling = NullValueHandling.Ignore)]
        public long? Durability { get; set; }

        [JsonProperty("Count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }
    }

    public partial class Room
    {
        public static Room FromJson(string json) => JsonConvert.DeserializeObject<Room>(json, PentaSphere.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Room self) => JsonConvert.SerializeObject(self, PentaSphere.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
