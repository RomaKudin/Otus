using System;

namespace SerializeDZ.Attributes
{
	public class IniComment : Attribute
	{
		public string Content { get; private set; }
		public IniComment(string content)
		{
			Content = content;
		}
	}
}
