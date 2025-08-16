/**
 * 支出账单
 */
export default class ExpenditureBill {
    // 消费日期
    date: number
    // 消费类型
    eType: string
    // 店铺
    store: string
    // 商品名称
    name: string
    // 单价
    unitPrice: string
    // 数量
    quantity: string

    constructor(...args: any[]) {
        const opt = args[0]
        this.date = opt?.date
        this.eType = opt?.eType
        this.store = opt?.store
        this.name = opt?.name
        this.unitPrice = opt?.unitPrice
        this.quantity = opt?.quantity
    }
}