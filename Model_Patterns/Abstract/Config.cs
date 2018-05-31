using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Model_Patterns.Abstract
{
    public abstract class Config
    {
        public abstract Dictionary<string, string> DictConfig { get; set; }
        protected Config(string path)
        {
            Dictionary<string, string> DictConfig = new Dictionary<string, string>();
            try
            {
                XElement docx = XElement.Load(path);
                IEnumerable<XElement> appSettings =
                from el in docx.Elements("appSettings")
                select el;
                IEnumerable<XElement> add =
                from ell in appSettings.Elements("add")
                select ell;
                foreach (XElement ell in add)
                    DictConfig.Add((string)ell.Attribute("key"), (string)ell.Attribute("value"));

                this.DictConfig = DictConfig;
            }
            catch (Exception)
            {

            }
        }
    }
}
