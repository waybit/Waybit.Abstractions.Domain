using System;

namespace Waybit.Abstractions.Domain.UnitTests.Implementations
{
	public class TestValueObject : ValueObject<TestValueObject>
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
		public override bool Equals(TestValueObject other)
		{
			return City == other.City && Street == other.Street;
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return HashCode.Combine(City, Street);
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"{City}, {Street}";
		}
	}
}
