using AccountBook.Local;
using AccountBook.Utils;
using System.Windows.Controls;

namespace AccountBook.Component {
    /// <summary>
    /// Interaction logic for WalletComponent.xaml
    /// </summary>
    public partial class WalletElement : UserControl {
        private Wallet wallet;

        public WalletElement(Wallet wallet) {
            InitializeComponent();
            this.wallet = wallet;

            this.init();
        }

        private void init() {
            if (this.wallet.Icon != null) {
                WalletIcon.Source = IconManager.GetBitmapImage(this.wallet.Icon);
            }
            WalletNameText.Content = this.wallet.Name;
            WalletBalanceText.Content = this.wallet.Balance;
        }
    }
}
