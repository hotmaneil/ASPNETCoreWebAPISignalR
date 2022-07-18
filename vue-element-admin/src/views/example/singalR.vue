<template>
  <div class="app-container">
    <el-alert
      :title="data"
      type="success"
      show-icon
    />
  </div>
</template>

<script>
const signalR = require('@microsoft/signalr')
export default {
  name: 'SingalR',

  data() {
    return {
      data: null
    }
  },

  created() {
    this.connectToContactHub()
  },

  methods: {
    /**
     * 連線到ASP.NET Core的SignarlR之ContactHub
     * 亦加入自動重新連線
     */
    connectToContactHub() {
      const connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5276/ContactHub')
        .withAutomaticReconnect()
        .build()

      // 與Server建立連線
      connection.start().then(function() {
        console.log('連線完成')
      }).catch(function(err) {
        console.log('連線錯誤', err)
      })

      connection.on('SendData', source => {
        console.log(source)
        this.data = source.id + '_' + source.name
      })
    }
  }
}
</script>

