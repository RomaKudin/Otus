using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ParallelDz
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] sizes = { 100000, 1000000, 10000000 };

			Console.WriteLine("Операционная система: " + RuntimeInformation.OSDescription);
			Console.WriteLine("Тип ОС: " + RuntimeInformation.OSArchitecture);
			Console.WriteLine("Архитектура процесса: " + RuntimeInformation.ProcessArchitecture);
			Console.WriteLine("Количество логических процессоров: " + Environment.ProcessorCount);
			Console.WriteLine("Максимальный объём памяти, доступный процессу: " + Environment.WorkingSet / (1024 * 1024) + " MB");
			Console.WriteLine();

			foreach (var size in sizes)
			{
				int[] array = new int[size];
				Random rand = new Random();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = rand.Next(1, 100);
				}

				Console.WriteLine($"Array size: {size}");

				// Обычное суммирование
				Stopwatch sw = Stopwatch.StartNew();
				long sequentialSum = Sum(array);
				sw.Stop();
				Console.WriteLine($"Sum: {sequentialSum}, Time: {sw.ElapsedMilliseconds} ms");

				sw.Restart();
				long parallelSum = ThreadsSum(array);
				sw.Stop();
				Console.WriteLine($"ThreadsSum: {sequentialSum}, Time: {sw.ElapsedMilliseconds} ms");

				sw.Restart();
				long linqSum = LinqSum(array);
				sw.Stop();
				Console.WriteLine($"LinqSum: {sequentialSum}, Time: {sw.ElapsedMilliseconds} ms");
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Выполняет последовательное суммирование элементов массива.
		/// </summary>
		/// <param name="array">Массив целых чисел, элементы которого нужно просуммировать.</param>
		/// <returns>Сумма всех элементов массива.</returns>
		static long Sum(int[] array)
		{
			long sum = 0;
			foreach (var num in array)
			{
				sum += num;
			}
			return sum;
		}

		/// <summary>
		/// Выполняет параллельное суммирование элементов массива с использованием потоков.
		/// Массив делится на части, каждая из которых обрабатывается отдельным потоком.
		/// </summary>
		/// <param name="array">Массив целых чисел, элементы которого нужно просуммировать.</param>
		/// <returns>Сумма всех элементов массива.</returns>
		static long ThreadsSum(int[] array)
		{
			int numThreads = Environment.ProcessorCount;
			List<Thread> threads = new List<Thread>();
			long[] partialSums = new long[numThreads];
			int chunkSize = array.Length / numThreads;

			for (int i = 0; i < numThreads; i++)
			{
				int threadIndex = i;
				threads.Add(new Thread(() =>
				{
					int start = threadIndex * chunkSize;
					int end = (threadIndex == numThreads - 1) ? array.Length : start + chunkSize;
					for (int j = start; j < end; j++)
					{
						partialSums[threadIndex] += array[j];
					}
				}));
			}

			foreach (var thread in threads)
			{
				thread.Start();
			}

			foreach (var thread in threads)
			{
				thread.Join();
			}

			long sum = partialSums.Sum();
			return sum;
		}

		/// <summary>
		/// Выполняет параллельное суммирование элементов массива с использованием LINQ.
		/// Массив обрабатывается параллельно с помощью метода AsParallel.
		/// </summary>
		/// <param name="array">Массив целых чисел, элементы которого нужно просуммировать.</param>
		/// <returns>Сумма всех элементов массива.</returns>
		static long LinqSum(int[] array)
		{
			return array.AsParallel().Sum(x => (long)x);
		}


	}
}
