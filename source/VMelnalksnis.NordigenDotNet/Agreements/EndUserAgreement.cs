﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using NodaTime;

using VMelnalksnis.NordigenDotNet.Institutions;

namespace VMelnalksnis.NordigenDotNet.Agreements;

/// <summary>Details the end-user has agreement to share from a specific institution.</summary>
public record EndUserAgreement
{
	/// <summary>Gets or sets the id of the end-user agreement.</summary>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the point in time when the agreement was created.</summary>
	public DateTimeOffset Created { get; set; }

	/// <summary>Gets or sets maximum number of days of transaction data to retrieve.</summary>
	[JsonPropertyName("max_historical_days")]
	public int MaxHistoricalDays { get; set; }

	/// <summary>Gets or sets number of days from acceptance that the access can be used.</summary>
	[JsonPropertyName("access_valid_for_days")]
	public int AccessValidForDays { get; set; }

	/// <summary>Gets or sets level of information to access.</summary>
	[JsonPropertyName("access_scope")]
	public List<string> AccessScope { get; set; } = null!;

	/// <summary>Gets or sets an <see cref="Institution"/> ID for the agreement.</summary>
	[JsonPropertyName("institution_id")]
	public string InstitutionId { get; set; } = null!;

	/// <summary>Gets or sets the point in time when the end user accepted the agreement.</summary>
	public DateTimeOffset? Accepted { get; set; }
}
