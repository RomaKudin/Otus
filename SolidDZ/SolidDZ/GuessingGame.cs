using SolidDZ.Interface;
using System.ComponentModel;

namespace SolidDZ
{
	/// <summary>
	/// Класс для логики игры
	/// </summary>
	public class GuessingGame
	{
		private readonly GameSettings _settings;
		public int TargetNumber { get; init; }
		private int _attempts;
		public GuessingGame(GameSettings settings, INumberGenerator numberGenerator)
		{
			_settings = settings;
			TargetNumber = numberGenerator.GenerateNumber();
		}
		
		private string Guess(int number)
		{
			_attempts++;
			if (number < TargetNumber)
			{
				return "Больше";
			}
			else if (number > TargetNumber)
			{
				return "Меньше";
			}
			else
			{
				return "Угадали!";
			}
		}

		private bool IsGameOver(int number)
		{
			return _attempts >= _settings.GetMaxAttempts() || TargetNumber == number;
		}

		public void StartGame(IWriter write, IPrinter print) 
		{
			print.Print($"Угадайте число от {_settings.GetStartRange()} до {_settings.GetEndRange()} за {_settings.GetMaxAttempts()} попыток");
			int guess = -1;

			do
			{
				try
				{
					print.Print("Ваш вариант: ", false);
					guess = write.GetReadLine();
					print.Print("");
					string result = Guess(guess);
					print.Print(result);
					if (result == "Угадали!")
					{
						break;
					}
				}
				catch (FormatException)
				{
					print.Print("Пожалуйста, введите число.");
				}
			} while (!IsGameOver(guess));

			if (IsGameOver(guess) && Guess(guess) != "Угадали!")
			{
				print.Print($"Вы проиграли. Загаданное число было {TargetNumber}");
			}
		}
	}
}
