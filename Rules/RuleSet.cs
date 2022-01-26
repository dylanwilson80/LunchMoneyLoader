namespace LunchMoneyLoader.Rules;

public class RuleSet
{
    public List<Rule> Rules { get; } = new();

    public Rule? Evaluate(string value)
    {
        foreach (var rule in Rules)
        {
            if (rule.Evaluate(value))
                return rule;
        }

        return null;
    }
}