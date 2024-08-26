namespace SolidDZ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var settings = new GameSettings(5, 1, 100);
			var numberGenerator = new AdvancedNumberGenerator(settings.GetStartRange(), settings.GetEndRange());
			var game = new GuessingGame(settings, numberGenerator);
			game.StartGame(new MyConsolePrinter());
		}
	}
}
