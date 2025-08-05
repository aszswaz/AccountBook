using System;

using AccountBook.Entity;

namespace AccountBook.Utils {
    /**
     * 钱包的数据更新事件
     */
    public delegate void WalletsUpdateEvent();

    public class EventManager {
        public static event WalletsUpdateEvent? WalletsUpdated;

        public static void SendUpdateWallets()
            => WalletsUpdated?.Invoke();
    }
}
