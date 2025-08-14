<script lang="ts" src="./javascript/App.ts" />
<style lang="less" scoped src="./style/App.less" />

<template>
  <!-- 统计和钱包选项卡 -->
  <div class="tab-control">
    <div class="tab-element" :class="{ 'tab-active': !activeTab }" @mousedown="activeTab = null">统计图</div>

    <!-- 鼠标单击时设置背景色，双击时打开编辑钱包名称的对话框 -->
    <div class="tab-element" v-for="(item, idx) in wallets" :key="idx" :class="{ 'tab-active': item === activeTab }"
      @mousedown="activeTab = item" @dblclick="editWalletName = true">
      {{ item.name }}
    </div>
    <!-- 创建钱包 -->
    <div class="tab-element" style="font-size: 25px;" @mousedown="newWallet">+</div>
  </div>

  <!-- 编辑钱包名称的对话框 -->
  <div class="dialog" v-if="editWalletName">
    <div>
      <!-- 一个文本输入框，一个保存按钮，一个取消按钮 -->
      <div class="input-area">
        <input id="wallet-name-in" type="text" placeholder="请输入钱包名称" :value="activeTab?.name">
      </div>
      <div class="buton-group">
        <button type="button" @click="saveName">保存</button>
        <button type="button" @click="editWalletName = false">取消</button>
      </div>
    </div>
  </div>

  <!-- 选项卡内容 -->
  <div class="tab-content">
    <!-- 统计图标 -->
    <StatisticalChart v-if="!activeTab" />
    <!-- 钱包选项卡 -->
    <WalletContent v-if="activeTab" :wallet="activeTab" />
  </div>
</template>