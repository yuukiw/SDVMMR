﻿namespace SDVMMR
{
	public class zipHandling
	{
		internal static void extractZip(string sourcePath, string destPath)
		{
			System.IO.Compression.ZipFile.ExtractToDirectory(sourcePath,destPath);
		}
	}
}
