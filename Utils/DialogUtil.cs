using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountBook.Utils {
    public class DialogUtil {
        public static void Error(string? msg) {
            msg = (msg == null || msg.Length == 0) ? "未知错误" : msg;
            MessageBox.Show(msg, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
