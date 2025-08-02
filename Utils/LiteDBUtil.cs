using LiteDB;

namespace AccountBook.Utils {
    public static class LiteDBUtil {
        private static readonly LiteDatabase DB;

        static LiteDBUtil() {
            DB = new LiteDatabase(ConfigManager.DB_PATH);
        }

        public static void Close() {
            DB.Dispose();
        }

        public static ILiteCollection<T> GetCollection<T>(string name) {
            return DB.GetCollection<T>(name);
        }
    }
}
