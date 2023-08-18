using System.Text.Json.Serialization;
using backend.Models.Api.DTOs;

namespace backend.Models.Api.Responses;

/// <summary>
/// Weather calendar
/// </summary>
public class WeatherCalendarResponse
{
    [JsonPropertyName("calendarItems")]
    public IReadOnlyCollection<WeatherCalendarItem> CalendarItems { get; private set; }

    public WeatherCalendarResponse
    (
        IReadOnlyCollection<WeatherCalendarItem> calendarItems
    )
    {
        CalendarItems = calendarItems
                        ?? throw new ArgumentNullException(nameof(calendarItems), "Calendar items must be populated!");

        if (!CalendarItems.Any())
        {
            throw new ArgumentException("Calendar must not be empty!");
        }
    }
}