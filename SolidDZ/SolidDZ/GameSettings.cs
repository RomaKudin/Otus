using SolidDZ.Interface;

namespace SolidDZ
{
	/// <summary>
	/// Класс с настройками
	/// </summary>
	public class GameSettings
	{
		private int _maxAttempts;
		private int _startRange;
		private int _endRange;

		public GameSettings(int maxAttempts, int startRange, int endRange)
		{
			_maxAttempts = maxAttempts;
			_startRange = startRange;
			_endRange = endRange;
		}

		public int GetMaxAttempts()
		{
			return _maxAttempts;
		}

		public int GetStartRange()
		{
			return _startRange;
		}

		public int GetEndRange()
		{
			return _endRange;
		}
	}
}
