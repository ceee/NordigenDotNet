﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System.Text.Json.Serialization;

namespace VMelnalksnis.NordigenDotNet.Accounts;

/// <summary>All possible states of an account.</summary>
public enum AccountUsage
{
	PRIV,
	ORGA
}
