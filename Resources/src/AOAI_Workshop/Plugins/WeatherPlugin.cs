using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace AOAI_Workshop;

public class WeatherPlugin
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherPlugin(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [KernelFunction("get_forecast")]
    [Description("Get the weather forecast for up to 16 days")]
    [return: Description("")]
    public async Task<string> GetForecastAsync(string latitude, string longitude, string days)
    {
        using HttpClient httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetStringAsync(
              $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation,rain,showers,snowfall,weather_code,wind_speed_10m,wind_direction_10m,wind_gusts_10m&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,precipitation,rain,showers,snowfall,weather_code,cloud_cover,wind_speed_10m,uv_index&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&forecast_days={days}");
        return response;
    }

    [KernelFunction("get_pastforecast")]
    [Description("Get the past weather forecast")]
    [return: Description("")]
    public async Task<string> GetPastForecastAsync(string latitude, string longitude, string daysInPast)
    {
        using HttpClient httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetStringAsync(
                $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&daily=weather_code,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,daylight_duration,uv_index_max,precipitation_sum,rain_sum,showers_sum,snowfall_sum,precipitation_hours,wind_speed_10m_max,wind_gusts_10m_max&temperature_unit=fahrenheit&wind_speed_unit=mph&precipitation_unit=inch&past_days={daysInPast}");
        return response;
    }
}