// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System;

using NodaTime;

namespace VMelnalksnis.NordigenDotNet.Tokens;

/// <summary>Caches refresh and access tokens for <see cref="INordigenClient"/>.</summary>
public class NordigenTokenCache
{
	private readonly NordigenOptions _nordigenOptions;

	/// <summary>Initializes a new instance of the <see cref="NordigenTokenCache"/> class.</summary>
	/// <param name="nordigenOptions">Options for connection to the Nordigen API.</param>
	public NordigenTokenCache(NordigenOptions nordigenOptions)
	{
		_nordigenOptions = nordigenOptions;
	}

	public AccessToken? AccessToken { get; private set; }

	public bool IsAccessExpired =>
		AccessToken is not null &&
		AccessExpiresAt is not null &&
		DateTimeOffset.Now > AccessExpiresAt;

	public Token? Token { get; private set; }

	public bool IsRefreshExpired =>
		Token is not null &&
		RefreshExpiresAt is not null &&
		DateTimeOffset.Now > RefreshExpiresAt;

	public DateTimeOffset? AccessExpiresAt { get; set; }

	public DateTimeOffset? RefreshExpiresAt { get; set; }

	public void SetToken(Token token)
	{
		Token = token;
		AccessToken = token;
		var now = DateTimeOffset.Now;
		var factor = _nordigenOptions.ExpirationFactor;
		AccessExpiresAt = now.AddSeconds(token.AccessExpires / factor);
		RefreshExpiresAt = now.AddSeconds(token.RefreshExpires / factor);
	}

	public void SetAccessToken(AccessToken accessToken)
	{
		AccessToken = accessToken;
		var now = DateTimeOffset.Now;
		var factor = _nordigenOptions.ExpirationFactor;
		AccessExpiresAt = now.AddSeconds(accessToken.AccessExpires / factor);
	}
}
