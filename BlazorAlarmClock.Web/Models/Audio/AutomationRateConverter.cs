using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorAlarmClock.Web.Models.Audio;

internal class AutomationRateConverter : JsonConverter<AutomationRate>
{
	public override AutomationRate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}

	public override void Write(Utf8JsonWriter writer, AutomationRate value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value switch
		{
			AutomationRate.ARate => "a-rate",
			AutomationRate.KRate => "k-rate",
			_ => throw new ArgumentException($"Value '{value}' was not a valid {nameof(AutomationRate)}.")
		});
	}
}
