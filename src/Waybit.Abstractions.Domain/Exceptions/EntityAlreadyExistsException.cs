using System;

namespace Waybit.Abstractions.Domain.Exceptions
{
	/// <summary>
	/// Represents errors that occur if entity already exists.
	/// </summary>
	public class EntityAlreadyExistsException : Exception
	{
		/// <summary>
		/// Entity name.
		/// </summary>
		public string EntityName { get; }

		/// <summary>
		/// Initialize instance of <see cref="EntityNotFoundException" />.
		/// </summary>
		public EntityAlreadyExistsException(string entityName, string message)
			: base(message)
		{
			EntityName = entityName;
		}
	}
}