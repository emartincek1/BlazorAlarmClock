using Microsoft.JSInterop;

namespace BlazorAlarmClock.Web.Models.Audio;

internal static class IJSRuntimeExtensions
{
	internal static async Task<IJSObjectReference> GetHelperAsync(this IJSRuntime jSRuntime)
	{
		return await jSRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./KristofferStrube.Blazor.WebAudio.js");
	}
	internal static async Task<IJSInProcessObjectReference> GetInProcessHelperAsync(this IJSRuntime jSRuntime)
	{
		return await jSRuntime.InvokeAsync<IJSInProcessObjectReference>(
			"import", "./KristofferStrube.Blazor.WebAudio.js");
	}
}
