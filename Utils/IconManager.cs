using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using AccountBook.Utils;

namespace AccountBook.Utils {
    public class IconManager {
        public static string AddIcon(string iconFile) {
            var newIcon = Guid.NewGuid().ToString() + ".jpg";
            File.Copy(iconFile, FullPath(newIcon));
            return newIcon;
        }

        public static void DeleteIcon(string? icon) {
            if (icon == null) return;
            var fullPath = FullPath(icon);
            File.Delete(fullPath);
        }

        public static BitmapImage GetBitmapImage(string icon) {
            return GetBitmapImageByFullPath(FullPath(icon));
        }

        public static BitmapImage GetBitmapImageByFullPath(string fullPath) {
            var bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            using (Stream ms = new MemoryStream(File.ReadAllBytes(fullPath))) {
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                bitmap.Freeze();
            }

            return bitmap;
        }

        private static string FullPath(string fileName) {
            return ConfigManager.ICON_DIR + "\\" + fileName;
        }
    }
}
