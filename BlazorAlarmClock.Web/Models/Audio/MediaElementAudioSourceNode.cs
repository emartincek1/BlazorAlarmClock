﻿using Microsoft.JSInterop;

namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// This interface represents an audio source from an audio or video element.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#MediaElementAudioSourceNode">See the API definition here</see>.</remarks>
public class MediaElementAudioSourceNode : AudioNode
{
	/// <summary>
	/// Constructs a wrapper instance for a given JS Instance of a <see cref="MediaElementAudioSourceNode"/>.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="jSReference">A JS reference to an existing <see cref="MediaElementAudioSourceNode"/>.</param>
	/// <returns>A wrapper instance for a <see cref="MediaElementAudioSourceNode"/>.</returns>
	public static new Task<MediaElementAudioSourceNode> CreateAsync(IJSRuntime jSRuntime, IJSObjectReference jSReference)
	{
		return Task.FromResult(new MediaElementAudioSourceNode(jSRuntime, jSReference));
	}

	/// <summary>
	/// Constructs a wrapper instance for a given JS Instance of a <see cref="MediaElementAudioSourceNode"/>.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="jSReference">A JS reference to an existing <see cref="MediaElementAudioSourceNode"/>.</param>
	protected MediaElementAudioSourceNode(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference)
	{
	}
}
