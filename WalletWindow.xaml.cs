using System;
using System.Windows;
using Microsoft.Win32;

using AccountBook.Local;
using AccountBook.Utils;

namespace AccountBook {
    public partial class WalletWindow : Window {
        private Wallet wallet;
        private string? newIcon = null;

        public WalletWindow(Window main) : this(main, null) { }

        public WalletWindow(Window main, Wallet? wallet) {
            InitializeComponent();
            this.Owner = main;

            if (wallet != null) {
                this.wallet = wallet;
                if (wallet.Icon != null) WalletIcon.Source = IconManager.GetBitmapImage(wallet.Icon);
                WalletNameText.Text = wallet.Name;
                WalletBalanceText.Value = wallet.Balance;
            } else {
                this.wallet = new Wallet();
            }
        }

        /**
         * 保存钱包信息
         */
        private void CreateOrUPdate(object sender, RoutedEventArgs e) {
            try {
                var name = WalletNameText.Text;
                var balance = WalletBalanceText.Text;

                if (string.IsNullOrWhiteSpace(name)) throw new Exception("名称不能为空");
                if (string.IsNullOrWhiteSpace(balance)) throw new Exception("余额不能为空");
                if (name.Length > 20) throw new Exception("名称长度不能大于 20");
                if (balance.Length > 20) throw new Exception("余额长度不能大于 20");

                // 如果用户修改了图标，将其保存到指定目录和数据库
                if (!string.IsNullOrEmpty(this.newIcon)) {
                    // 删除旧的图标
                    IconManager.DeleteIcon(this.wallet.Icon);
                    this.wallet.Icon = IconManager.AddIcon(this.newIcon);
                }

                // 将更新后的信息保存到数据库
                this.wallet.Name = name;
                this.wallet.Balance = decimal.Parse(balance);
                WalletCollection.InsertOrUpdateWallet(this.wallet);

                Utils.EventManager.SendUpdateWallets();
                Close();
            } catch (Exception ex) {
                DialogUtil.Error(ex.Message);
            }
        }

        /**
         * 选择钱包的图标
         */
        private void SelectIcon(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog() {
                Title = "选择钱包的图标",
                Filter = "JPEG（*.jpg）|*.jpg",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            if (ofd.ShowDialog() != true) return;
            this.newIcon = ofd.FileName;
            WalletIcon.Source = IconManager.GetBitmapImageByFullPath(ofd.FileName);
        }
    }
}
