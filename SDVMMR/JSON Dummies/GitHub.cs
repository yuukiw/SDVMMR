using System;
using Newtonsoft.Json;

namespace SDVMMR
{
public class GitRelease
{
	public string Name { get; set; }

	[JsonProperty("tag_name")]
	public string TagName { get; set; }

	[JsonProperty("draft")]
	public bool IsDraft { get; set; }

	[JsonProperty("prerelease")]
	public bool IsPreRelease { get; set; }

	[JsonProperty("assets")]
	public GitDownload[] Downloads { get; set; }
}

public class GitDownload
{
	public string Name { get; set; }

	[JsonProperty("created_at")]
	public DateTime Created { get; set; }

	[JsonProperty("browser_download_url")]
	public string DownloadUrl { get; set; }
}
}
