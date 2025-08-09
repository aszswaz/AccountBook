<template>
  <!-- <img alt="Vue logo" src="./assets/logo.png"> -->
  <!-- <HelloWorld msg="Welcome to Your Vue.js + TypeScript App"/> -->
   <WalletTable/>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import WalletTable from './components/WalletTable.vue';

@Options({
  components: {
    WalletTable
  },
})
export default class App extends Vue {}
</script>

<style lang="less">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 0;
  background-color: lightgray;
}
</style>
