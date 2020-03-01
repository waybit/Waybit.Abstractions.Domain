using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace Waybit.Abstractions.Domain
{
	/// <summary>
	/// Base entity.
	/// </summary>
	/// <typeparam name="TKey">Type of entity identity.</typeparam>
	public abstract class Entity<TKey> : IEntity
		where TKey : IEquatable<TKey>
	{
		private readonly IList<INotification> _domainEvents;

		/// <summary>
		/// Gets entity identity.
		/// </summary>
		public TKey Id { get; private set; }

		/// <summary>
		/// Gets domain events.
		/// </summary>
		public IEnumerable<INotification> DomainEvents
			=> _domainEvents;
		
		/// <summary>
		/// Initialize instance of a <see cref="Entity{TKey}"/>
		/// </summary>
		protected Entity(TKey id)
		{
			Id = id;
			_domainEvents = new List<INotification>();
		}

		/// <summary>
		/// Add domain event.
		/// </summary>
		/// <param name="domainEvent"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public void AddDomainEvent(INotification domainEvent)
		{
			if (domainEvent == null)
			{
				throw new ArgumentNullException(nameof(domainEvent));
			}

			_domainEvents.Add(domainEvent);
		}

		/// <inheritdoc />
		public void ClearDomainEvents()
		{
			_domainEvents.Clear();
		}

		/// <summary>
		/// Is equals value objects.
		/// </summary>
		/// <param name="other"><see cref="Entity{TKey}"/></param>
		protected bool Equals(Entity<TKey> other)
		{
			return EqualityComparer<TKey>.Default.Equals(Id, other.Id);
		}
		
		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}

			return this.Equals((Entity<TKey>)obj);
		}

		/// <inheritdoc />
		[SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
		public override int GetHashCode()
		{
			return EqualityComparer<TKey>.Default.GetHashCode(Id);
		}

		/// <summary>
		/// Equals override.
		/// </summary>
		/// <param name="left"><see cref="Entity{TKey}"/></param>
		/// <param name="right"><see cref="Entity{TKey}"/></param>
		/// <returns></returns>
		public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Not equals override.
		/// </summary>
		/// <param name="left"><see cref="Entity{TKey}"/></param>
		/// <param name="right"><see cref="Entity{TKey}"/></param>
		public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
		{
			return !Equals(left, right);
		}
	}
}
