// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System;
using System.Text.Json.Serialization;

using NodaTime;

namespace VMelnalksnis.NordigenDotNet.Accounts;

/// <summary>Common information for all transactions.</summary>
public record Transaction
{
	/// <summary>Gets or sets the amount transferred in this transaction.</summary>
	public AmountInCurrency TransactionAmount { get; set; } = null!;

	/// <summary>Gets or sets unstructured information about the transaction, usually added by the debtor.</summary>
	[JsonPropertyName("remittanceInformationUnstructured")]
	public string UnstructuredInformation { get; set; } = null!;

	/// <summary>Gets or sets the date when the transaction was valued at.</summary>
	public DateTimeOffset? ValueDate { get; set; }
	
	/// <summary>Gets or sets a unique transaction id created by the <see cref="Institution"/>.</summary>
	public string TransactionId { get; set; } = null!;
	
	/// <summary>Gets or sets a unique transaction id created by Nordigen.</summary>
	public string InternalTransactionId { get; set; } = null!;

	/// <summary>Gets or sets the date when an entry is posted to an account on the account servicer's books.</summary>
	public DateTimeOffset? BookingDate { get; set; }

	/// <summary>Gets or sets the name of the counterparty that sends <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public string? DebtorName { get; set; }

	/// <summary>Gets or sets the account of the counterparty that sends <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public TransactionAccount? DebtorAccount { get; set; }

	/// <summary>Gets or sets the name of the counterparty that receives <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public string? CreditorName { get; set; }

	/// <summary>Gets or sets the account of the counterparty that receives <see cref="Transaction.TransactionAmount"/> during the transaction.</summary>
	public TransactionAccount? CreditorAccount { get; set; }

	/// <summary>Gets or sets the ISO 20022 bank transaction code.</summary>
	/// <example>Some example values:
	/// <code>
	/// PMNT-ICDT-STDO
	/// PMNT-IRCT-STDO
	/// </code></example>
	public string? BankTransactionCode { get; set; }

	/// <summary>Gets or sets a transaction id, used both by the transaction and any fees paid to the <see cref="Institution"/> for the transaction.</summary>
	public string? EntryReference { get; set; }

	/// <summary>Gets or sets additional structured information about the transaction from the institution.</summary>
	/// <example>
	/// <code>
	/// PURCHASE
	/// INWARD TRANSFER
	/// </code></example>
	public string? AdditionalInformation { get; set; }
}


public record PendingTransaction : Transaction
{
}
