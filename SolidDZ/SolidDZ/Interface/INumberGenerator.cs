namespace SolidDZ.Interface
{
	/// <summary>
	/// Интерфейс генерации числа.
	/// </summary>
	public interface INumberGenerator
	{
		/// <summary>
		/// Сгенерировать число.
		/// </summary>
		/// <param name="numberRange">Диапозон.</param>
		/// <returns>Возвращает сгенерированное число.</returns>
		public int GenerateNumber(int numberRange);
	}
}
