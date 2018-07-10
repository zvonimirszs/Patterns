using Model_Patterns.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patterns.Models
{
    public class ExceptionHandler
    {
        public static bool Handle(Exception ex)
        {
            // upisati u log i obavjestiti developera i admina mailom
            if (ex.GetType() == typeof(CacheProviderException))
                return true;
            // upisati u log i obavjestiti developera i admina mailom
            if (ex.GetType() == typeof(DataProviderException))
                return true;
            // upisati u log i obavjestiti developera mailom
            if (ex.GetType() == typeof(DocumentException))
                return true;
            // upisati u log i obavjestiti developera i admina mailom
            if (ex.GetType() == typeof(ConfigurationException))
                return true;
            // upisati u log i obavjestiti developera mailom
            if (ex.GetType() == typeof(NotImplementedException))
                return true;
            // upisati u log i obavjestiti developera mailom
            if (ex.GetType() == typeof(ArgumentNullException))
                return true;
            // upisati u log i obavjestiti developera mailom
            if (ex.GetType() == typeof(Exception))
                return true;

            return false;
        }
    }
}