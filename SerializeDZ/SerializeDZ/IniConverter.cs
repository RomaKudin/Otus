using SerializeDZ.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SerializeDZ
{
	internal class IniConverter
	{
		public static string SerializeObject<T>(T target) where T : class
		{
			IniWriter writer = new IniWriter();
			IEnumerable<PropertyInfo> sections = IniTypeReflector.GetSectionTypes<T>();
			if (sections.Count() > 0)
			{
				foreach (PropertyInfo section in sections)
				{
					writer.WriteSection(section.Name);

					object propertyValue = section.GetValue(target);
					WriteAttributes(propertyValue, writer);

					writer.EndSection();
				}
			}
			else
			{
				writer.WriteSection(typeof(T).Name);
				WriteAttributes(target, writer);
				writer.EndSection();
			}

			return writer.GetIniString();
		}

		public static T DeserializeObject<T>(string iniContent) where T : class
		{
			IniReader reader = new IniReader();

			string[] lines = iniContent.Split('\n');
			T target = Activator.CreateInstance<T>();

			IEnumerable<PropertyInfo> sections = IniTypeReflector.GetSectionTypes<T>();
			if (sections.Count() == 0)
			{
				ReadAttributes(target, typeof(T), reader, lines, 1);
				return target;
			}

			for (int i = 0; i < lines.Length; ++i)
			{
				lines[i] = lines[i].Trim();

				if (reader.TryGetSection(lines[i], out string section))
				{
					PropertyInfo currentSection = sections.FirstOrDefault(s => s.Name == section);
					object obj = Activator.CreateInstance(currentSection.PropertyType);
					currentSection.SetValue(target, obj);
					++i;

					i += ReadAttributes(obj, currentSection.PropertyType, reader, lines, i);
				}
			}

			return target;
		}

		private static int ReadAttributes(object target, Type type, IniReader reader, string[] lines, int i)
		{
			IEnumerable<PropertyInfo> attributes = IniTypeReflector.GetAttributeTypes(type);
			int attributesRead = 0;

			for (; i < lines.Length && !reader.IsSection(lines[i]); ++i)
			{
				lines[i] = lines[i].Trim();

				foreach (KeyValuePair<string, string> att in reader.GetAttributes(lines[i]))
				{
					PropertyInfo currentAttribute = attributes.FirstOrDefault(a => a.Name == att.Key ||
								(a.GetCustomAttribute<IniProperty>()?.PropertyName == att.Key));

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
				string name = attribute.Name;
				if (IniTypeReflector.TryGetComment(attribute, out IniComment comment))
					writer.WriteComment(comment.Content);

				if (IniTypeReflector.TryGetAlternativeName(attribute, out IniProperty property))
					name = property.PropertyName;

				writer.WriteAttribute(name, attribute.GetValue(propertyValue).ToString());
			}
		}
	}
}
