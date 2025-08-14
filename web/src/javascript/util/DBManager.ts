import WalletTable from "./WalletTable"
import { WALLET_TABLE } from "./TableNames"


export default class DBManager {
    private static isClosed: boolean = false;
    private static db: IDBDatabase | null = null;
    // 存储钱包信息的表格
    private static walletTable: WalletTable | null;

    private constructor() { }

    private static openDB(): Promise<void> {
        return new Promise((resolve, reject) => {
            if (!(this.db && !this.isClosed)) {
                const result = indexedDB.open("AccountBook", 1)
                result.onsuccess = (event: any) => {
                    this.db = event.target.result
                    this.isClosed = false
                    // 无论有没有值需要返回，都要调用 resolve，否则 WEB 会直接被阻塞
                    resolve()
                }
                result.onerror = (event: any) => {
                    reject(`无法打开数据库：${event.target.error}`)
                }
                // 初始化数据库
                result.onupgradeneeded = (event: any) => {
                    const db: IDBDatabase = event.target.result;
                    if (!db.objectStoreNames.contains(WALLET_TABLE)) {
                        db.createObjectStore(WALLET_TABLE, {
                            keyPath: "id",
                            autoIncrement: true
                        });
                    }
                }
            }
        })
    }

    public static async openWalletTable(): Promise<WalletTable> {
        if (this.walletTable && !this.isClosed) return this.walletTable;

        await this.openDB();
        if (!this.db) throw "无法打开 indexDB"
        this.walletTable = new WalletTable(this.db);
        return this.walletTable;
    }

    public static close() {
        this.db?.close()
        this.db = null
        this.walletTable = null
    }
}