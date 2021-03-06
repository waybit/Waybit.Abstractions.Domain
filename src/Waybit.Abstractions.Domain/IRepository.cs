﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Waybit.Abstractions.Domain
{
	/// <summary>
	/// Repository.
	/// </summary>
	/// <typeparam name="TAggregateRoot">Aggregate root.</typeparam>
	/// <typeparam name="TKey">Type of identity aggregate root entity.</typeparam>
	public interface IRepository<TAggregateRoot, TKey>
		where TKey : IEquatable<TKey>
		where TAggregateRoot : Entity<TKey>, IAggregateRoot
	{
		/// <summary>
		/// Gets all aggregate roots.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token.</param>
		Task<IEnumerable<TAggregateRoot>> GetAllAsync(CancellationToken cancellationToken);

		/// <summary>
		/// Gets aggregate root by identity.
		/// </summary>
		/// <param name="id">Identity</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		Task<TAggregateRoot> GetByIdAsync(TKey id, CancellationToken cancellationToken);

		/// <summary>
		/// Add aggregate root and returns created identity.
		/// </summary>
		/// <param name="entity">Aggregate root.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		Task<TKey> AddAsync(TAggregateRoot entity, CancellationToken cancellationToken);

		/// <summary>
		/// Change aggregate root.
		/// </summary>
		/// <param name="entity">Aggregate root.</param>
		/// <param name="cancellationToken">Cancellation token.</param>
		Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken);
	}
}
