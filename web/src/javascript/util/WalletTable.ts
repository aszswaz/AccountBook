import Wallet from "../entity/Wallet"
import { WALLET_TABLE } from "./TableNames"

export default class WalletTable {
    private db: IDBDatabase;

    constructor(db: IDBDatabase) {
        this.db = db;
    }

    public findAll(): Promise<Wallet[]> {
        return new Promise((resolve, reject) => {
            this.db.transaction(WALLET_TABLE, "readwrite").objectStore(WALLET_TABLE)
            const request: IDBRequest = this.getStore().getAll();
            request.onerror = (event: any) => reject(event.target.error)
            request.onsuccess = (event: any) => {
                const wallets: Wallet[] = []
                const data = event.target.result
                for (const element of data) {
                    wallets.push(Wallet.build(element))
                }
                resolve(wallets)
            }
        })
    }

    public insetrOne(data: Wallet): Promise<Wallet> {
        return new Promise((resolve, reject) => {
            const ctime = Date.now()
            data.createTime = ctime
            data.modifyTime = ctime
            const dbData = data.toDBData()
            const request: IDBRequest = this.getStore().add(dbData)
            request.onerror = (event: any) => reject(event)
            request.onsuccess = (event: any) => {
                // IndexDB 返回自增 ID
                data.id = event.target.result
                resolve(data)
            }
        })
    }

    public updateOne(data: Wallet): Promise<Wallet> {
        return new Promise((resolve, reject) => {
            data.modifyTime = Date.now()
            const dbData = data.toDBData()
            const request: IDBRequest = this.getStore().put(dbData)
            request.onerror = (event: any) => reject(event)
            request.onsuccess = () => {
                resolve(data)
            }
        })
    }

    private getStore(): IDBObjectStore {
        return this.db.transaction(WALLET_TABLE, "readwrite").objectStore(WALLET_TABLE)
    }
}