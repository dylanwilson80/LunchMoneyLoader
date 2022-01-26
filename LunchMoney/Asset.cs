using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public class Asset
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("type_name")]
    public string TypeName { get; set; } = null!;

    [JsonProperty("subtype_name")]
    public string SubtypeName { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("balance")]
    public decimal Balance { get; set; }

    [JsonProperty("balance_as_of")]
    public DateTimeOffset BalanceAsOf { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = null!;

    [JsonProperty("status")]
    public string Status { get; set; } = null!;

    [JsonProperty("institution_name")]
    public string InstitutionName { get; set; } = null!;

    [JsonProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}