using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public class Category
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("is_income")]
    public bool IsIncome { get; set; }

    [JsonProperty("exclude_from_budget")]
    public bool ExcludeFromBudget { get; set; }
        
    [JsonProperty("exclude_from_totals")]
    public bool ExcludeFromTotals { get; set; }
        
    [JsonProperty("updated_at")]
    public DateTimeOffset UpdatedAt { get; set; }

    [JsonProperty("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
        
    [JsonProperty("is_group")]
    public bool IsGroup { get; set; }
        
    [JsonProperty("group_id")]
    public int? GroupId { get; set; }
}
