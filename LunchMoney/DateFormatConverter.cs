using Newtonsoft.Json.Converters;

namespace LunchMoneyLoader.LunchMoney;

public class DateFormatConverter : IsoDateTimeConverter
{
    public DateFormatConverter(string format)
    {
        DateTimeFormat = format;
    }
}