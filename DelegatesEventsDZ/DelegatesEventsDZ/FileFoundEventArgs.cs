namespace DelegatesEventsDZ
{
	public class FileFoundEventArgs
	{
		public string FileName { get; }

		public FileFoundEventArgs(string fileName)
		{
			FileName = fileName;
		}
	}
}
