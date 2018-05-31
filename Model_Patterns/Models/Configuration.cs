using Model_Patterns.Abstract;
using Model_Patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Models
{
    public class Configuration : Config
    {
        public override Dictionary<string, string> DictConfig { get; set; }

        public Configuration(string path) : base(path)
        {

        }
    }
}
