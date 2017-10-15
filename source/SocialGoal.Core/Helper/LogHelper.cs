using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGoal.Core.Helper
{
    public class LogHelper
    {
        private static string LogPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Log/");

        public static void WriteLog(string fileName, string Content)
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            string filePath = $"{LogPath}/{fileName}.log";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"紀錄時間:{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}");
            sb.AppendLine($"內容:{Content}");
            File.AppendAllText(filePath, sb.ToString());
        }
    }
}