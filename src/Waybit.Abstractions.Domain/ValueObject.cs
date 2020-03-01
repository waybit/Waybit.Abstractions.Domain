﻿namespace Waybit.Abstractions.Domain
{
	/// <summary>
	/// Value object
	/// </summary>
	public abstract class ValueObject
	{
		/// <summary>
		/// Is equals value objects.
		/// </summary>
		/// <param name="other">Value object candidate.</param>
		protected abstract bool Equals(ValueObject other);

		/// <summary>
		/// Gets value object hash code for equality.
		/// </summary>
		protected abstract int GetValueObjectHashCode();

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

			return this.Equals((ValueObject)obj);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return this.GetValueObjectHashCode();
		}

		/// <summary>
		/// Equals override.
		/// </summary>
		/// <param name="left">Left value object.</param>
		/// <param name="right">Right value object.</param>
		public static bool operator ==(ValueObject left, ValueObject right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Not equals override.
		/// </summary>
		/// <param name="left">Left value object.</param>
		/// <param name="right">Right value object.</param>
		public static bool operator !=(ValueObject left, ValueObject right)
		{
			return !Equals(left, right);
		}

		/// <summary>
		/// Copy values for a new value object.
		/// </summary>
		public virtual ValueObject Copy()
		{
			return this.MemberwiseClone() as ValueObject;
		}
	}
}