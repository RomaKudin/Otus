using System.Text;

namespace SerializeDZ
{
	public class IniWriter
	{
		private StringBuilder builder = new StringBuilder();

		internal void WriteSection(string sectionName)
		{
			builder.AppendLine($"[{sectionName}]");
		}

		internal void WriteAttribute(string attribute, string value)
		{
			builder.AppendLine($"{attribute}={value}");
		}

		internal void WriteComment(string comment)
		{
			builder.AppendLine($"# {comment}");
		}

		internal void EndSection()
		{
			builder.AppendLine();
		}

		internal string GetIniString()
		{
			return builder.ToString();
		}
	}
}
