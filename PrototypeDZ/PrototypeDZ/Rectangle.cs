using PrototypeDZ.Interface;

namespace PrototypeDZ
{
	/// <summary>
	/// Класс Rectangle (Прямоугольник), наследуется от Shape и добавляет свойства для ширины и высоты.
	/// </summary>
	public class Rectangle : Shape
	{
		/// <summary>
		/// Ширина прямоугольника.
		/// </summary>
		public double Width { get; set; }

		/// <summary>
		/// Высота прямоугольника.
		/// </summary>
		public double Height { get; set; }

		/// <summary>
		/// Конструктор для создания прямоугольника с указанным цветом, шириной и высотой.
		/// </summary>
		/// <param name="color">Цвет прямоугольника</param>
		/// <param name="width">Ширина прямоугольника</param>
		/// <param name="height">Высота прямоугольника</param>
		public Rectangle(string color, double width, double height)
			: base(color, width * height)
		{
			Width = width;
			Height = height;
		}

		/// <summary>
		/// Метод для клонирования объекта Rectangle с использованием IMyCloneable.
		/// </summary>
		/// <returns>Клон объекта Rectangle</returns>
		public override Shape MyClone()
		{
			return new Rectangle(this.Color, this.Width, this.Height);
		}

		/// <summary>
		/// Реализация метода Clone из интерфейса ICloneable.
		/// </summary>
		/// <returns>Клон объекта Rectangle</returns>
		public new object Clone()
		{
			return MyClone();
		}

		/// <summary>
		/// Переопределение метода ToString для вывода информации о прямоугольнике.
		/// </summary>
		/// <returns>Описание прямоугольника</returns>
		public override string ToString()
		{
			return base.ToString() + $", Ширина: {Width}, Высота: {Height}";
		}
	}
}
