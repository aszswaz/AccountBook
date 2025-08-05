using AccountBook.Utils;
using System;
using System.Windows;

namespace AccountBook.Component {
    public partial class ExpensesBillWindow : Window {
        public ExpensesBillWindow() {
            InitializeComponent();
            this.Owner = Application.Current.MainWindow;
            ConsumptionDate.SelectedDate = DateTime.Now;
        }

        private void Save(object sender, RoutedEventArgs e) {
            try {
                var consumptionDate = ConsumptionDate.SelectedDate;
                if (consumptionDate == null) throw new Exception("日期不能为空");
            } catch (Exception ex) {
                DialogUtil.Error(ex.Message);
            }
        }
    }
}
