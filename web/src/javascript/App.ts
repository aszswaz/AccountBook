import { Options, Vue } from 'vue-class-component';

import WalletContent from '@/components/WalletContent.vue';
import StatisticalChart from '@/components/StatisticalChart.vue';
import Wallet from '@/javascript/entity/Wallet';
import DBManager from '@/javascript/util/DBManager';

@Options({
  components: {
    StatisticalChart,
    WalletContent
  }
})
export default class App extends Vue {
  wallets: Wallet[] = [];
  activeTab: Wallet | null = null;
  editWalletName: boolean = false;

  async mounted(): Promise<void> {
    // 获取所有钱包信息
    const table = await DBManager.openWalletTable();
    this.wallets = await table.findAll()
  }

  unmounted(): void {
    // 关闭数据库
    DBManager.close()
  }

  /**
   * 创建新的钱包
   */
  async newWallet() {
    try {
      if (this.wallets.length < 20) {
        const ctime = Date.now()
        const wallet = new Wallet()
        const table = await DBManager.openWalletTable();
        // 先保存到数据库再显示到页面，以便获得 IndexDB 自增的主键
        await table.insetrOne(wallet)
        this.wallets.push(wallet)
        this.activeTab = wallet
        this.editWalletName = true
      } else {
        alert("钱包数量过多！")
      }
    } catch (err) {
      console.error(err)
      alert("操作失败")
    }
  }

  /**
   * 保存钱包名称
   */
  async saveName() {
    try {
      const nameIn = <HTMLInputElement | null>document.getElementById("wallet-name-in")
      if (!nameIn || !this.activeTab) return

      // 同步到页面
      this.activeTab.name = nameIn.value
      this.editWalletName = false
      // 将修改保存到数据库
      const table = await DBManager.openWalletTable()
      await table.updateOne(this.activeTab)
    } catch (error) {
      console.error(error)
      alert("操作失败")
    }
  }
}