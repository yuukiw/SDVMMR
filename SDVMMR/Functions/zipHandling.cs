﻿using System;
using System.IO;
using System.IO.Compression;

namespace SDVMMR
{
	public class zipHandling
	{
		public void extractZip(string sourcePath, string destPath)
		{
			System.IO.Compression.ZipFile.ExtractToDirectory(sourcePath,destPath);
		}
	}
}
