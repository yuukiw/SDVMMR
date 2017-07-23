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
	}
}
