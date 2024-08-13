using System;

namespace SerializeDZ.Attributes
{
	public class IniProperty : Attribute
	{
		public string PropertyName { get; set; }
		public IniProperty(string propertyName)
		{
			PropertyName = propertyName;
		}
	}
}
