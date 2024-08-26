using SolidDZ.Enum;
using SolidDZ.Interface;
using System.Text;

namespace SolidDZ
{
	public class MyConsolePrinter : IPrinter, IWriter
	{
		public int GetReadLine()
		{
			StringBuilder input = new StringBuilder();
			ConsoleKeyInfo keyInfo;
			int value = 0;
			while (true)
			{
				keyInfo = Console.ReadKey(true);

				if (char.IsDigit(keyInfo.KeyChar))
				{
					input.Append(keyInfo.KeyChar);
					Console.Write(keyInfo.KeyChar);
				}
				else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
				{
					input.Remove(input.Length - 1, 1);
					Console.Write("\b \b");
				}
				else if (keyInfo.Key == ConsoleKey.Enter)
				{
					bool success = int.TryParse(input.ToString(), out value);
					if (success)
					{
						break;
					}
					else
					{
						input.Clear();
						Console.WriteLine();
						Console.WriteLine("Преобразование не удалось, повторите попытку ввода числа.");
					}
				}
			}
			Console.WriteLine();

			return value;
		}

		public void StartGame(int start, int end, int attempts)
		{
			Console.WriteLine($"Угадайте число от {start} до {end} за {attempts} попыток");
		}

		public void PrintOption()
		{
			Console.Write("Ваш вариант: ");
		}

		public void PrintGameOver(int targetNumber)
		{
			Console.WriteLine($"Вы проиграли. Загаданное число было {targetNumber}");
		}

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
