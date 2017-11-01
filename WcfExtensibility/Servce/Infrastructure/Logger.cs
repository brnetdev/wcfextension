using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Infrastructure
{
    public static class Logger
    {
        private static object _sync = new object();

        public static void Log(string text)
        {

            lock(_sync)
            {
                var sw = File.AppendText(@"d:\logs");
                sw.WriteLine(text);
                sw.Flush();
                sw.Close();

            }
        }
    }
}
