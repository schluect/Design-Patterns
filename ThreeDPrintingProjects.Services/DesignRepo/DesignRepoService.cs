using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ThreeDPrintingProjects.Services.DesignRepo.Model;

namespace ThreeDPrintingProjects.Services.DesignRepo
{
    public class DesignRepoService: IDesignRepoService
    {
        public IDictionary<int, Design> ThingiverseDesigns
        {
            get
            {
                if (_thingiverseDesigns == null)
                {
                    PopulateThingiverseDesigns();
                }
                return _thingiverseDesigns;
            }
            set { _thingiverseDesigns = value; }
        }

        private void PopulateThingiverseDesigns()
        {
            _thingiverseDesigns =
                    JsonConvert.DeserializeObject<List<Design>>(
                        File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(thingiverseJsonFile))).ToDictionary(x=>x.Id, y=>y);
        }

        private string thingiverseJsonFile = "~/scripts/thingiverse.json";
        private IDictionary<int, Design> _thingiverseDesigns;

        public List<Design> SearchForDesigns(string keyword)
        {
            if (keyword == null)
            {
                keyword = "";
            }

            return ThingiverseDesigns.Values.Where(x => x.Name.Contains(keyword)).ToList();
        }

        public Design GetById(int id)
        {
            if (id == 0 && !ThingiverseDesigns.ContainsKey(id))
            {
                return null;
            }

            return ThingiverseDesigns[id];
        }

        public string Authenticate(string code)
        {
            throw new NotImplementedException();
        }
    }
}
