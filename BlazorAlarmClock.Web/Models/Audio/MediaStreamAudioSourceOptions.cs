﻿
using System.Text.Json.Serialization;
using KristofferStrube.Blazor.MediaCaptureStreams;


namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// This specifies the options to use in constructing an <see cref="MediaStreamAudioSourceNode"/>.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#MediaStreamAudioSourceOptions">See the API definition here</see>.</remarks>
public class MediaStreamAudioSourceOptions
{
	/// <summary>
	/// The media stream that will act as a source.
	/// </summary>
	[JsonPropertyName("mediaStream")]
	public required MediaStream MediaStream { get; set; }
}