import { v4 as uuidV4 } from 'uuid';

export default class Wallet {
    // IndexDB 的自增 ID
    id: number
    // 全局唯一 ID
    uuid: string
    name: string
    createTime: number
    modifyTime: number

    constructor(...args: any) {
        let opt = null
        if (args.length > 0)
            opt = args[0]

        this.id = opt?.id
        this.uuid = opt?.uuid ?? uuidV4()
        this.name = opt?.name ?? "新建钱包"
        this.createTime = opt?.createTime
        this.modifyTime = opt?.modifyTime
    }

    public toDBData(): any {
        const data: any = {
            uuid: this.uuid,
            name: this.name,
            createTime: this.createTime,
            modifyTime: this.modifyTime
        }
        if (this.id) data.id = this.id
        return data
    }

    public static build(data: Wallet): Wallet {
        return new Wallet({
            id: data.id,
            uuid: data.uuid,
            name: data.name,
            createTime: data.createTime,
            modifyTime: data.modifyTime
        })
    }

}