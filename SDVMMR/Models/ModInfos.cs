using System;
namespace SDVMMR
{
	public class ModInfos
	{
        public class Infos
        {
            public string name { get; set; }
            public string author { get; set; }
            public string version { get; set; }
            public string website { get; set; }
            public string UniqueID { get; set; }
            public string[] UpdateKeys { get; set; }
			public string MinimumApiVersion { get; set; }
			public string Description { get; set; }
			public bool isActive { get; set; }
			public bool isXNB { get; set; }
			public string orgXNBpath { get; set; }
            public bool isALL { get; set; }            
		}
	}
}

