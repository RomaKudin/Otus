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
		/// <returns>Возвращает сгенерированное число.</returns>
		public int GenerateNumber();
	}
}
