using AccountBook.Local;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SpendingTable.xaml
    /// </summary>
    public partial class SpendingTable : UserControl {
        public ObservableCollection<ExpensesBill> Data { get; set; } = new ObservableCollection<ExpensesBill>();

        public SpendingTable() {
            this.DataContext = this;
            InitializeComponent();

            Data.Add(new ExpensesBill {
                ConsumptionDate = 100,
                CommodityName = "Demo",
                ConsumptionType = "DemoType",
                UnitPrice = 10,
                Quantity = 100,
                TotalPrices = 1000
            });

            Data.Add(new ExpensesBill {
                ConsumptionDate = 100,
                CommodityName = "Demo",
                ConsumptionType = "DemoType",
                UnitPrice = 10,
                Quantity = 100,
                TotalPrices = 1000
            });
        }
    }
}
