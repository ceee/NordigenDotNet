﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System;
using System.Text.Json.Serialization;

using NodaTime;

using VMelnalksnis.NordigenDotNet.Institutions;

namespace VMelnalksnis.NordigenDotNet.Accounts;

/// <summary>Information about the account record, such as the processing status and IBAN.</summary>
public record Account
{
	/// <summary>Gets or sets the id of this Account, used to refer to this account in other API calls.</summary>
	public Guid Id { get; set; }

	/// <summary>Gets or sets the point in time when the account object was created.</summary>
	public DateTimeOffset Created { get; set; }

	/// <summary>Gets or sets the point in time when the account object was last accessed.</summary>
	[JsonPropertyName("last_accessed")]
	public DateTimeOffset LastAccessed { get; set; }

	/// <summary>
	/// Gets or sets the name of the legal account owner.
	/// If there is more than one owner, then e.g. two names might be noted here.
	/// For a corporate account, the corporate name is used for this attribute.</summary>
	public string? OwnerName { get; set; }

	/// <summary>Gets or sets the account IBAN.</summary>
	public string Iban { get; set; } = null!;

	/// <summary>Gets or sets the id of the <see cref="Institution"/> associated with the account.</summary>
	[JsonPropertyName("institution_id")]
	public string InstitutionId { get; set; } = null!;

	/// <summary>Gets or sets the processing status of this account.</summary>
	public AccountStatus Status { get; set; }
}
