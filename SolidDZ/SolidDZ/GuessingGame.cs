using SolidDZ.Interface;

namespace SolidDZ
{
	/// <summary>
	/// Класс для логики игры
	/// </summary>
	public class GuessingGame
	{
		private readonly IGameSettings _settings;
		private readonly INumberGenerator _numberGenerator;
		private readonly int _targetNumber;
		private int _attempts;

		public int TargetNumber {
			get {
				return _targetNumber;
			}
		}

		public GuessingGame(IGameSettings settings, INumberGenerator numberGenerator)
		{
			_settings = settings;
			_numberGenerator = numberGenerator;
			_targetNumber = _numberGenerator.GenerateNumber(_settings.GetNumberRange());
			_attempts = 0;
		}

		public string Guess(int number)
		{
			_attempts++;
			if (number < _targetNumber)
			{
				return "Больше";
			}
			else if (number > _targetNumber)
			{
				return "Меньше";
			}
			else
			{
				return "Угадали!";
			}
		}

		public bool IsGameOver(int number)
		{
			return _attempts >= _settings.GetMaxAttempts() || _targetNumber == number;
		}
	}
}
