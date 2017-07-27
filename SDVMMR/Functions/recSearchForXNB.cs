using System;
using System.IO;

namespace SDVMMR
{
	internal static class recSearchForXNB
	{
		internal static string SearchForXNB(string SourcePath, string searched)
		{
			string foundName = "";
			bool foundfile = false;
		
			DirectoryInfo SourceDir = new DirectoryInfo(SourcePath);
			int pathIndex;
			pathIndex = SourcePath.LastIndexOf("\\", StringComparison.Ordinal);
			// the source directory must exist, otherwise throw an exception
			if (SourceDir.Exists)
			{
				DirectoryInfo SubDir = new DirectoryInfo(SourcePath); //
				foreach (DirectoryInfo tempLoopVar_SubDir in SourceDir.GetDirectories("*", SearchOption.AllDirectories))
				{
					SubDir = tempLoopVar_SubDir;
					SearchForXNB(Path.Combine(@SourcePath + SubDir.Name, ""), searched);
				}


				foreach (FileInfo childFile in SourceDir.GetFiles(searched, SearchOption.AllDirectories))
				{
					if (foundfile == false)
					{
						foundName = childFile.FullName;
						foundfile = true;
					}
					else
					{
						return "";
					}
				}
			}
			else
			{
				Message msg = new Message("Source directory does not exist: " + SourceDir.FullName, "Not Found!");
			}
			return foundName;
		}
	}
}
