﻿using Microsoft.JSInterop;

namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// This interface represents a processing node which positions / spatializes an incoming audio stream in three-dimensional space.
/// The spatialization is in relation to the <see cref="BaseAudioContext"/>'s <see cref="AudioListener"/> (listener attribute).
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#PannerNode">See the API definition here</see>.</remarks>
public class PannerNode : AudioNode
{
	/// <summary>
	/// Constructs a wrapper instance for a given JS Instance of a <see cref="PannerNode"/>.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="jSReference">A JS reference to an existing <see cref="PannerNode"/>.</param>
	/// <returns>A wrapper instance for a <see cref="PannerNode"/>.</returns>
	public static new Task<PannerNode> CreateAsync(IJSRuntime jSRuntime, IJSObjectReference jSReference)
	{
		return Task.FromResult(new PannerNode(jSRuntime, jSReference));
	}

	/// <summary>
	/// Constructs a wrapper instance for a given JS Instance of a <see cref="PannerNode"/>.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="jSReference">A JS reference to an existing <see cref="PannerNode"/>.</param>
	protected PannerNode(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference)
	{
	}
}
