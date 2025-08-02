using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace AccountBook.Local {
    public class WalletCollection {
        private static ILiteCollection<Wallet> collection;

        static WalletCollection() {
            collection = LiteDBUtil.GetCollection<Wallet>("wallets");
        }

        /**
         * 创建或更新钱包
         */
        public static void InsertOrUpdateWallet(Wallet newWallet) {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var oldWallet = FindWalletByName(newWallet.Name);

            if (oldWallet == null) {
                newWallet.createTime = timestamp;
                newWallet.updateTime = timestamp;
                collection.Insert(newWallet);
            } else {
                if (newWallet.Icon != null) oldWallet.Icon = newWallet.Icon;
                if (newWallet.Name != null) oldWallet.Name = newWallet.Name;
                if (newWallet.Balance != null) oldWallet.Balance = newWallet.Balance;
                oldWallet.updateTime = timestamp;
                collection.Update(oldWallet);
            }
        }

        public static Wallet? FindWalletByName(string? name) {
            if (name == null) return null;
            return collection.FindOne(d => d.Name == name);
        }

        public static List<Wallet> GetAllWallets() {
            return collection.FindAll().ToList();
        }
    }
}
