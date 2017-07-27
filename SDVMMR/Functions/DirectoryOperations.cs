using System;
using System.IO;



namespace SDVMMR
{
	public static class DirectoryOperations
	{
		static string sep = Path.DirectorySeparatorChar.ToString();

		public static void createAppData(string path)
		{
			var dir = System.IO.Path.GetDirectoryName(path);
			if (!System.IO.Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			var file = File.Create(path);
			file.Close();
		}

		public static string getFolder(string Folder)
		{
			if (Folder == "OldAppData")
			{
				string test = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string tes2 = Path.Combine(test, "SDVMM\\WindowsApplication1\\1.0.0.0\\");
				return Path.Combine(test, "SDVMM\\WindowsApplication1\\1.0.0.0\\");
			}
			if (Folder == "AppData")
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			}
			if (Folder == "User")
			{
				return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			}

			return null;
		}

		internal static void moveMod(string FromFolder, string ToFolder)
		{
		}




	}
}
