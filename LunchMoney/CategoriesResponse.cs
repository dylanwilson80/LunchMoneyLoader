using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public class CategoriesResponse
{
    [JsonProperty("categories")]
    public Category[] Categories { get; set; } = null!;
}