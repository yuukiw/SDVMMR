using System;
namespace SDVMMR
{
	public class ModManifestOld
	{
		public string Name  { get; set; }
		public string Author  { get; set; }
		public ModVersion Version  { get; set; }
		public string Description  { get; set; }
		public string UniqueID  { get; set; }
		public string MinimumApiVersion  { get; set; }
		public string EntryDll  { get; set; }
	}

	public class ModVersion
	{
		public int MajorVersion  { get; set; }
		public int MinorVersion  { get; set; }
		public int PatchVersion { get; set; }
		public string Build { get; set; }
	}
}
