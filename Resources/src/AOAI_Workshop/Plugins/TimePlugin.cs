using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace AOAI_Workshop;

public class TimePlugin
{

    [KernelFunction("get_datetime")]
    [Description("")]
    [return: Description("")]
    public async Task<string> GetDateTimeNow()
    {
        DateTime currentDateTime = DateTime.Now;
        return currentDateTime.ToString();
    }

    [KernelFunction("get_year")]
    [Description("")]
    [return: Description("")]
    public async Task<string> GetYear(string date)
    {
        DateTime currentDateTime = DateTime.Parse(date); ;
        string year = currentDateTime.Year.ToString();
        return year;
    }

    [KernelFunction("get_month")]
    [Description("")]
    [return: Description("")]
    public async Task<string> GetMonth(string date)
    {
        DateTime currentDateTime = DateTime.Parse(date); ;
        string month = currentDateTime.Month.ToString();
        return month;
    }

    [KernelFunction("get_dayofweek")]
    [Description("")]
    [return: Description("")]
    public async Task<string> GetDayofWeek(string date)
    {
        DateTime currentDateTime = DateTime.Parse(date); ;
        string dayOfWeek = currentDateTime.DayOfWeek.ToString();
        return dayOfWeek;
    }
}