﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System.Text.Json.Serialization;

namespace VMelnalksnis.NordigenDotNet.Agreements;

/// <summary>Details needed to accept an end-user agreement.</summary>
public record EndUserAgreementAcceptance(string UserAgent, string IpAddress)
{
	/// <summary>Gets user agent string for the end user.</summary>
	[JsonPropertyName("user_agent")]
	public string UserAgent { get; } = UserAgent;

	/// <summary>Gets end user IP address.</summary>
	[JsonPropertyName("ip_address")]
	public string IpAddress { get; } = IpAddress;
}
