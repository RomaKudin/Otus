using SerializeDZ.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SerializeDZ
{
	internal class IniTypeReflector
	{
		public static IEnumerable<PropertyInfo> GetSectionTypes<T>()
		{
			return typeof(T).GetRuntimeProperties().Where(p => !p.GetCustomAttributes()
													.Any(a => a is IniIgnore) && p.PropertyType.GetTypeInfo().IsClass);
		}

		public static IEnumerable<PropertyInfo> GetAttributeTypes(Type type)
		{
			return type.GetRuntimeProperties().Where(p => !p.GetCustomAttributes().Any(a => a is IniIgnore));
		}

		public static bool TryGetComment(PropertyInfo info, out IniComment comment)
		{
			comment = info.GetCustomAttribute<IniComment>();
			return (comment != null);
		}

		public static bool TryGetAlternativeName(PropertyInfo info, out IniProperty property)
		{
			property = info.GetCustomAttribute<IniProperty>();
			return (property != null);
		}
	}
}
