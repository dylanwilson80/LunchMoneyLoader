using LunchMoneyLoader;
using LunchMoneyLoader.LunchMoney;
using LunchMoneyLoader.Rules;

const string filePath = @"C:\GoogleDrive\Dylan\Bankwest\306-453 0284819_transaction_27_01_2022.csv";
var accessToken = args.FirstOrDefault() ?? Environment.GetEnvironmentVariable("LUNCH_MONEY_ACCESS_TOKEN");

if (string.IsNullOrEmpty(accessToken))
{
    Console.WriteLine("usage: lunch <access_token>");
    Console.WriteLine();
    Console.WriteLine("(or add LUNCH_MONEY_ACCESS_TOKEN as an environment variable)");
    return;
}

var ruleSet = new RuleSet()
{
    Rules =
    {
        new("GitHubSponsors", "GitHub Sponsors"),
        new("Pocket Money"),
        new("PayPal"),
        
        new("NARANGBA VALLEY TA", "Grog"),
        new("BWS", "Grog"),
        new("L/LAND", "Grog"),
        new("1ST CHOICE", "Grog"),

        new("Electrician"),
        new("Laundry"),
        
        new("REBEL NORTHLAKES", "Gym"),
        new("OVERDRIVE", "Gym"),
        
        new("GOOGLE*DOMAINS", "Domains"),
        
        new("WOOLWORTHS", "Groceries"),
        new("COLES", "Groceries"),
        new("IGA", "Groceries"),

        new("Amazon"),

        new("Lunch Money"),

        new("Lucas"),

        new("Google"),
        
        new("BP EXPRESS", "Servo"),

        new("Binance", "Crypto"),
        new("Kraken", "Crypto"),
        new("BAU withdrawal", "Crypto"),

        new("ATM"),
        new("Patio"),
        new("TRANSACTION FEE", "Transaction Fees"),
        
        new("KFC", "Junk Food"),
        new("MCDONALDS", "Junk Food"),
        new("BRUMBIES", "Junk Food"),
        
        new("Loan", "Loans"),
        new("Lend", "Loans"),
        
        new("COFFEE", "Coffee")
    }
};

using var reader = new StreamReader(filePath);

var header = await reader.ReadLineAsync();
Console.WriteLine(header);

var total = 0;
var categorized = 0;
var categories = new HashSet<string>();

while (!reader.EndOfStream)
{
    var line = await reader.ReadLineAsync();
    var fields = line!.Split(',');
    var row = CsvRow.FromFields(fields, "dd/MM/yyyy");

    var rule = ruleSet.Evaluate(row.Narration!);

    if (rule != null)
    {
        //Console.WriteLine($"{row.Narration} => {rule.Category}");
        categories.Add(rule.Category);
        categorized++;
    }
    else
    {
        Console.WriteLine(row.Narration);
    }

    total++;
}

Console.WriteLine($"{categorized} / {total}");

foreach (var category in categories)
{
    Console.WriteLine(category);
}

//using var api = new LunchMoneyApi(accessToken);

//var categories = await api.GetCategories();

//foreach (var category in categories)
//{
//    Console.WriteLine(category.Name);
//}