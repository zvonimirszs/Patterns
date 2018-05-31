using Model_Patterns.Models.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Patterns.Providers
{
    public class LoggerProvider : Log
    {
        private Log _IProviderLogger = null;
        public LoggerProvider(Enumerations.Logger logType)
        {

            if (logType == Enumerations.Logger.Db)
            {
                if (_IProviderLogger == null)
                    _IProviderLogger = (Log)Activator.CreateInstance(typeof(DbLogger));

            }
            else if (logType == Enumerations.Logger.File)
            {
                if (_IProviderLogger == null)
                    _IProviderLogger = (Log)Activator.CreateInstance(typeof(FileLogger));
            }
            else
            {
                if (_IProviderLogger == null)
                    _IProviderLogger = (Log)Activator.CreateInstance(typeof(FileLogger));
            }
        }
        public override void InsertLog(Model_Patterns.Models.Content.Logger log)
        {
            _IProviderLogger.InsertLog(log);
        }
    }
}
