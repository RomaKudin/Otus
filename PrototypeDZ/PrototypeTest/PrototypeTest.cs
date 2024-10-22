using PrototypeDZ;

namespace PrototypeTest
{
	public class PrototypeTests
	{
		/// <summary>
		/// ������������ ������������ ������� ������ (Shape).
		/// </summary>
		[Fact]
		public void Shape_Clone_ShouldCloneBaseShape()
		{
			Shape original = new Shape("�����", 20);
			Shape clone = (Shape)original.Clone();

			// Assert: ���������, ��� ���� �� ����� ���������, �� �� �������� ���������
			Assert.NotSame(original, clone);
			Assert.Equal(original.Color, clone.Color);
			Assert.Equal(original.Area, clone.Area);
		}

		/// <summary>
		/// ������������ ������������ �������������� (Rectangle).
		/// </summary>
		[Fact]
		public void Rectangle_Clone_ShouldCloneRectangle()
		{
			Rectangle original = new Rectangle("�������", 4, 5);
			Rectangle clone = (Rectangle)original.Clone();

			// Assert: ���������, ��� ���� �� ����� ���������, �� �� �������� ���������
			Assert.NotSame(original, clone);
			Assert.Equal(original.Color, clone.Color);
			Assert.Equal(original.Width, clone.Width);
			Assert.Equal(original.Height, clone.Height);
			Assert.Equal(original.Area, clone.Area);
		}

		/// <summary>
		/// ������������ ������������ �������� (Square).
		/// </summary>
		[Fact]
		public void Square_Clone_ShouldCloneSquare()
		{
			Square original = new Square("������", 6);
			Square clone = (Square)original.Clone();

			// Assert: ���������, ��� ���� �� ����� ���������, �� �� �������� ���������
			Assert.NotSame(original, clone);
			Assert.Equal(original.Color, clone.Color);
			Assert.Equal(original.Area, clone.Area);
		}

		/// <summary>
		/// ������������ ������������� �������������� ������� �� �������������.
		/// </summary>
		[Fact]
		public void Clone_ShouldCreateIndependentClone()
		{
			Square original = new Square("�������", 7);
			Square clone = (Square)original.Clone();

			// �������� ��������
			original.Color = "������";

			// Assert: ���������, ��� ���� ������� ����������
			Assert.Equal("�������", clone.Color);

			// �������� �������
			Assert.Equal("������", original.Color);
		}

		/// <summary>
		/// ������������ ������ ToString ��� ������ Square.
		/// </summary>
		[Fact]
		public void Square_ToString_ShouldReturnCorrectString()
		{
			// Arrange: ������� ������ Square
			Square square = new Square("�����", 5);

			// Act: �������� ����� ToString
			string result = square.ToString();

			// Assert: ���������, ��� ��������� ������������� ���������
			Assert.Contains("������: ����: �����", result);
			Assert.Contains("�������: 25", result);
			Assert.Contains("��������: 5", result);
		}
	}
}