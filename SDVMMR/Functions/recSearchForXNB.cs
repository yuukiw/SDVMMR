using System;
using System.IO;
using System.Linq;

namespace SDVMMR
{
	internal static class recSearchForXNB
	{


		internal static string recXNB(string SourcePath, string search)
		{
			var x = Directory.GetFiles(SourcePath,search,SearchOption.AllDirectories).ToList();
			return x.Count==1 ? System.IO.Path.GetFullPath(x[0]): "";
		} 


	}
}
