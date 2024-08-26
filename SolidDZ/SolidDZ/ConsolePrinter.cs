using SolidDZ.Interface;

namespace SolidDZ
{
	public class ConsolePrinter : IPrinter
	{
		public void Print(string str, bool isNewLine = true)
		{
			if (isNewLine)
			{
				Console.WriteLine(str);
			}
			else
			{
				Console.Write(str);
			}
		}
	}
}
