using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace BSLHRAPI.Models
{
    public class Generic
    {

    }
    public static class Logger
    {
        public static void WriteLog(string FunctionName, string message, StackTrace stStrack)
        {
            string LogPath = ConfigurationManager.AppSettings["logPath"] + System.DateTime.Today.ToString("dd-MM-yyyy") + "." + "txt";
            FileInfo LogFileInfo = new FileInfo(LogPath);
            DirectoryInfo LogDirInfo = new DirectoryInfo(LogFileInfo.DirectoryName);
            if (!LogDirInfo.Exists) LogDirInfo.Create();
            using (FileStream fileStream = new FileStream(LogPath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    //var st = new StackTrace(true);
                    StackFrame frame = null;
                    int LineNumber = 0;
                    for (int i = 0; i < stStrack.FrameCount; i++)
                    {
                        frame = stStrack.GetFrame(i);
                        if (frame.GetFileLineNumber() > 0)
                        {
                            LineNumber = frame.GetFileLineNumber();
                            break;
                        }
                    }
                    log.WriteLine($"{DateTime.Now} : {FunctionName} {LineNumber} {message}");
                }
            }
        }
    }
}