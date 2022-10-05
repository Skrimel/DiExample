using System;
using System.Collections.Generic;
using System.Linq;
using Script;

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

	public TDependency Resolve<TDependency>()
	{
		return (TDependency)Contracts[typeof(TDependency)];
	}

	public void Inject(object instance)
	{
		var fields = instance.GetType()
			.GetFields()
			.Where(i => i.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0);

		foreach (var field in fields)
		{
			var fieldType = field.FieldType;
			field.SetValue(instance, Contracts[fieldType]);
		}
	}
}
