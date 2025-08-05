using System.ComponentModel;
using System.Windows;
using AccountBook.Utils;

/**
 * 用于管理收支明细的软件
 */
namespace AccountBook {
    public partial class MainWindow : Window {
        public MainWindow() {
            this.DataContext = this;
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            LiteDBUtil.Close();
        }
    }
}
