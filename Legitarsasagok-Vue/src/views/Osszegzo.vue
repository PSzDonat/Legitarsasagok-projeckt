<template>
  <div class="container-fluid"> 
    <table class="table">
      <thead>
        <tr>
        <th>Légitársaság</th>
        <th>Honnan</th>
        <th>Hova</th>
        <th>Féröhely/Utasok Száma</th>
        <th>Összes kereslet</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in Data_Reservations" :key="index">
          <td>{{ Data_Airline[item.id-1].legitarsasag }}</td>
          <td>{{ Data_Airline[item.id-1].honnan  }}</td>
          <td>{{ Data_Airline[item.id-1].hova }}</td>
          <td>{{ Data_Flight[item.id-1].ferohely }}/{{ item.foglaltHelyek }}</td>
          <td>{{ item.foglalasokOsszege }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import {Servers} from "../assets/js/Servers.mjs";
export default {
  name: "TravelTo",
  data() {
    return {
      "ServerIp": Servers.find(x=>x.Name == "RestApi").Ip,
      //Api
      "Data_Airline" : [],
      "Data_Flight" : [],
      "Data_Reservations" : []
    }
  }, 
  async mounted() {
    await fetch(this.ServerIp+"airlines").then(x=>x.json()).then(x=>this.Data_Airline = x);
    await fetch(this.ServerIp+"flights").then(x=>x.json()).then(x=>this.Data_Flight = x);
    await fetch(this.ServerIp+"reservations").then(x=>x.json()).then(x=>this.Data_Reservations = x);
  }
}
</script>

<style scoped>
.container-fluid{
  height: 100vh;
  margin-top: 60px;
}
</style>