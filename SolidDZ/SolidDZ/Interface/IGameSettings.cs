namespace SolidDZ.Interface
{
	/// <summary>
	/// Интерфейс настроек игры.
	/// </summary>
	public interface IGameSettings
	{
		/// <summary>
		/// Установить настрокйик.
		/// </summary>
		/// <param name="maxAttempts">Максимальное число попыток.</param>
		/// <param name="numberRange">Диапозон.</param>
		public void SetSettings(int maxAttempts, int numberRange);

		/// <summary>
		/// Получить кол-во попыток.
		/// </summary>
		/// <returns>Возвращает кол-во попыток.</returns>
		public int GetMaxAttempts();

		/// <summary>
		/// Получить диапозон.
		/// </summary>
		/// <returns>Возвращает диапозон.</returns>
		public int GetNumberRange();
	}
}
