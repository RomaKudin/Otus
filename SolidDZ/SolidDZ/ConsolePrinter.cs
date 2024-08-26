using SolidDZ.Enum;
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

		public void Print(Guess value, bool isNewLine = true)
		{
			switch (value)
			{
				case Enum.Guess.Greater:
					Print("Больше", isNewLine);
					break;
				case Enum.Guess.Less:
					Print("Меньше", isNewLine);
					break;
				case Enum.Guess.Success:
					Print("Угадали!", isNewLine);
					break;
				default:
					break;
			}
		}
	}
}
