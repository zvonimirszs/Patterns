using Model_Patterns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal_Pattern.Models
{
    public class WebApiConfig : Config
    {
        public override Dictionary<string, string> DictConfig { get; set; }

        public WebApiConfig(string path) : base(path)
        {

        }
    }
}
