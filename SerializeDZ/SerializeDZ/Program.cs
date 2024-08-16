using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace SerializeDZ
{

	internal class Program
	{
		static int _sycle = 100000;
		static void Main(string[] args)
		{
			var f = new F { I1 = 1, I2 = 2, I3 = 3, I4 = 4, I5 = 5 };

			Console.WriteLine($"Кол-во итераций: {_sycle}");
			Console.WriteLine($"Сериализация класса:");
			SerializeTest(f);
			Console.WriteLine();

			Console.WriteLine($"--------------Custom--------------------------------");
			Console.WriteLine($"Custom Cериализация ini:");
			SetDataIniFileAndSeserialize(f, @"..\..\File\F.ini");
			
			Console.WriteLine($"Custom десериализация ini:");
			GetDataIniFileAndDeserialize<F>(@"..\..\File\F.ini");
			Console.WriteLine();

			Console.WriteLine($"--------------Newtonsoft.Json--------------------------------");
			Console.WriteLine($"Сериализация Newtonsoft.Json:");
			
			SerializeJson(@"..\..\File\F.ini");
			Console.WriteLine($"Десериализация Newtonsoft.Json:");
			DeserializeJson(f);

			Console.ReadLine();
		}


		/// <summary>
		/// Стандартная сериализация JSON при помощи System.Text.Json.JsonSerializer
		/// </summary>
		/// <typeparam name="T">Тип объекта</typeparam>
		/// <param name="classSerialize">Объект класса</param>
		static void SerializeTest<T>(T classSerialize) where T : class
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			
			for (int i = 0; i < _sycle; i++)
			{
				var json = System.Text.Json.JsonSerializer.Serialize(classSerialize);
			}

			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine($"Время выполнения: {time} мс");
			var time2 = stopwatch.ElapsedMilliseconds;
			stopwatch.Stop();
			Console.WriteLine($"Время вывода текста {time2 - time} мс");
		}

		/// <summary>
		/// Сериализация при помощи рефлексии
		/// </summary>
		/// <typeparam name="T">Тип объекта</typeparam>
		/// <param name="path">Путь к файлу</param>
		static void SetDataIniFileAndSeserialize<T>(T target, string path) where T : class
		{
			var stopwatch = new Stopwatch();

			if (string.IsNullOrEmpty(path))
			{
				Console.WriteLine("Путь к файлу не указан!");
				return;
			}

			var content = File.ReadAllText(path);
			stopwatch.Start();
			for (int i = 0; i < _sycle; i++)
			{
				IniConverter.SerializeObject(target);
			}
			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine($"Время выполнения: {time} мс");
			var time2 = stopwatch.ElapsedMilliseconds;
			stopwatch.Stop();
			Console.WriteLine($"Время вывода текста {time2 - time} мс");

		}

		/// <summary>
		/// Десериализация при помощи рефлексии
		/// </summary>
		/// <typeparam name="T">Тип объекта</typeparam>
		/// <param name="path">Путь к файлу</param>
		static void GetDataIniFileAndDeserialize<T>(string path) where T : class
		{
			var stopwatch = new Stopwatch();
			
			if (string.IsNullOrEmpty(path))
			{
				Console.WriteLine("Путь к файлу не указан!");
				return;
			}

			var content = File.ReadAllText(path);
			stopwatch.Start();
			for (int i = 0; i < _sycle; i++)
			{
				IniConverter.DeserializeObject<T>(content);
			}
			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine($"Время выполнения: {time} мс");
			var time2 = stopwatch.ElapsedMilliseconds;
			stopwatch.Stop();
			Console.WriteLine($"Время вывода текста {time2-time} мс");

		}

		/// <summary>
		/// Стандартная сериализация JSON при помощи Newtonsoft.Json
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		static void SerializeJson<T>(T target)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			stopwatch.Start();
			
			for (int i = 0; i < _sycle; i++)
			{
				JsonConvert.SerializeObject(target);
			}
			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine($"Время выполнения: {time} мс");
			var time2 = stopwatch.ElapsedMilliseconds;
			stopwatch.Stop();
			Console.WriteLine($"Время вывода текста {time2 - time} мс");
		}

		/// <summary>
		/// Стандартная десериализация JSON при помощи Newtonsoft.Json
		/// </summary>
		/// <typeparam name="T"></typeparam>
		static void DeserializeJson<T>(T target) where T : class
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var json = JsonConvert.SerializeObject(target);

			stopwatch.Start();
			for (int i = 0; i < _sycle; i++)
			{
				JsonConvert.DeserializeObject<T>(json);
			}
			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine($"Время выполнения: {time} мс");
			var time2 = stopwatch.ElapsedMilliseconds;
			stopwatch.Stop();
			Console.WriteLine($"Время вывода текста {time2 - time} мс");
		}
	}
}
