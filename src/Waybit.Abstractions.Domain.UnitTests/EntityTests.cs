using NUnit.Framework;
using Shouldly;
using Waybit.Abstractions.Domain.UnitTests.Implementations;

namespace Waybit.Abstractions.Domain.UnitTests
{
	public class EntityTests
	{
		[Test]
		public void Can_create_entity()
		{
			// Arrange
			const string entityName = "testName";
			const int id = 1;
			
			// Act
			var testInt32Entity = new Int32TestEntity(id, entityName); 
			
			// Assert
			testInt32Entity.ShouldNotBeNull();
			testInt32Entity.Id.ShouldBeOfType<int>();
			testInt32Entity.Id.ShouldBe(id);
			testInt32Entity.Name.ShouldBe(entityName);
		}
	}
}