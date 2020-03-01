using NUnit.Framework;
using Shouldly;
using Waybit.Abstractions.Domain.UnitTests.Implementations;

namespace Waybit.Abstractions.Domain.UnitTests
{
	public class ValueObjectTests
	{
		[Test]
		public void Can_create_value_object()
		{
			// Arrange
			const string city = "City";
			const string street = "Street";
			
			// Act
			var actual = new TestValueObject(city, street);
			
			// Assert
			actual.ShouldNotBeNull();
			actual.City.ShouldBe(city);
			actual.Street.ShouldBe(street);
		}

		[Test]
		public void Can_equals_value_objects()
		{
			// Arrange
			const string city = "City";
			const string street = "Street";
			var equality = new TestValueObject(city, street);
			
			// Act
			var actual = new TestValueObject(city, street);
			
			// Assert
			actual.ShouldNotBeNull();
			equality.ShouldNotBeNull();
			actual.ShouldBe(equality);
		}

		[Test]
		public void Can_not_equals_value_objects()
		{
			// Arrange
			var equality = new TestValueObject(
				city: "EqualityCity",
				street: "EqualityStreet");
			
			// Act
			var actual = new TestValueObject(
				city: "ActualCity",
				street: "ActualStreet");

			// Assert
			actual.ShouldNotBeNull();
			equality.ShouldNotBeNull();
			actual.ShouldNotBe(equality);
		}

		[Test]
		public void Can_create_valid_hash_set()
		{
			
		}
	}
}