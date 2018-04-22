using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl
{
    public static class Log4Net
    {
        private static readonly ILog Log =
             LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void WriteError(string error)
        {
            Log.Error(error);
        }
        public static void WriteException(Exception ex)
        {
            Log.Error(ex);
        }
        public static void WriteInfo(string info)
        {
            Log.Info(info);
        }
    }
}
