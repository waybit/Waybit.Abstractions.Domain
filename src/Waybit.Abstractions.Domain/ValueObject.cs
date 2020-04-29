﻿using System;

namespace Waybit.Abstractions.Domain
{
	/// <summary>
	/// Value object
	/// </summary>
	public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>, IValueObject
	{
		/// <inheritdoc />
		public abstract bool Equals(TValueObject other);

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

			if (!(obj is TValueObject valueObject))
			{
				return false;
			}
			
			return this.Equals(valueObject);
		}

		/// <inheritdoc />
		public abstract override int GetHashCode();

		/// <summary>
		/// Comparable operator ==
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Comparable operator !=
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
		{
			return !Equals(left, right);
		}

		/// <inheritdoc />
		public abstract override string ToString();
	}
}
