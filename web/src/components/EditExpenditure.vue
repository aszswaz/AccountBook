<template>
    <!-- 创建或修改支出账单的对话框 -->
    <div class="curtain">
        <div class="edit-expenditure">
            <div><span>日期：</span><input id="date-in" type="date" /></div>
            <div>
                <span>类型：</span>
                <select id="e-type">
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
            <div><span>店铺：</span><input id="store-in" type="text" autocomplete="true" /></div>
            <div><span>商品名称：</span><input id="name-in" type="text" autocomplete="true" /></div>
            <div>
                <span>单价：</span>
                <input id="unit-price-in" type="number" @input="updateTotalPrices" />
            </div>
            <div>
                <span>数量：</span>
                <input id="quantity-in" type="number" @input="updateTotalPrices" />
            </div>
            <div>
                <span>总价：</span>
                <input id="total-prices-in" type="number" disabled />
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

import { getInputValue, getInputElement } from '@/javascript/util/DOMUtil'

@Options({})
export default class EditExpenditure extends Vue {
    /**
     * 根据输入的单价和数量，自动计算总价
     */
    updateTotalPrices() {
        try {
            let unitPrice = getInputValue("unit-price-in")
            let quantity = getInputValue("quantity-in")
            const totalPrices = getInputElement("total-prices-in")

            if (unitPrice.length === 0) unitPrice = '0'
            if (quantity.length === 0) quantity = '0'

            const n1 = new Big(unitPrice)
            const n2 = new Big(quantity)
            const result = n1.times(n2)
            if (totalPrices) totalPrices.value = result.toFixed(2).toString()
        } catch (err) {
            alert(err)
        }
    }

    /**
     * 保存支出账单
     */
    saveExpenditure() {
        const date = getInputValue("date-in")
        const eType = getInputValue("e-type")
        const store = getInputValue("store-in")
        const name = getInputValue("name-in")
        const unitPrice = getInputValue("unit-price-in")
        const quantity = getInputValue("quantity-in")

        console.log(`date: ${date}`)
        console.log(`eType: ${eType}`)
        console.log(`store: ${store}`)
        console.log(`name: ${name}`)
        console.log(`unitPrice: ${unitPrice}`)
        console.log(`quantity: ${quantity}`)
    }

    mounted(): void {
        const date = getInputElement("date-in")
        date.value = new Date().toISOString().split('T')[0]
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