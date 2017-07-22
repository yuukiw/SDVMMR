using System;
namespace SDVMMR
{
	public class GitHub
	{
		public class GitRelease
		{
			public string tag_name { get; set; }
			public string name { get; set; }
			public string body { get; set; }
			public GitAsset[] assets { get; set; }
		}

		public class GitAsset
		{
			public string name { get; set; }
			public string content_type { get; set; }
			public string browser_download_url { get; set; }
		}

		public class Manifest
		{
			public string Name { get; set; }
			public string Author { get; set; }
			public ModVersion Version { get; set; }
			public string Description { get; set; }
			public string UniqueID { get; set; }
			public string PerSaveConfigs { get; set; }
			public string EntryDll { get; set; }
		}

		public class ModVersion
		{
			public int MajorVersion { get; set; }
			public int MinorVersion { get; set; }
			public int PatchVersion { get; set; }
			public string Build { get; set; }
		}
	}
}
