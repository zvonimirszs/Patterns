using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns
{
    public class Enumerations
    {
        public enum Dao
        {
            Sql,
            WebApi
        };

        public enum Cache
        {
            Http            
        };

        public enum Logger
        {
            Db,
            File
        }

        public enum Reporting
        {
            Pdf,
            Html
        }
    }
}
