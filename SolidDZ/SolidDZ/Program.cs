namespace SolidDZ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var settings = new GameSettings();
			settings.SetSettings(5, 100);

			var numberGenerator = new NumberGenerator();
			var game = new GuessingGame(settings, numberGenerator);

			Console.WriteLine($"Угадайте число от 1 до {settings.GetNumberRange()} за {settings.GetMaxAttempts()} попыток");
			int guess = -1;

			do
			{
				try
				{
					Console.Write("Ваш вариант: ");
					guess = int.Parse(Console.ReadLine());
					string result = game.Guess(guess);
					Console.WriteLine(result);
					if (result == "Угадали!")
					{
						break;
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Пожалуйста, введите число.");
				}
			} while (!game.IsGameOver(guess));

			if (game.IsGameOver(guess) && game.Guess(guess) != "Угадали!")
			{
				Console.WriteLine($"Вы проиграли. Загаданное число было {game.TargetNumber}");
			}
		}
	}
}
