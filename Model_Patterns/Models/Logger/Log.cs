using System;
using System.Collections.Generic;
using System.Text;
using Model_Patterns.Models.Content;

namespace Model_Patterns.Models.Logger
{
    public abstract class Log
    {
        public Content.Logger Logger { get; set; }
        //public abstract void InsertLog();

        public abstract void InsertLog(Model_Patterns.Models.Content.Logger log);

    }
}
