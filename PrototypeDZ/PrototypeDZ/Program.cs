namespace PrototypeDZ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Создаем оригинальные объекты различных фигур
			Shape originalShape = new Shape("Зеленый", 50);
			Rectangle originalRectangle = new Rectangle("Красный", 4, 5);
			Square originalSquare = new Square("Желтый", 6);

			// Клонируем объекты
			Shape clonedShape = (Shape)originalShape.Clone();
			Rectangle clonedRectangle = (Rectangle)originalRectangle.Clone();
			Square clonedSquare = (Square)originalSquare.Clone();

			// Выводим оригиналы и их клоны
			Console.WriteLine("Оригинальная фигура: " + originalShape);
			Console.WriteLine("Клонированная фигура: " + clonedShape);

			Console.WriteLine("Оригинальный прямоугольник: " + originalRectangle);
			Console.WriteLine("Клонированный прямоугольник: " + clonedRectangle);

			Console.WriteLine("Оригинальный квадрат: " + originalSquare);
			Console.WriteLine("Клонированный квадрат: " + clonedSquare);
		}
	}
}
