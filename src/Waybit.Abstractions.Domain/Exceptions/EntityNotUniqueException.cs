﻿using System;

namespace Waybit.Abstractions.Domain.Exceptions
{
	/// <summary>
	/// Represents errors that occur if entity not unique.
	/// </summary>
	public class EntityNotUniqueException : Exception
	{
		/// <summary>
		/// Entity name.
		/// </summary>
		public object EntityName { get; }

		/// <summary>
		/// Initialize instance of <see cref="EntityNotUniqueException" />.
		/// </summary>
		public EntityNotUniqueException(object entityName, string message, Exception innerException)
			: base(message, innerException)
		{
			EntityName = entityName;
		}
	}
}