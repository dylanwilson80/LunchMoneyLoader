namespace LunchMoneyLoader.Rules;

public class Rule
{
    public Rule(string containsCategory)
    {
        Text = containsCategory;
        Category = containsCategory;
    }

    public Rule(string containsText, string category)
    {
        Text = containsText;
        Category = category;
    }

    public string Text { get; }
    public string Category { get; }

    public bool Evaluate(string value)
    {
        return value.Contains(Text, StringComparison.InvariantCultureIgnoreCase);
    }
}
