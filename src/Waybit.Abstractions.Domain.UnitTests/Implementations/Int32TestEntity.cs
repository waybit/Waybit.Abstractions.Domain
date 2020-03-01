namespace Waybit.Abstractions.Domain.UnitTests.Implementations
{
	public class Int32TestEntity : Entity<int>
	{
		/// <inheritdoc />
		public Int32TestEntity(int id, string name)
			: base(id)
		{
			Name = name;
		}

		public string Name { get; private set; }
	}
}