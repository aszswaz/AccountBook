using LiteDB;

namespace AccountBook.Entity {
    /**
     * 钱包的信息，比如微信、支付宝、银行卡等
     */
    public class Wallet {
        public ObjectId? Id { get; set; }
        /**
         * 钱包图标
         */
        public string? Icon { get; set; }
        // 钱包名称
        public string? Name { get; set; }
        // 钱包余额
        public decimal? Balance { get; set; }
        // 创建时间
        public long? createTime { get; set; }
        // 修改时间
        public long? updateTime { get; set; }

        public override string ToString() {
            return " Id: " + Id
                + " Icon: " + Icon
                + " Name: " + Name
                + " Balance: " + Balance
                + " createTime: " + createTime
                + " updateTime: " + updateTime;
        }
    }
}
