using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoremIpsumLogistica.API.Converters;

public class DateTimeConverter 
{
    //private const string DateFormat = "yyyy-MM-dd";
    private const string DateFormat = "dd-MM-yyyy";

    public DateTime ParseDate(string dateString)
    {
        return DateTime.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
    }

    public string FormatDate(DateTime dateTime)
    {
        return dateTime.ToString(DateFormat);
    }
}
