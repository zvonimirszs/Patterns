using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Interfaces
{
    public interface IConfiguration
    {
        Dictionary<string, string> DictConfig { get; set; }

    }
}
