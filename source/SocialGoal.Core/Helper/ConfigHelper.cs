using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGoal.Core.Helper
{
    public class ConfigHelper
    {
        public static string LogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["LogPath"];
            }
        }
    }
}