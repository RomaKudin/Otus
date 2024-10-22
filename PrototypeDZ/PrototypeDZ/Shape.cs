using PrototypeDZ.Interface;

namespace PrototypeDZ
{
	/// <summary>
	/// Класс Shape (Фигура), базовый класс для всех геометрических фигур.
	/// </summary>
	public class Shape : ICloneable, IMyCloneable<Shape>
	{
		/// <summary>
		/// Цвет фигуры.
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// Площадь фигуры.
		/// </summary>
		public double Area { get; set; }

		/// <summary>
		/// Конструктор для создания фигуры с указанным цветом и площадью.
		/// </summary>
		/// <param name="color">Цвет фигуры</param>
		/// <param name="area">Площадь фигуры</param>
		public Shape(string color, double area)
		{
			Color = color;
			Area = area;
		}

		/// <summary>
		/// Метод для клонирования объекта Shape с использованием IMyCloneable.
		/// </summary>
		/// <returns>Клон объекта Shape</returns>
		public virtual Shape MyClone()
		{
			return new Shape(this.Color, this.Area);
		}

		/// <summary>
		/// Реализация метода Clone из интерфейса ICloneable.
		/// </summary>
		/// <returns>Клон объекта Shape</returns>
		public object Clone()
		{
			return MyClone();
		}

		/// <summary>
		/// Переопределение метода ToString для вывода информации о фигуре.
		/// </summary>
		/// <returns>Описание фигуры</returns>
		public override string ToString()
		{
			return $"Фигура: Цвет: {Color}, Площадь: {Area} кв. ед.";
		}
	}
}
