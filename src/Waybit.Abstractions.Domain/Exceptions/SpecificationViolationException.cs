﻿using System;

namespace Waybit.Abstractions.Domain.Exceptions
{
	/// <summary>
	/// Represents errors that occur if specification has errors.
	/// </summary>
	public class SpecificationViolationException : Exception
	{
		/// <summary>
		/// Initialize instance of <see cref="SpecificationViolationException"/>.
		/// </summary>
		/// <param name="message">Error message.</param>
		public SpecificationViolationException(string message)
			: base(message)
		{
		}
	}
}