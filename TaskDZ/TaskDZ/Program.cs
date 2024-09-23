using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskDZ
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			string directoryPath = @"..\..\..\Files";

			string[] filePaths = { @"..\..\..\Files\TestFile1.txt", @"..\..\..\Files\TestFile2.txt", @"..\..\..\Files\TestFile3.txt" };
			List<Task<int>> tasks = new List<Task<int>>();

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			foreach (var filePath in filePaths)
			{
				tasks.Add(CountSpacesInFileAsync(filePath));
			}

			int[] results = await Task.WhenAll(tasks);
			int totalSpaces = await CountSpacesInDirectoryAsync(directoryPath);

			stopwatch.Stop();

			foreach (var content in results)
			{
				Console.WriteLine(content);
			}

			Console.WriteLine($"Кол-во пробелов в файлах из директории: {totalSpaces}");
			Console.WriteLine($"Затраченное время: {stopwatch.ElapsedMilliseconds} мс");
		}

		/// <summary>
		/// Получить файлы из директории.
		/// </summary>
		/// <param name="directoryPath">Путь к директории.</param>
		/// <returns>Возвращает название файлов из директории.</returns>
		public static string[] GetFilesInDirectory(string directoryPath)
		{
			return Directory.GetFiles(directoryPath);
		}

		/// <summary>
		/// Получить кол-во пробелов в файлах в директории.
		/// </summary>
		/// <param name="directoryPath">Путь к директории.</param>
		/// <returns>Возвращает кол-во пробелов в файлах.</returns>
		public static async Task<int> CountSpacesInDirectoryAsync(string directoryPath)
		{
			string[] filePaths = GetFilesInDirectory(directoryPath);
			return await CountSpacesInFilesAsync(filePaths);
		}

		/// <summary>
		/// Подсчитать кол-во пробелов в файле.
		/// </summary>
		/// <param name="filePath">Путь к файлу.</param>
		/// <returns>Возвращает кол-во пробелов в файле.</returns>
		public static async Task<int> CountSpacesInFileAsync(string filePath)
		{
			int spaceCount = 0;
			using (StreamReader reader = new StreamReader(filePath))
			{
				string content = await reader.ReadToEndAsync();
				spaceCount = content.Count(c => c == ' ');
			}
			return spaceCount;
		}

		/// <summary>
		/// Получить сумму пробелов в файлах.
		/// </summary>
		/// <param name="filePaths">Список путей к файлу.</param>
		/// <returns>Возвращает сумму пробелов во всех файлах.</returns>
		public static async Task<int> CountSpacesInFilesAsync(string[] filePaths)
		{
			var tasks = filePaths.Select(filePath => CountSpacesInFileAsync(filePath));
			int[] results = await Task.WhenAll(tasks);
			return results.Sum();
		}
	}
}
