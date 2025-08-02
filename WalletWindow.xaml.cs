using System;
using System.Windows;
using Microsoft.Win32;

using AccountBook.Local;

namespace AccountBook {
    public partial class WalletWindow : Window {
        public Wallet? oldWallet = null;
        public string? newIcon = null;

        public WalletWindow(Window main) : this(main, null) { }

        public WalletWindow(Window main, Wallet? wallet) {
            InitializeComponent();
            this.Owner = main;
            this.oldWallet = wallet;
            this.Init();

        }

        private void Init() {
            if (oldWallet == null) return;
            if (oldWallet.Icon != null) {
                WalletIcon.Source = IconManager.GetBitmapImage(oldWallet.Icon);
            }
            WalletNameText.Text = oldWallet.Name;
            WalletBalanceText.Text = oldWallet.Balance.ToString();
        }

        /**
         * 保存钱包信息
         */
        private void CreateOrUPdate(object sender, RoutedEventArgs e) {
            try {
                var name = WalletNameText.Text;
                var balance = WalletBalanceText.Text;
                var newWallet = new Wallet();

                if (string.IsNullOrWhiteSpace(name)) throw new Exception("名称不能为空");
                if (string.IsNullOrWhiteSpace(balance)) throw new Exception("余额不能为空");
                if (name.Length > 20) throw new Exception("名称长度不能大于 20");
                if (balance.Length > 20) throw new Exception("余额长度不能大于 20");

                // 如果用户修改了图标，将其保存到指定目录和数据库
                if (!string.IsNullOrEmpty(this.newIcon)) {
                    var newIcon = IconManager.AddIcon(this.newIcon);
                    newWallet.Icon = newIcon;
                    // 删除旧的图标
                    if (this.oldWallet != null && this.oldWallet.Icon != null)
                        IconManager.DeleteIcon(this.oldWallet.Icon);
                }

                newWallet.Name = name;
                newWallet.Balance = double.Parse(balance);
                WalletCollection.InsertOrUpdateWallet(newWallet);
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
