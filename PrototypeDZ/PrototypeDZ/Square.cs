using PrototypeDZ.Interface;

namespace PrototypeDZ
{
	/// <summary>
	/// Класс Square (Квадрат), наследуется от Rectangle, где стороны квадрата равны.
	/// </summary>
	public class Square : Rectangle
	{
		/// <summary>
		/// Конструктор для создания квадрата с указанным цветом и длиной стороны.
		/// </summary>
		/// <param name="color">Цвет квадрата</param>
		/// <param name="sideLength">Длина стороны квадрата</param>
		public Square(string color, double sideLength)
			: base(color, sideLength, sideLength)
		{
		}

		/// <summary>
		/// Метод для клонирования объекта Square с использованием IMyCloneable.
		/// </summary>
		/// <returns>Клон объекта Square</returns>
		public override Shape MyClone()
		{
			return new Square(this.Color, this.Width);
		}

		/// <summary>
		/// Реализация метода Clone из интерфейса ICloneable.
		/// </summary>
		/// <returns>Клон объекта Square</returns>
		public new object Clone()
		{
			return MyClone();
		}

		/// <summary>
		/// Переопределение метода ToString для вывода информации о квадрате.
		/// </summary>
		/// <returns>Описание квадрата</returns>
		public override string ToString()
		{
			return base.ToString() + $", Сторона квадрата: {Width}";
		}
	}
}
