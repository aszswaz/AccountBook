using System;
using System.IO;

namespace AccountBook.Utils {
    public class ConfigManager
    {
        private readonly static string BASE_DIR;
        public readonly static string DB_PATH;
        public readonly static string ICON_DIR;

        static ConfigManager()
        {
            BASE_DIR = AppDomain.CurrentDomain.BaseDirectory;
            DB_PATH = Path.Combine(BASE_DIR, "AccountBook.db");
            ICON_DIR = Path.Combine(BASE_DIR, "Icons");

            // 如果文件夹不存在，创建文件夹
            var dirInfo = new DirectoryInfo(BASE_DIR);
            if (!dirInfo.Exists) dirInfo.Create();
            dirInfo = new DirectoryInfo(ICON_DIR);
            if (!dirInfo.Exists) dirInfo.Create();
        }
    }
}
