using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

			Console.WriteLine($"Сериализация класса:");
			Console.WriteLine($"Кол-ва итераций: {_sycle}");
			SerializeTest(f);
			Console.WriteLine($"Десериализация ini:");
			Console.WriteLine($"Кол-ва итераций: {_sycle}");
			GetDataIniFileAndDeserialize<F>(@"..\..\File\F.ini");

			Console.WriteLine($"Сериализация ini:");
			Console.WriteLine($"Кол-ва итераций: {_sycle}");
			SerializeJson(@"..\..\File\F.ini");
			
			Console.WriteLine($"Десериализация ini:");
			Console.WriteLine($"Кол-ва итераций: {_sycle}");
			DeserializeJson<F>(@"..\..\File\F.ini");
			Console.ReadLine();
		}

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

		static Dictionary<string, Dictionary<string, string>> ParseIniToDictionary(IEnumerable<string> lines)
		{
			var result = new Dictionary<string, Dictionary<string, string>>();
			string currentSection = null;

			foreach (var line in lines)
			{
				var trimmedLine = line.Trim();

				if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith(";"))
					continue;

				if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
				{
					currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2);
					result[currentSection] = new Dictionary<string, string>();
				}
				else if (currentSection != null)
				{
					var parts = trimmedLine.Split('=');
					if (parts.Length == 2)
					{
						var key = parts[0].Trim();
						var value = parts[1].Trim();
						result[currentSection][key] = value;
					}
				}
			}

			return result;
		}

		static void SerializeJson(string path)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			if (string.IsNullOrEmpty(path))
			{
				Console.WriteLine("Путь к файлу не указан!");
				return;
			}

			var content = File.ReadLines(path);
			var iniData = ParseIniToDictionary(content);

			stopwatch.Start();
			for (int i = 0; i < _sycle; i++)
			{
				JsonConvert.SerializeObject(iniData);
			}
			var time = stopwatch.ElapsedMilliseconds;
			Console.WriteLine($"Время выполнения: {time} мс");
			var time2 = stopwatch.ElapsedMilliseconds;
			stopwatch.Stop();
			Console.WriteLine($"Время вывода текста {time2 - time} мс");
		}

		static void DeserializeJson<T>(string path) where T : class
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			if (string.IsNullOrEmpty(path))
			{
				Console.WriteLine("Путь к файлу не указан!");
				return;
			}

			var content = File.ReadLines(path);
			var iniData = ParseIniToDictionary(content);
			var json = JsonConvert.SerializeObject(iniData);

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
