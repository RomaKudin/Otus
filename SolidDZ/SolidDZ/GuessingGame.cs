using SolidDZ.Enum;
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
		private INumberGenerator _numberGenerator;
		private int TargetNumber { get; set; }
		private int _attempts;
		public GuessingGame(GameSettings settings, INumberGenerator numberGenerator)
		{
			_settings = settings;
			_numberGenerator = numberGenerator;
		}
		
		private Guess Guess(int number)
		{
			_attempts++;
			if (number < TargetNumber)
			{
				return Enum.Guess.Greater;
			}
			else if (number > TargetNumber)
			{
				return Enum.Guess.Less;
			}
			else
			{
				return Enum.Guess.Success;
			}
		}

		private bool IsGameOver(int number)
		{
			return _attempts >= _settings.GetMaxAttempts() || TargetNumber == number;
		}

		public void StartGame(IWriter write, IPrinter print)
		{
			try
			{
				TargetNumber = _numberGenerator.GenerateNumber();
				print.Print($"Угадайте число от {_settings.GetStartRange()} до {_settings.GetEndRange()} за {_settings.GetMaxAttempts()} попыток");
				int guess = -1;

				do
				{

					print.Print("Ваш вариант: ", false);
					guess = write.GetReadLine();
					print.Print("");
					var result = Guess(guess);
					print.Print(result);

					if (result == Enum.Guess.Success)
					{
						break;
					}

				} while (!IsGameOver(guess)) ;

				if (IsGameOver(guess) && Guess(guess) != Enum.Guess.Success)
				{
					print.Print($"Вы проиграли. Загаданное число было {TargetNumber}");
				}
			}
			catch (Exception e)
			{
				print.Print($"Ошибка {e.Message}");
			}
		}
	}
}
