<template>
    <!-- TODO: 钱包选项卡，显示钱包的支出和收入信息 -->
    <div id="WalletTab">
        <h1>wallet：{{ wallet }}</h1>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';

import Wallet from '@/javascript/entity/Wallet';

@Options({
    props: {
        wallet: {
            type: Wallet,
            required: true
        }
    }
})
export default class WalletContent extends Vue {
    wallet?: Wallet
}
</script>

<style lang="less" scoped></style>