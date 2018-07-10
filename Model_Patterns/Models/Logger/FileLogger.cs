using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Model_Patterns.Models.Content;

namespace Model_Patterns.Models.Logger
{
    public class FileLogger : Log
    {
        public override void InsertLog(Content.Logger log)
        {
            string sPath = String.Format("{0}_{1}_{2}_{3}.txt", @"d:\Log", log.PageId.ToString(), log.DocumentKey.ToString(), log.Date.ToString("yyyyMMddTHHmmss"));
            File.WriteAllText(sPath, log.ToString());
        }
    }
}
