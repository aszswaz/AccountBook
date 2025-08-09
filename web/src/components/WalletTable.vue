<template>
    <!-- 所有钱包的横向表格 -->
    <div id="WalletTable">
        <!-- 导航栏 -->
        <div>
            <label style="margin:0 10px;">钱包</label>
            <button @click="newWallet">新建</button>
        </div>
        <!-- 表格的主要内容 -->
         <div>
            <div class="element" v-for="(item, idx) in wallets" :key="idx">
                <div>
                    名称：
                    <input type="text"
                        v-model="item.data.name"
                        :readonly="!item.isEditName"
                        @dblclick="item.isEditName = true"
                        @blur="item.isEditName = false"/>
                </div>
                <div>
                    余额：
                    <input type="number" 
                        v-model="item.data.balance"
                        :readonly="!item.isEditBalance"
                        @dblclick="item.isEditBalance = true"
                        @blur="item.isEditBalance = false"/>
                </div>
                <button v-if="item.isEditName || item.isEditBalance">保存</button>
            </div>
         </div>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  props: {
  }
})

export default class WalletTable extends Vue {
    wallets = [{
        data: {
            name: "这是第一个钱包",
            balance: "10.00",
        },
        isEditName: false,
        isEditBalance: false
    },
    {
        data: {
            name: "这是第二个钱包",
            balance: "50.00",
        },
        isEditName: false,
        isEditBalance: false
    },
    {
        data: {
            name: "这是第三个钱包",
            balance: "150.00",
        },
        isEditName: false,
        isEditBalance: true
    }]

    newWallet(): void {
        for(let item of this.wallets) {
            console.log(item)
        }
    }
}
</script>

<style lang="less" scoped>
// 横向列表
.element {
    display: inline-block;
    width: 250px;
    height: 100px;
    background-color: lightgreen;
    margin: 0;
}

// 只读的文本框
input:read-only {
    background-color: lightblue;
}

button {
    display: inline-block;
}
</style>