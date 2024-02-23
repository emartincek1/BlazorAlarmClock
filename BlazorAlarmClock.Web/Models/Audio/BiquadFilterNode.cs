﻿
using KristofferStrube.Blazor.WebIDL;
using Microsoft.JSInterop;

namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// <see cref="BiquadFilterNode"/> is an <see cref="AudioNode"/> processor implementing very common low-order filters.<br />
/// Low-order filters are the building blocks of basic tone controls (bass, mid, treble), graphic equalizers, and more advanced filters.
/// Multiple <see cref="BiquadFilterNode"/> filters can be combined to form more complex filters.
/// The filter parameters such as <see cref="GetFrequencyAsync"/> can be changed over time for filter sweeps, etc.
/// Each <see cref="BiquadFilterNode"/> can be configured as one of a number of common filter types.
/// The default filter type is <see cref="BiquadFilterType.Lowpass"/>.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#BiquadFilterNode">See the API definition here</see>.</remarks>
public class BiquadFilterNode : AudioNode
{
	/// <summary>
	/// Constructs a wrapper instance for a given JS Instance of an <see cref="BiquadFilterNode"/>.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="jSReference">A JS reference to an existing <see cref="BiquadFilterNode"/>.</param>
	/// <returns>A wrapper instance for an <see cref="BiquadFilterNode"/>.</returns>
	public static new Task<BiquadFilterNode> CreateAsync(IJSRuntime jSRuntime, IJSObjectReference jSReference)
	{
		return Task.FromResult(new BiquadFilterNode(jSRuntime, jSReference));
	}

	/// <summary>
	/// Creates an <see cref="BiquadFilterNode"/> using the standard constructor.
	/// </summary>
	/// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
	/// <param name="context">The <see cref="BaseAudioContext"/> this new <see cref="BiquadFilterNode"/> will be associated with.</param>
	/// <param name="options">Optional initial parameter value for this <see cref="BiquadFilterNode"/>.</param>
	/// <returns>A new instance of an <see cref="BiquadFilterNode"/>.</returns>
	public static async Task<BiquadFilterNode> CreateAsync(IJSRuntime jSRuntime, BaseAudioContext context, BiquadFilterOptions? options = null)
	{
		IJSObjectReference helper = await jSRuntime.GetHelperAsync();
		IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("constructBiquadFilterNode", context.JSReference, options);
		return new BiquadFilterNode(jSRuntime, jSInstance);
	}

	private BiquadFilterNode(IJSRuntime jSRuntime, IJSObjectReference jSReference) : base(jSRuntime, jSReference)
	{
	}

	/// <summary>
	/// Gets the type of this <see cref="BiquadFilterNode"/>.
	/// Its default value is <see cref="BiquadFilterType.Lowpass"/>.
	/// The exact meaning of the other parameters depend on the value of the this attribute.
	/// </summary>
	public async Task<BiquadFilterType> GetTypeAsync()
	{
		IJSObjectReference helper = await webAudioHelperTask.Value;
		return await helper.InvokeAsync<BiquadFilterType>("getAttribute", JSReference, "type");
	}
	/// <summary>
	/// Sets the type of this <see cref="BiquadFilterNode"/>.
	/// Its default value is <see cref="BiquadFilterType.Lowpass"/>.
	/// The exact meaning of the other parameters depend on the value of the this attribute.
	/// </summary>
	public async Task SetTypeAsync(BiquadFilterType value)
	{
		IJSObjectReference helper = await webAudioHelperTask.Value;
		await helper.InvokeVoidAsync("setAttribute", JSReference, "type", value);
	}

	/// <summary>
	/// The frequency at which the <see cref="BiquadFilterNode"/> will operate, in Hz.
	/// It forms a compound parameter with <see cref="GetDetuneAsync"/> to form the computedFrequency.
	/// </summary>
	/// <returns>An <see cref="AudioParam"/></returns>
	public async Task<AudioParam> GetFrequencyAsync()
	{
		IJSObjectReference helper = await webAudioHelperTask.Value;
		IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("getAttribute", JSReference, "frequency");
		return await AudioParam.CreateAsync(JSRuntime, jSInstance);
	}

	/// <summary>
	/// A detune value, in cents, for the frequency.
	/// It forms a compound parameter with <see cref="GetFrequencyAsync"/> to form the computedFrequency.
	/// </summary>
	/// <returns>An <see cref="AudioParam"/></returns>
	public async Task<AudioParam> GetDetuneAsync()
	{
		IJSObjectReference helper = await webAudioHelperTask.Value;
		IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("getAttribute", JSReference, "detune");
		return await AudioParam.CreateAsync(JSRuntime, jSInstance);
	}

	/// <summary>
	/// The Q factor of the filter.
	/// </summary>
	/// <returns>An <see cref="AudioParam"/></returns>
	public async Task<AudioParam> GetQAsync()
	{
		IJSObjectReference helper = await webAudioHelperTask.Value;
		IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("getAttribute", JSReference, "Q");
		return await AudioParam.CreateAsync(JSRuntime, jSInstance);
	}

	/// <summary>
	/// The gain of the filter. Its value is in dB units. The gain is only used for <see cref="BiquadFilterType.Lowshelf"/>, <see cref="BiquadFilterType.Highshelf"/>, and <see cref="BiquadFilterType.Peaking"/> filters.
	/// </summary>
	/// <returns>An <see cref="AudioParam"/></returns>
	public async Task<AudioParam> GetGainAsync()
	{
		IJSObjectReference helper = await webAudioHelperTask.Value;
		IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("getAttribute", JSReference, "gain");
		return await AudioParam.CreateAsync(JSRuntime, jSInstance);
	}

	/// <summary>
	/// Given the value of each of the filter parameters, synchronously calculates the frequency response for the specified frequencies.
	/// </summary>
	/// <remarks>
	/// It throws an <see cref="InvalidAccessErrorException"/> if the <see cref="Float32Array"/> parameters are not the same length.<br />
	///  If a value in <paramref name="frequencyHz"/> is not within <c>[0, sampleRate/2]</c>, where <c>sampleRate</c> is the same as <see cref="BaseAudioContext.GetSampleRateAsync"/>, the corresponding value at the same index of the <paramref name="magResponse"/> and <paramref name="phaseResponse"/> arrays will be <c>NaN</c>.
	/// </remarks>
	/// <param name="frequencyHz">This parameter specifies an array of frequencies, in Hz, at which the response values will be calculated.</param>
	/// <param name="magResponse">This parameter specifies an output array receiving the linear magnitude response values.</param>
	/// <param name="phaseResponse">This parameter specifies an output array receiving the phase response values in radians.</param>
	/// <returns></returns>
	public async Task GetFrequencyResponseAsync(Float32Array frequencyHz, Float32Array magResponse, Float32Array phaseResponse)
	{
		await JSReference.InvokeVoidAsync("getFrequencyResponse", frequencyHz.JSReference, magResponse.JSReference, phaseResponse.JSReference);
	}
}
