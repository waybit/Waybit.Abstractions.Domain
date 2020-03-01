using System.Collections.Generic;
using MediatR;

namespace Waybit.Abstractions.Domain
{
	/// <summary>
	/// Entity.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		/// Gets domain events.
		/// </summary>
		IEnumerable<INotification> DomainEvents { get; }

		/// <summary>
		/// Add domain event in entity.
		/// </summary>
		/// <param name="domainEvent">Domain event.</param>
		void AddDomainEvent(INotification domainEvent);

		/// <summary>
		/// Clear all domain events.
		/// </summary>
		void ClearDomainEvents();
	}
}