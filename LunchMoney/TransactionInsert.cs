using Newtonsoft.Json;

namespace LunchMoneyLoader.LunchMoney;

public class TransactionInsert
{
    [JsonProperty("transactions")]
    public Transaction[] Transactions { get; set; } = null!;
        
    [JsonProperty("apply_rules")]
    public bool ApplyRules { get; set; }
        
    [JsonProperty("check_for_recurring")]
    public bool CheckForRecurring { get; set; }
        
    [JsonProperty("debit_as_negative")]
    public bool DebitAsNegative { get; set; }
}