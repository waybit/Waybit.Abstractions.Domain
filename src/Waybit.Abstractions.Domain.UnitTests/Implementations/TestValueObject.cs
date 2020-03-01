namespace Waybit.Abstractions.Domain.UnitTests.Implementations
{
	public class TestValueObject : ValueObject
	{
		/// <inheritdoc />
		public TestValueObject(string city, string street)
		{
			City = city;
			Street = street;
		}

		public string City { get; private set; }

		public string Street { get; private set; }
		
		/// <inheritdoc />
		protected override bool Equals(ValueObject other)
		{
			if (!(other is TestValueObject testValueObject))
			{
				return false;
			}

			return this.City == testValueObject.City &&
				this.Street == testValueObject.Street;
		}

		/// <inheritdoc />
		protected override int GetValueObjectHashCode()
		{
			unchecked
			{
				int hashCode = City?.GetHashCode() ?? 0;
				return (hashCode * 396) ^ Street?.GetHashCode() ?? 0;
			}
		}
	}
}