import { Options, Vue } from 'vue-class-component'
import { ElTable, ElTabs, ElTabPane } from 'element-plus'

const Big = require("big.js")

import Wallet from '@/javascript/entity/Wallet'

@Options({
    props: {
        wallet: {
            type: Wallet,
            required: true
        }
    },
    components: {
        ElTable,
        ElTabs,
        ElTabPane
    }
})
export default class WalletContent extends Vue {
    wallet?: Wallet
    // 当前显示的表格
    SHOW_TABLE = {
        expenditure_bill: 0,
        income_statement: 1
    }
    showTable = this.SHOW_TABLE.expenditure_bill

    // 支出金额
    expenditure = new Big("0")
    // 收入金额
    income = new Big("0")
    // 支出账单
    expenditureBill = [
        {
            date: "2025-08-10",
            eType: "饮食",
            store: "小卖部",
            name: "棒冰",
            unitPrice: new Big("40000"),
            quantity: new Big("30000")
        },
        {
            date: "2025-08-15",
            eType: "饮食",
            store: "小卖部",
            name: "薯片",
            unitPrice: new Big("40000"),
            quantity: new Big("30000")
        },
        {
            date: "2025-08-15",
            eType: "饮食",
            store: "小卖部",
            name: "冰红茶",
            unitPrice: new Big("40000"),
            quantity: new Big("30000")
        }
    ]
    // 收入账单
    incomeStatement = [
        {
            date: "2025-07-25",
            iType: "工资",
            money: new Big("15000"),
            comment: "六月份的工资收入"
        },
        {
            date: "2025-07-25",
            iType: "股票",
            money: new Big("17000"),
            comment: "股票卖出"
        }
    ]

    /**
     * 更新钱包的支出、收入、余额、支出账单和收入账单
     */
    updateMoney() {
        // 累加收入
        let money = new Big("0")
        for (const item of this.incomeStatement) money = money.plus(item.money)
        this.income = money
        // 累加支出
        money = new Big("0")
        for (const item of this.expenditureBill) money = money.plus(item.unitPrice.times(item.quantity))
        this.expenditure = money
    }

    created(): void {
        this.updateMoney()
    }
    beforeUpdate(): void {
        this.updateMoney()
    }
}