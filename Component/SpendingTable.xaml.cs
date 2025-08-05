using AccountBook.Entity;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AccountBook.Component {
    /// <summary>
    /// Interaction logic for SpendingTable.xaml
    /// </summary>
    public partial class SpendingTable : UserControl {
        public ObservableCollection<ExpensesBillView> Data { get; set; } = new ObservableCollection<ExpensesBillView>();

        public SpendingTable() {
            this.DataContext = this;
            InitializeComponent();
        }

        /**
         * 添加新数据
         */
        public void NewData(object sender, RoutedEventArgs e) {
            var window = new ExpensesBillWindow();
            window.ShowDialog();
        }
    }
}
