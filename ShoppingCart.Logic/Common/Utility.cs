using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Logic.Common
{
    public static class Utility
    {
        public static void WriteLog(Exception ex)
        {
            if (ex != null)
            {
                string path = Path.Combine(ConfigurationManager.AppSettings["LogPath"],DateTime.Now.Date.ToShortDateString(), ".log");
                
                string error = Environment.NewLine + DateTime.Now +
                    "--------------------" + ex.Message + Environment.NewLine + ex.StackTrace +
                    Environment.NewLine + ex.InnerException + "-------------------------"
                    + Environment.NewLine;

                File.AppendAllText(path, error);
            }
        }
    }
}
