using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace System.IO
{
	public static class DirectoryInfoExtensions
	{
		internal static void MoveMod(this DirectoryInfo source, DirectoryInfo target)
		{
			if (!target.Exists)
				target.Create();

			foreach (var file in source.GetFiles())
				file.CopyTo(Path.Combine(target.FullName, file.Name), true);

			foreach (var subdir in source.GetDirectories())
				subdir.MoveMod(target.CreateSubdirectory(subdir.Name));
		}

		internal static void CopyMod(this DirectoryInfo source, DirectoryInfo target)
		{
			if (!target.Exists)
				target.Create();

			foreach (var file in source.GetFiles())
				file.CopyTo(Path.Combine(target.FullName, file.Name), true);

			foreach (var subdir in source.GetDirectories())
				subdir.CopyMod(target.CreateSubdirectory(subdir.Name));
		}
		internal static void CreateXLoaderStruct(this DirectoryInfo source, DirectoryInfo target)
		{
			if (!target.Exists)
				target.Create();



			foreach (var subdir in source.GetDirectories())
				subdir.CreateXLoaderStruct(target.CreateSubdirectory(subdir.Name));
		}
	}



}