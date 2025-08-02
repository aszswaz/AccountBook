using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

using AccountBook.Utils;

namespace AccountBook.Local {
    public class WalletCollection {
        private static ILiteCollection<Wallet> collection;

        static WalletCollection() {
            collection = LiteDBUtil.GetCollection<Wallet>("wallets");
        }

        /**
         * 创建或更新钱包
         */
        public static void InsertOrUpdateWallet(Wallet wallet) {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (wallet.Id == null) {
                // 数据不存在于数据库中，只要确认钱包名称不重复就保存到数据库
                if (FindWalletByName(wallet.Name) != null)
                    throw new Exception("钱包" + wallet.Name + "已存在");
                wallet.createTime = timestamp;
                wallet.updateTime = timestamp;
                collection.Insert(wallet);
            } else {
                // 数据已存在于数据库中，仅更新数据，如果用户修改了钱包名称，要确保新名称不重复
                var oldWallet = collection.FindById(wallet.Id);
                if (oldWallet == null) throw new Exception("不存在的 ID" + wallet.Id.ToString());
                if (oldWallet.Name != wallet.Name) {
                    if (FindWalletByName(wallet.Name) != null)
                        throw new Exception("钱包" + wallet.Name + "已存在");
                }
                wallet.updateTime = timestamp;
                collection.Update(wallet);
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
