using System;
using System.Collections.Generic;
using System.Reflection;

namespace SerializeDZ
{
	internal class IniTypeReflector
	{
		public static IEnumerable<PropertyInfo> GetSectionTypes<T>()
		{
			return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
		}

		public static IEnumerable<PropertyInfo> GetAttributeTypes(Type type)
		{
			return type.GetRuntimeProperties();
		}
	}
}
