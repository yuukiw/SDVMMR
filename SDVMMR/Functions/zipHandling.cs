using System.IO.Compression;
namespace SDVMMR
{
	public class zipHandling
	{
		internal static void extractZip(string sourcePath, string destPath)
		{
			ZipFile.ExtractToDirectory(sourcePath,destPath);
		}
	}
}
