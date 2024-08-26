using SolidDZ.Interface;
using System;
using System.Security.Cryptography;

namespace SolidDZ
{
	/// <summary>
	/// Класс для генерации случайного числа
	/// </summary>
	public class NumberGenerator : INumberGenerator
	{
		protected int _startRange;

		protected int _endRange;

		public NumberGenerator(int startRange, int endRange)
		{
			_startRange = startRange;
			_endRange = endRange;
		}

		public virtual int GenerateNumber()
		{
			Random _random = new Random();
			return _random.Next(_startRange, _endRange + 1);
		}
	}
}
