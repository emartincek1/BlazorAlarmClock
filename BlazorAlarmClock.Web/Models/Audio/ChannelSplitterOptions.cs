﻿
using System.Text.Json.Serialization;

namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// This specifies the options to use in constructing a <see cref="ChannelSplitterNode"/>.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#ChannelSplitterOptions">See the API definition here</see>.</remarks>
public class ChannelSplitterOptions : AudioNodeOptions
{
	/// <summary>
	/// The number inputs for the <see cref="ChannelSplitterNode"/>.
	/// </summary>
	/// <remarks>
	/// It throws an <see cref="IndexSizeErrorException"/> if it is less than <c>1</c> or larger than the supported number of channels when used for constructing a <see cref="ChannelSplitterNode"/>.
	/// </remarks>
	[JsonPropertyName("numberOfInputs")]
	public ulong NumberOfInputs { get; set; } = 6;
}
