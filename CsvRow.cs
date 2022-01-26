namespace LunchMoneyLoader;

public record CsvRow
{
    public string? BsbNumber { get; init; }
    public string? AccountNumber { get; init; }
    public DateOnly Date { get; init; }
    public string? Narration { get; init; }
    public string? Cheque { get; init; }
    public decimal? Debit { get; init; }
    public decimal? Credit { get; init; }
    public decimal? Balance { get; init; }
    public string? TransactionType { get; init; }

    public static CsvRow FromFields(string[] fields, string dateFormat)
    {
        return new CsvRow
        {
            BsbNumber = fields[0].Trim('"'),
            AccountNumber = fields[1].Trim('"'),
            Date = DateOnly.ParseExact(fields[2], dateFormat),
            Narration = fields[3].Trim('"'),
            Cheque = fields[4].Trim('"'),
            Debit = decimal.TryParse(fields[5], out var debit) ? debit : null,
            Credit = decimal.TryParse(fields[6], out var credit) ? credit : null,
            Balance = decimal.TryParse(fields[7], out var balance) ? balance : null,
            TransactionType = fields[8].Trim('"')
        };
    }
}