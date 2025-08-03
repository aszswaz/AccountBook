using LiteDB;

namespace AccountBook.Local {
    /**
     * 支出账单
     */
    public class ExpensesBill {
        public ObjectId? Id { get; set; }
        // 消费日期
        public long? ConsumptionDate { get; set; }
        // 商品名称
        public string? CommodityName { get; set; }
        // 消费类型
        public string? ConsumptionType { get; set; }
        // 商品单价
        public decimal? UnitPrice { get; set; }
        // 商品数量
        public int? Quantity { get; set; }
        // 商品总价
        public decimal? TotalPrices { get; set; }
        // 付款钱包的 ID
        public ObjectId? WalletId { get; set; }
    }
}
