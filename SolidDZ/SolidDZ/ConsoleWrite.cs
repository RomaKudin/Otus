using SolidDZ.Interface;
using System.Text;

namespace SolidDZ
{
	public class ConsoleWrite : IWriter
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

			return value;
		}
	}
}
