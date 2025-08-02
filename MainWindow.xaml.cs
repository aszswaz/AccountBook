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
using AccountBook.Component;
using AccountBook.Local;
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
