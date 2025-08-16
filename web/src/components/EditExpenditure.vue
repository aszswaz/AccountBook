<template>
    <!-- 创建或修改支出账单的对话框 -->
    <div class="curtain">
        <div class="edit-expenditure">
            <div><span>日期：</span><input type="date" v-model="newData.date" /></div>
            <div>
                <span>类型：</span>
                <select v-model="newData.eType">
                    <option value="" disabled selected>-- 请选择 --</option>
                    <option value="饮食">饮食</option>
                    <option value="证券">证券</option>
                    <option value="衣着">衣着</option>
                    <option value="居住">居住</option>
                    <option value="生活用品及服务">生活用品及服务</option>
                    <option value="交通通信">交通通信</option>
                    <option value="教育文化娱乐">教育文化娱乐</option>
                    <option value="医疗保健">医疗保健</option>
                    <option value="其他">其他</option>
                </select>
            </div>
            <div><span>店铺：</span><input type="text" v-model="newData.store" autocomplete="true" /></div>
            <div><span>商品名称：</span><input type="text" v-model="newData.name" autocomplete="true" /></div>
            <div>
                <span>单价：</span>
                <input type="number" v-model="newData.unitPrice" />
            </div>
            <div>
                <span>数量：</span>
                <input type="number" v-model="newData.quantity" />
            </div>
            <div>
                <span>总价：</span>
                <input type="number" v-model="newData.totalPrices" disabled />
            </div>
            <div class="btn-group">
                <button type="button" @click="saveExpenditure">保存</button>
                <button type="button">取消</button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'

const Big = require("big.js")

import Wallet from '@/javascript/entity/Wallet'
import ExpenditureBill from '@/javascript/entity/ExpenditureBill'

@Options({
    props: {
        wallet: {
            type: Wallet,
            require: true
        },
        expenditureBill: {
            type: ExpenditureBill,
            require: false
        }
    }
})
export default class EditExpenditure extends Vue {
    // 钱包
    wallet?: Wallet
    // 支出账单
    expenditureBill?: ExpenditureBill
    // 用户输入的新数据，与 input 等表单元素绑定
    newData = {
        date: "",
        eType: "",
        store: "",
        name: "",
        unitPrice: "0",
        quantity: "0",
        totalPrices: "0.00"
    }

    /**
     * 保存支出账单
     */
    saveExpenditure() {
        console.log(this.newData)
    }

    beforeUpdate(): void {
        // 根据输入的单价和数量，自动计算总价
        if (this.newData.unitPrice.length === 0) this.newData.unitPrice = '0'
        if (this.newData.quantity.length === 0) this.newData.quantity = '0'

        const n1 = new Big(this.newData.unitPrice)
        const n2 = new Big(this.newData.quantity)
        const result = n1.times(n2)
        this.newData.totalPrices = result.toFixed(2).toString()
    }

    created(): void {
        this.newData.date = new Date().toISOString().split('T')[0]
    }
}
</script>

<style lang="less">
@import '../style/global.less';

// 创建或修改支出账单的对话框
.edit-expenditure {
    position: fixed;
    top: 50%;
    left: 50%;
    width: auto;
    height: auto;
    // 使对话框居中
    transform: translate(-50%, -50%);
    background-color: white;
    border-radius: @dialog-border-radius;
    padding: @dialog-padding;
    // 子元素的排列方式为竖向排列
    display: flex;
    flex-direction: column;
    // 子元素间距
    gap: 5px;

    input,
    select {
        width: 177px;
        height: 30px;
        font-size: 16px;
    }

    span {
        display: inline-block;
        width: 85px;
        text-align: right;
    }

    // 保存和取消按钮
    .btn-group {
        // 网格布局
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 2px;
    }
}
</style>