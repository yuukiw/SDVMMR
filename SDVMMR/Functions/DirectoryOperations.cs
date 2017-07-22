using System;
using System.IO;



namespace SDVMMR
{
	public static class DirectoryOperations
	{
		static string sep = Path.DirectorySeparatorChar.ToString();


		public static string getFolder(string Folder)
		{
			if (Folder == "OldAppData")
			{
				string test = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				return Path.Combine(test, "SDVMM\\WindowsApplication1\\1.0.0.0\\");
			}
			if (Folder == "AppData")
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			}
			if (Folder == "User")
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
			}

			return null;
		}
	}
}
