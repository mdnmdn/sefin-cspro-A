using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Sefin.CsProA.WebApp.Libs
{
    public class GlobalConfiguration
    {
        static GlobalConfiguration _instance = new GlobalConfiguration();

        public static GlobalConfiguration Instance { get { return _instance; } }

        private GlobalConfiguration()
        {
            this.Environment = (ConfigurationManager.AppSettings["Environment"] ?? "debug").ToLower();

            StartupDate = DateTime.Now;

            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            Version = asm.GetName().Version.ToString();
            var asmFile = new System.IO.FileInfo(asm.Location);


            if (asmFile.Exists)
            {
                BuildDate = asmFile.LastWriteTime;
            }

            //    this.DB = ParseConnectionString();
        }

        private static string ParseConnectionString()
        {
            var db = "-";
            try
            {
                var conn = ConfigurationManager.ConnectionStrings["DataConnection"];
                if (conn != null)
                {
                    var connString = conn.ConnectionString.ToLower();
                    int start = connString.IndexOf("database=");
                    if (start > 0)
                    {
                        connString = connString.Substring(start + "database=".Length);
                        var end = connString.IndexOf(";");
                        if (end > 0) db = connString.Substring(0, end);
                        else db = connString;
                    }
                }
            }
            catch { }
            return db;
        }


        public string Version { get; private set; }
        public DateTime BuildDate { get; private set; }
        public DateTime StartupDate { get; private set; }

        public string Environment { get; private set; }

        public string DB { get; private set; }
    }
}