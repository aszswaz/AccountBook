using AccountBook.Local;
using AccountBook.Utils;
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
    /// Interaction logic for WalletComponent.xaml
    /// </summary>
    public partial class WalletComponent : UserControl {
        private Wallet wallet;

        public WalletComponent(Wallet wallet) {
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
