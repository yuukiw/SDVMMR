using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVMMR.Functions
{
    class ModUpdateHandler
    {
        public async void CheckModUpdateAsync(string address)
        {
            // Setup the configuration to support document loading
            var config = Configuration.Default.WithDefaultLoader();
            // Asynchronously get the document in a new context using the configuration
            var document = await BrowsingContext.New(config).OpenAsync(address);
            var nodes = document.QuerySelectorAll(".downloadbutton a.inner");
            if (nodes.Length > 0 && nodes[0].HasAttribute("href"))
            {
                string url = nodes[0].GetAttribute("href");
                // Do stuff with the url
            }
            else
            {
                // We cant get the url for some reason or another, do something else?
            }
        }

    }
}
