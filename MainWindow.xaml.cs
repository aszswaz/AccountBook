using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AccountBook.Local;

/**
 * 用于管理收支明细的软件
 */
namespace AccountBook {
    public partial class MainWindow : Window {
        public MainWindow() {
            this.DataContext = this;
            InitializeComponent();
            this.Loaded += (sender, e) => {
                this.LoadWallets();
            };
        }

        /**
         * 打开创建钱包的窗口
         */
        private void NewWallet(object sender, RoutedEventArgs e) {
            var window = new WalletWindow(this);
            window.ShowDialog();
        }

        /**
         * 将钱包添加到窗口
         */
        private void LoadWallets() {
            var wallets = WalletCollection.GetAllWallets();
            foreach (var item in wallets) {
                // TODO: 钱包数据显示到页面
            }
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            LiteDBUtil.Close();
        }
    }
}
