﻿using System;

namespace Waybit.Abstractions.Domain.Exceptions
{
	/// <summary>
	/// Represents errors that occur if entity not found.
	/// </summary>
	public class EntityNotFoundException : Exception
	{
		/// <summary>
		/// Entity name.
		/// </summary>
		public string EntityName { get; }

		/// <summary>
		/// Initialize instance of <see cref="EntityNotFoundException" />.
		/// </summary>
		public EntityNotFoundException(string entityName, string message)
			: base(message)
		{
			EntityName = entityName;
		}
	}
}