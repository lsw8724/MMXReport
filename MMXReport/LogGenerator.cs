using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo.Logger;
using System.Windows.Forms;

namespace MMXReport
{
    public enum LogType {Common,SQLQuery,Exception}
    public static class LogGenerator
    {
        public static string SavePath { get; set; }
        public static string FilePath { get; set; }

        private static void CreateLogDirectory()
        {
            SavePath = Application.StartupPath + "\\Log";
            if(!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);
        }

        public static void CreateLogFile()
        {
            CreateLogDirectory();
            string fileName = DateTime.Now.ToString("yyyy-MM-dd");
            FilePath = SavePath + "\\" + fileName + ".txt";
            if (!File.Exists(FilePath))
                using (StreamWriter writer = new StreamWriter(File.Open(FilePath, FileMode.Create)))
                { 
                    writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") +  " 로그파일 생성");
                }
        }

        public static void AppendLog(string log, LogType type, object obj = null)
        {
            using (StreamWriter writer = new StreamWriter(File.Open(FilePath, FileMode.Append)))
            {
                writer.Write(DateTime.Now.ToString() + " : [" + type + "] " + log);
                if (obj != null) writer.WriteLine(" "+obj.ToString());
            }
        }

  
    }
}
