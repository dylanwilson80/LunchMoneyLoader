using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public class AssetsResponse
{
    [JsonProperty("assets")]
    public Asset[] Assets { get; set; } = null!;
}