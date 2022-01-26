using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public class Transaction
{
    [JsonProperty("date")]
    [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
    public DateTime Date { get; set; }
        
    [JsonProperty("amount")]
    public decimal Amount { get; set; }
        
    [JsonProperty("category_id")]
    public int CategoryId { get; set; }
        
    [JsonProperty("payee")]
    public string Payee { get; set; } = null!;
        
    [JsonProperty("currency")]
    public string Currency { get; set; } = null!;

    [JsonProperty("asset_id")]
    public int AssetId { get; set; }
        
    //[JsonProperty("recurring_id")]
    //public int? RecurringId { get; set; }

    [JsonProperty("notes")] 
    public string Notes { get; set; } = "";

    [JsonProperty("status")] 
    public string Status { get; set; } = TransactionStatus.Uncleared;

    [JsonProperty("external_id")]
    public string ExternalId { get; set; } = null!;

    [JsonProperty("tags")] 
    public string[] Tags { get; set; } = Array.Empty<string>();
}