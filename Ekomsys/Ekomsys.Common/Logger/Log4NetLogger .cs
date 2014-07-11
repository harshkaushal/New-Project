using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAGreenCard.Common.Logger
{
    using log4net;
    public static class Log4NetLogger 
    {
        private static readonly ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Log(string message, params object[] args)
        {
            _log.Info(string.Format(message, args));
        }
        public static void Error(string message)
        {
            _log.Error(message);
        }
        public static void Debug(string message)
        {
            _log.Debug(message);            
        }
        public static void Fatal(String Message, Exception ex)
        {
            _log.Fatal(Message, ex);
        }
    
    }
    
}
