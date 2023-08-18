using System.Text.Json.Serialization;

namespace backend.Models.Api.Responses;

public class CurrentDateResponse
{
    [JsonPropertyName("currentDate")]
    public DateOnly CurrentDate { get; private set; }

    public CurrentDateResponse(DateOnly currentDate)
    {
        CurrentDate = currentDate;
    }
}