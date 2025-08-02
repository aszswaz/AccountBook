using LiteDB;

namespace AccountBook.Local {
    /**
     * 支出账单
     */
    public class ExpensesBill {
        public ObjectId? Id;
        // 消费日期
        public long? Timestamp = 0;
        // 商品名称
        public string? CommodityName;
        // 消费类型
        public string? ConsumptionType;
        // 商品单价
        public double? UnitPrice;
        // 商品数量
        public int? Quantity;
        // 商品总价
        public double? TotalPrices;
        // 付款钱包的 ID
        public ObjectId? WalletId;
    }
}
