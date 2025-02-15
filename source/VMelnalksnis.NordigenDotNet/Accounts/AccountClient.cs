﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using NodaTime;

using VMelnalksnis.NordigenDotNet.Serialization;

namespace VMelnalksnis.NordigenDotNet.Accounts;

/// <inheritdoc />
public sealed class AccountClient : IAccountClient
{
	private readonly HttpClient _httpClient;
	private readonly NordigenSerializationContext _context;

	/// <summary>Initializes a new instance of the <see cref="AccountClient"/> class.</summary>
	/// <param name="httpClient">Http client configured for making requests to the Nordigen API.</param>
	/// <param name="serializerOptions">Nordigen specific instance of <see cref="JsonSerializerOptions"/>.</param>
	public AccountClient(HttpClient httpClient, NordigenJsonSerializerOptions serializerOptions)
	{
		_httpClient = httpClient;
		_context = serializerOptions.Context;
	}

	/// <inheritdoc />
	public Task<Account> Get(Guid id, CancellationToken cancellationToken = default)
	{
		return _httpClient.GetFromJsonAsync(Routes.Accounts.IdUri(id), _context.Account, cancellationToken)!;
	}

	/// <inheritdoc />
	public async Task<List<Balance>> GetBalances(Guid id, CancellationToken cancellationToken = default)
	{
		var balances = await _httpClient
			.GetFromJsonAsync(Routes.Accounts.BalancesUri(id), _context.BalancesWrapper, cancellationToken)
			.ConfigureAwait(false);

		return balances!.Balances;
	}

	/// <inheritdoc />
	public async Task<AccountDetails> GetDetails(Guid id, CancellationToken cancellationToken = default)
	{
		var details = await _httpClient
			.GetFromJsonAsync(Routes.Accounts.DetailsUri(id), _context.AccountDetailsWrapper, cancellationToken)
			.ConfigureAwait(false);

		return details!.Account;
	}

	/// <inheritdoc />
	public async Task<Transactions> GetTransactions(
		Guid id,
		DateTimeOffset? dateFrom = null,
		DateTimeOffset? dateTo = null,
		CancellationToken cancellationToken = default)
	{
		var transactions = await _httpClient
			.GetFromJsonAsync(Routes.Accounts.TransactionsUri(id, dateFrom, dateTo), _context.TransactionsWrapper, cancellationToken)
			.ConfigureAwait(false);

		return transactions!.Transactions;
	}
}
