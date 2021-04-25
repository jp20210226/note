using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GetResources
{
    public class ResourcesData
    {
        public int code { get; set; }
        public string message { get; set; }
        public Data[] data { get; set; }

    }

    public class Data 
    {
        public string file_url { get; set; }
        public string model_id { get; set; }
        public string md5 { get; set; }

    }

}
