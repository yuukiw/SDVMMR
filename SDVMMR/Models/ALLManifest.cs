using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVMMR.JSON_Dummies
{
    public class ALLManifest
    {
        public string LoaderVersion { get; set; }
        public About About { get; set; }
    }

    public class About
    {
        public string ModName { get; set; }
        public string Author { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }

}