using UnityEngine;

namespace Script
{
	public class ExampleStartup : MonoBehaviour
	{
		public void Awake()
		{
			var target = new ExampleTarget();
			
			var container = new DiContainer();
			var dependency = new ExampleDependency();
			container.Bind(dependency);
			container.Inject(target);

			target.PerformOperation();
		}
	}
}