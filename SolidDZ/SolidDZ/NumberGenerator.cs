using SolidDZ.Interface;

namespace SolidDZ
{
	/// <summary>
	/// Класс для генерации случайного числа
	/// </summary>
	public class NumberGenerator : INumberGenerator
	{
		private readonly Random _random = new Random();

		public int GenerateNumber(int numberRange)
		{
			return _random.Next(1, numberRange + 1);
		}
	}
}
