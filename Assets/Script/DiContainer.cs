using System;
using System.Collections.Generic;

public class DiContainer
{
	public readonly Dictionary<Type, object> Contracts = new();

	public void Bind(object instance)
	{
		var type = instance.GetType();
		
		if (Contracts.ContainsKey(instance.GetType()))
		{
			throw new InvalidOperationException($"Type {type} is already binded!");
		}
		
		Contracts.Add(type, instance);
	}

	public void Inject(object instance)
	{
		
	}
}
