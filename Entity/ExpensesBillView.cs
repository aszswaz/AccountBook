using LiteDB;
using System;

namespace AccountBook.Entity {
    /**
     * 支出账单的页面视图对象
     */
    public class ExpensesBillView {
        /**
         * 关联的 DAO 对象
         */
        public ExpensesBill dao{ get; set; }
        // 消费日期
        public DateTime? ConsumptionDate { get; set; }
        // 商品名称
        public string? CommodityName { get; set; }
        // 消费类型
        public string? ConsumptionType { get; set; }
        // 商品单价
        public decimal? UnitPrice { get; set; }
        // 商品数量
        public decimal? Quantity { get; set; }
        // 商品总价
        public decimal? TotalPrices { get; set; }
        // 付款的钱包名称
        public string? WalletName { get; set; }

        public ExpensesBillView(ExpensesBill dao) {
            this.dao = dao;
        }
    }
}
