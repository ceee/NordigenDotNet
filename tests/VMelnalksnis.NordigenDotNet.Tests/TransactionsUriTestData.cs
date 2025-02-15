﻿// Copyright 2022 Valters Melnalksnis
// Licensed under the Apache License 2.0.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using NodaTime;

namespace VMelnalksnis.NordigenDotNet.Tests;

internal sealed class TransactionsUriTestData : IEnumerable<object?[]>
{
	public IEnumerator<object?[]> GetEnumerator()
	{
		yield return new object?[] { Guid.NewGuid(), null, new NameValueCollection() };

		var dateFrom = new DateTimeOffset(2022, 05, 01, 12, 00, 00, TimeSpan.Zero);
		var dateTo = new DateTimeOffset(2022, 05, 12, 13, 00, 00, TimeSpan.Zero);
		var collection = new NameValueCollection
		{
			{ "date_from", "2022-05-01" },
			{ "date_to", "2022-05-12" },
		};

		yield return new object?[] { Guid.NewGuid(), dateFrom, dateTo, collection };
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
