using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVMMR
{
    internal class ModInfoModel
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The mod name.</summary>
        public string Name { get; set; }

        /// <summary>The mod's semantic version number.</summary>
        public string Version { get; set; }

        /// <summary>The mod's web URL.</summary>
        public string Url { get; set; }

        /// <summary>The error message indicating why the mod is invalid (if applicable).</summary>
        public string Error { get; set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an empty instance.</summary>
        public ModInfoModel()
        {
            // needed for JSON deserialising
        }


        /// <summary>Construct an instance.</summary>
        /// <param name="name">The mod name.</param>
        /// <param name="version">The mod's semantic version number.</param>
        /// <param name="url">The mod's web URL.</param>
        /// <param name="error">The error message indicating why the mod is invalid (if applicable).</param>
        public ModInfoModel(string name, string version, string url, string error = null)
        {
            this.Name = name;
            this.Version = version;
            this.Url = url;
            this.Error = error; // mainly initialised here for the JSON deserialiser
        }

        /// <summary>Construct an instance.</summary>
        /// <param name="error">The error message indicating why the mod is invalid.</param>
        public ModInfoModel(string error)
        {
            this.Error = error;
        }
    }
}
