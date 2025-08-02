using AccountBook.Local;
using System;
using System.Collections.Generic;
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

namespace AccountBook.Component {
    /// <summary>
    /// Interaction logic for WalletTable.xaml
    /// </summary>
    public partial class WalletTable : UserControl {
        public WalletTable() {
            InitializeComponent();
            this.Init();
        }

        private void Init() {
            // 注册 Window 加载事件
            this.Loaded += (sender, e) => this.LoadWallets();
            // 注册钱包数据更新事件
            Utils.EventManager.WalletsUpdated += this.LoadWallets;
        }

        /**
         * 打开创建钱包的窗口
         */
        private void NewWallet(object sender, RoutedEventArgs e) {
            new WalletWindow().ShowDialog();
        }

        /**
         * 将钱包添加到窗口
         */
        private void LoadWallets() {
            var wallets = WalletCollection.GetAllWallets();
            WalletsPanel.Children.Clear();
            // 钱包数据显示到页面
            foreach (var item in wallets) {
                var walletComponent = new WalletElement(item);
                WalletsPanel.Children.Add(walletComponent);
            }
        }
    }
}
