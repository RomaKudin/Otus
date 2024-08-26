using SolidDZ.Enum;

namespace SolidDZ.Interface
{
	public interface IPrinter
	{
		public void Print(string toPrint, bool isNewLine = true);
		public void Print(Guess value, bool isNewLine = true);
	}
}
