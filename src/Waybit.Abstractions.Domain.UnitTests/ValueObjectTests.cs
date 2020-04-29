using System.Collections.Generic;
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
		public void Reference_equals_test()
		{
			// Arrange
			var valueObjectList = new List<TestValueObject>(2);
			var valueObject = new TestValueObject("city", "street");
			
			valueObjectList.Add(valueObject);
			valueObjectList.Add(valueObject);
			
			// Act
			TestValueObject left = valueObjectList[0];
			TestValueObject right = valueObjectList[1];

			// Assert
			left.Equals(right).ShouldBeTrue();
		}
		
		[Test]
		public void Not_Reference_equals_test()
		{
			// Arrange
			var valueObjectList = new List<TestValueObject>(2);
			var valueObject1 = new TestValueObject("city1", "street1");
			var valueObject2 = new TestValueObject("city2", "street2");
			
			valueObjectList.Add(valueObject1);
			valueObjectList.Add(valueObject2);
			
			// Act
			TestValueObject left = valueObjectList[0];
			TestValueObject right = valueObjectList[1];

			// Assert
			left.Equals(right).ShouldBeFalse();
		}

		[Test]
		public void Equality_operator_test()
		{
			// Arrange
			var valueObject1 = new TestValueObject("city1", "street1");
			var valueObject2 = new TestValueObject("city1", "street1");
			
			// Act & Assert
			(valueObject1 == valueObject2).ShouldBeTrue();
		}
		
		[Test]
		public void Not_equality_operator_test()
		{
			// Arrange
			var valueObject1 = new TestValueObject("city1", "street1");
			var valueObject2 = new TestValueObject("city2", "street2");
			
			// Act & Assert
			(valueObject1 != valueObject2).ShouldBeTrue();
		}

		[Test]
		public void Can_create_valid_hash_set()
		{
			// Arrange
			var valueObject1 = new TestValueObject("city1", "street1");
			var valueObject2 = new TestValueObject("city2", "street2");
			var valueObject3 = new TestValueObject("city3", "street3");
			
			// Act
			var hashSet = new HashSet<TestValueObject>();
			hashSet.Add(valueObject1);
			hashSet.Add(valueObject2);
			hashSet.Add(valueObject3);
			
			// Assert
			hashSet.Count.ShouldBe(3);
		}
		
		[Test]
		public void Can_create_not_valid_hash_set()
		{
			// Arrange
			var valueObject1 = new TestValueObject("city1", "street1");
			
			// Act
			var hashSet = new HashSet<TestValueObject>();
			hashSet.Add(valueObject1);
			hashSet.Add(valueObject1);
			hashSet.Add(valueObject1);
			
			// Assert
			hashSet.Count.ShouldBe(1);
		}

		[Test]
		public void Can_use_to_string()
		{
			// Arrange
			var valueObject = new TestValueObject("Samara", "Novo-Sadovaya");
			const string expected = "Samara, Novo-Sadovaya";
			
			// Act
			string actual = valueObject.ToString();
			
			// Assert
			actual.ShouldBe(expected);
		}
		
		[Test]
		public void Can_use_interpolation_string()
		{
			// Arrange
			var valueObject = new TestValueObject("Samara", "Novo-Sadovaya");
			const string expected = "Samara, Novo-Sadovaya";
			
			// Act
			string actual = $"{valueObject}";
			
			// Assert
			actual.ShouldBe(expected);
		}
	}
}
