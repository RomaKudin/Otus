namespace DelegatesEventsDZ
{
	public static class Program
	{
		static void Main(string[] args)
		{
			List<MyTestClass> list = new List<MyTestClass>
			{
				new MyTestClass { Value = 12 },
				new MyTestClass { Value = 1.4f },
				new MyTestClass { Value = 32 },
				new MyTestClass { Value = 2.5f },
				new MyTestClass { Value = 21 },
				new MyTestClass { Value = 32.1f },
			};

			var maxElement = list.GetMax(x => x.Value);
			Console.WriteLine($"Максимальное значение: {maxElement?.Value}");

			var fileSearcher = new DirectoryFileSearcher();
			fileSearcher.FileFound += (sender, e) =>
			{
				Console.WriteLine($"Файл найден: {e.FileName}");
			};

			string path = Directory.GetCurrentDirectory();
			var cts = new CancellationTokenSource();
			fileSearcher.Search(path, cts.Token);
		}

		/// <summary>
		/// Поиск максимального числа из коллекции
		/// </summary>
		/// <typeparam name="T">Тип</typeparam>
		/// <param name="collection">Коллекиция</param>
		/// <param name="getValue">Предикат функции</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> getValue) where T : class
		{
			if (collection == null || !collection.Any())
				throw new ArgumentException("Пустая коллекция или null");

			T maxElement = null;
			float maxValue = float.MinValue;

			foreach (var item in collection)
			{
				float value = getValue(item);
				if (value > maxValue)
				{
					maxValue = value;
					maxElement = item;
				}
			}

			return maxElement;
		}
	}

	/// <summary>
	/// Класс для значения
	/// </summary>
	public class MyTestClass
	{
		public float Value { get; set; }
	}
}
