namespace DelegatesEventsDZ
{
	/// <summary>
	/// Класс по поиску файлов в директории.
	/// </summary>
	public class DirectoryFileSearcher
	{
		/// <summary>
		/// Событие.
		/// </summary>
		public event EventHandler<FileFoundEventArgs> FileFound;

		/// <summary>
		/// Поиск файлов.
		/// </summary>
		/// <param name="directory">Путь.</param>
		/// <param name="cancellationToken">Отмена.</param>
		public void Search(string directory, CancellationToken cancellationToken)
		{
			foreach (var file in Directory.GetFiles(directory))
			{
				if (cancellationToken.IsCancellationRequested)
					return;

				OnFileFound(new FileFoundEventArgs(file));
			}

			foreach (var dir in Directory.GetDirectories(directory))
			{
				if (cancellationToken.IsCancellationRequested)
					return;

				Search(dir, cancellationToken);
			}
		}

		/// <summary>
		/// Обработчик нахождения файла.
		/// </summary>
		/// <param name="e">Аргументы.</param>
		protected virtual void OnFileFound(FileFoundEventArgs e)
		{
			FileFound?.Invoke(this, e);
		}
	}
}
