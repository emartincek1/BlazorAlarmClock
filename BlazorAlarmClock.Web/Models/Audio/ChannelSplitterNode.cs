﻿
using Microsoft.JSInterop;

namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// The <see cref="ChannelSplitterNode"/> is for use in more advanced applications and would often be used in conjunction with <see cref="ChannelMergerNode"/>.<br />
/// This interface represents an <see cref="AudioNode"/> for accessing the individual channels of an audio stream in the routing graph.
/// It has a single input, and a number of <c>"active"</c> outputs which equals the number of channels in the input audio stream.
/// For example, if a stereo input is connected to an <see cref="ChannelSplitterNode"/> then the number of active outputs will be two (one from the left channel and one from the right).
/// There are always a total number of N outputs (determined by the numberOfOutputs parameter to the <see cref="AudioContext"/> method <see cref="BaseAudioContext.CreateChannelSplitterAsync(ulong)"/>),
/// The default number is 6 if this value is not provided.
/// Any outputs which are not <c>"active"</c> will output silence and would typically not be connected to anything.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#ChannelSplitterNode">See the API definition here</see>.</remarks>
public class ChannelSplitterNode : AudioNode
{
	/// <summary>
	/// Constructs a wrapper instance for a given JS Instance of an <see cref="ChannelSplitterNode"/>.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="jSReference">A JS reference to an existing <see cref="ChannelSplitterNode"/>.</param>
	/// <returns>A wrapper instance for an <see cref="ChannelSplitterNode"/>.</returns>
	public static new Task<ChannelSplitterNode> CreateAsync(IJSRuntime jSRuntime, IJSObjectReference jSReference)
	{
		return Task.FromResult(new ChannelSplitterNode(jSRuntime, jSReference));
	}

	/// <summary>
	/// Creates a <see cref="ChannelSplitterNode"/> using the standard constructor.
	/// </summary>
	/// <remarks>
	/// It throws an <see cref="IndexSizeErrorException"/> if <see cref="ChannelSplitterOptions.NumberOfInputs"/> is less than <c>1</c> or larger than the supported number of channels.
	/// </remarks>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="context">The <see cref="BaseAudioContext"/> this new <see cref="ChannelSplitterNode"/> will be associated with.</param>
	/// <param name="options">Optional initial parameter value for this <see cref="ChannelSplitterNode"/>.</param>
	/// <exception cref="IndexSizeErrorException"></exception>
	/// <returns>A new instance of a <see cref="ChannelSplitterNode"/>.</returns>
	public static async Task<ChannelSplitterNode> CreateAsync(IJSRuntime jSRuntime, BaseAudioContext context, ChannelSplitterOptions? options = null)
	{
		IJSObjectReference helper = await jSRuntime.GetHelperAsync();
		IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("constructChannelSplitterNode", context, options);
		return new ChannelSplitterNode(jSRuntime, jSInstance);
	}

	private ChannelSplitterNode(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference) { }
}
