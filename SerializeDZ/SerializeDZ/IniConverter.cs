using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SerializeDZ
{
	/// <summary>
	/// Класс конвертер Ini файла
	/// </summary>
	public class IniConverter
	{
		public static string SerializeObject<T>(T target) where T : class
		{
			IniWriter writer = new IniWriter();

			writer.WriteSection(typeof(T).Name);
			WriteAttributes(target, writer);
			writer.EndSection();

			return writer.GetIniString();
		}

		public static T DeserializeObject<T>(string iniContent) where T : class
		{
			string[] lines = iniContent.Split('\n');
			T target = Activator.CreateInstance<T>();

			IEnumerable<PropertyInfo> sections = IniTypeReflector.GetSectionTypes<T>();
			ReadAttributes(target, typeof(T), lines, 0);
			return target;
		}

		private static int ReadAttributes(object target, Type type, string[] lines, int i)
		{
			IEnumerable<PropertyInfo> attributes = IniTypeReflector.GetAttributeTypes(type);
			int attributesRead = 0;

			for (; i < lines.Length && !IniReader.IsSection(lines[i]); ++i)
			{
				foreach (KeyValuePair<string, string> att in IniReader.GetAttributes(lines[i]))
				{
					PropertyInfo currentAttribute = attributes.FirstOrDefault(a => a.Name == att.Key);

					if (currentAttribute != null)
					{
						currentAttribute.SetValue(target, Convert.ChangeType(att.Value, currentAttribute.PropertyType));
						++attributesRead;
					}
				}
			}

			return attributesRead;
		}

		private static void WriteAttributes(object propertyValue, IniWriter writer)
		{
			foreach (PropertyInfo attribute in IniTypeReflector.GetAttributeTypes(propertyValue.GetType()))
			{
				writer.WriteAttribute(attribute.Name, attribute.GetValue(propertyValue).ToString());
			}
		}
	}
}
