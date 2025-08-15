<style lang="less" scoped src="../style/WalletContent.less" />
<script lang="ts" src="../javascript/WalletContent.ts" />

<template>
    <div id="wallet-content">
        <div class="wallet-info">
            <h1>支出：{{ expenditure.toFixed(2) }}</h1>
            <h1>收入：{{ income.toFixed(2) }}</h1>
            <!-- 余额，也就是收入减去支出 -->
            <h1>余额：{{ income.minus(expenditure).toFixed(2) }}</h1>
        </div>

        <!-- 标签页式数据筛选区域 -->
        <!-- 用于切换表格的标签页 -->
        <div class="tab-bar">
            <div :class="{ 'activate': showTable === SHOW_TABLE.expenditure_bill }"
                @click="showTable = SHOW_TABLE.expenditure_bill">支出账单</div>
            <div :class="{ 'activate': showTable === SHOW_TABLE.income_statement }"
                @click="showTable = SHOW_TABLE.income_statement">收入账单</div>
            <div style="flex: 1; padding: 0 5px; gap: 5px;">
                <!-- TODO: 条件筛选 -->
                <div class="condition-selection">条件筛选</div>
                <!-- 新建按钮 -->
                <button type="button" style="width: 50px;">新建</button>
            </div>
        </div>

        <div class="tab-content">
            <!-- 支出/收入表 -->
            <div class="table">
                <table v-show="showTable === SHOW_TABLE.expenditure_bill">
                    <thead>
                        <tr>
                            <th width="150px">日期</th>
                            <th width="150px">类型</th>
                            <th>店铺</th>
                            <th>商品名称</th>
                            <th width="150px">单价</th>
                            <th width="150px">数量</th>
                            <th width="150px">总价</th>
                            <th width="105px">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(item, idx) in expenditureBill" v-bind:key="idx">
                            <td>{{ item.date }}</td>
                            <td>{{ item.eType }}</td>
                            <td>{{ item.store }}</td>
                            <td>{{ item.name }}</td>
                            <td>{{ item.unitPrice.toFixed(2) }}</td>
                            <td>{{ item.quantity.toFixed(2) }}</td>
                            <td>{{ item.unitPrice.times(item.quantity).toFixed(2) }}</td>
                            <td>
                                <button type="button">修改</button>
                                <button type="button" style="margin-left: 2px;">删除</button>
                            </td>
                        </tr>
                    </tbody>
                </table>

                <table v-show="showTable === SHOW_TABLE.income_statement">
                    <thead>
                        <tr>
                            <th width="150px">日期</th>
                            <th width="150px">类型</th>
                            <th width="150px">金额</th>
                            <th>备注</th>
                            <th width="105px">操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(item, idx) in incomeStatement" v-bind:key="idx">
                            <td>{{ item.date }}</td>
                            <td>{{ item.iType }}</td>
                            <td>{{ item.money.toFixed(2) }}</td>
                            <td>{{ item.comment }}</td>
                            <td>
                                <button type="button">修改</button>
                                <button type="button" style="margin-left: 2px;">删除</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <!-- 分页按钮 -->
            <div class="page-btn-group">
                <button type="button">上一页</button>
                <button type="button">下一页</button>
            </div>
        </div>
    </div>
</template>