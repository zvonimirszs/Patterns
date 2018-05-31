using Model_Patterns.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Models
{
    public class AppConfig : Config
    {
        public override Dictionary<string, string> DictConfig { get; set; }

        public AppConfig(string path) : base(path)
        {

        }
    }
}