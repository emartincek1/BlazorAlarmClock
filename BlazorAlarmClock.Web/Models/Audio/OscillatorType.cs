﻿using System.Text.Json.Serialization;

namespace BlazorAlarmClock.Web.Models.Audio;

/// <summary>
/// Changing the gain of an audio signal is a fundamental operation in audio applications. This interface is an <see cref="AudioNode"/> with a single input and single output.
/// </summary>
/// <remarks><see href="https://www.w3.org/TR/webaudio/#enumdef-oscillatortype">See the API definition here</see>.</remarks>
[JsonConverter(typeof(OscillatorTypeConverter))]
public enum OscillatorType
{
    /// <summary>
    /// A sine wave.
    /// </summary>
    Sine,
    /// <summary>
    /// A square wave of duty period <c>0.5</c>.
    /// </summary>
    Square,
    /// <summary>
    ///	A sawtooth wave.
    /// </summary>
    Sawtooth,
    /// <summary>
    /// A triangle wave.
    /// </summary>
    Triangle,
    /// <summary>
    /// A custom periodic wave.
    /// </summary>
    Custom
}