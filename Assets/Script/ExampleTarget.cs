namespace Script
{
	public class ExampleTarget
	{
		[Inject]
		public ExampleDependency Dependency;

		public void PerformOperation()
		{
			Dependency.Log();
		}
	}
}