using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPull
{
    class Helpers
    {
        // writes a log to a log file
        public static void WriteLog(string line, string path = null)
        {
            if (null == path)
                path = Directory.GetCurrentDirectory();

            path += "/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "_log.txt";
            line = "\r\n" + Helpers.GetDateTime() + " " + line;
            System.IO.File.AppendAllText(path, line);
        }
        // writes message to console
        public static void WriteMessage(string s, bool log = false, string path = null)
        {
            Console.WriteLine(s);
            if (true == log)
                Helpers.WriteLog(s, path);
        }
        // self-explanetory ... can be shown to user (optional)
        public static void WriteError(string s, bool show = false)
        {
            s = "ERROR: " + s;
            Helpers.WriteLog(s);
            if (true == show)
                Console.WriteLine(s);
        }
        // self-explanetory ... allows append string for more info (optional)
        public static void LogMethod(string append = null)
        {

            // Get call stack
            StackTrace stackTrace = new StackTrace();
            Helpers.WriteLog("Method:: " + stackTrace.GetFrame(1).GetMethod().Name + " " + append);

        }
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
        }
    }
}
