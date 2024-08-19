using SolidDZ.Interface;

namespace SolidDZ
{
	/// <summary>
	/// Класс с настройками
	/// </summary>
	public class GameSettings : IGameSettings
	{
		private int _maxAttempts;
		private int _numberRange;


		public void SetSettings(int maxAttempts, int numberRange)
		{
			_maxAttempts = maxAttempts;
			_numberRange = numberRange;
		}

		public int GetMaxAttempts()
		{
			return _maxAttempts;
		}

		public int GetNumberRange()
		{
			return _numberRange;
		}
	}
}
