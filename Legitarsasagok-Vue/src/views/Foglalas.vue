<template>
  <div :class="pVisible == 1 ? 'container-fluid': 'container' ">
    <div class="row align-items-center">

      <h1 class="text-center mt-5 pt-5">Jegy Lefoglalása</h1>
      <!--Page1-->
      <div class="col align-self-center" v-if="pVisible == 0">


        <form class="mt-3 border p-5 rounded">
          <div class="mb-3">
            <label for="Honnan">Honnan:</label>
            <select class="form-select" :class="ifSameVaros || ifDosentHaveUtazasiLehetoseg ? 'is-invalid': ''" id="RepuloJaratok" v-model="varosSelect1">
              <option v-for="(item, index) in Data_City" :key="index" :value="item.varosNeve">{{item.varosNeve}}</option>
            </select>
          </div>
          <div class="mb-3">
            <label for="Hova">Hova:</label>
            <select class="form-select" :class="ifSameVaros || ifDosentHaveUtazasiLehetoseg ? 'is-invalid': ''" id="RepuloJaratok" v-model="varosSelect2">
              <option v-for="(item, index) in Data_City" :key="index" :value="item.varosNeve">{{item.varosNeve}}</option>
            </select>
          </div>

          <a class="btn btn-primary" @click="toNextPage" >Következö</a>
        </form>
        <div class="alert alert-warning mt-3" role="alert" v-if="ifSameVaros">
          Kérem kettő különböző várost válasszon !
        </div>
        <div class="alert alert-warning mt-3" role="alert" v-if="ifDosentHaveUtazasiLehetoseg">
          A kettö ország között nincs közvetlen utazási lehetöség !
        </div>
      </div>
      <!--Page2-->
      <div class="col align-self-center" v-if="pVisible == 1">
        <table class="table table-hover table-striped">
          <thead>
            <tr>
              <th>Légitársaság</th>
              <th>Honnan</th>
              <th>Hova</th>
              <th>Tavolsag</th>
              <th>UtazasiIdo (Perc)</th>
              <th>Ár (Felnőtt)</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in filter_Data_Airline" :key="index">
              <td>{{item.legitarsasag}}</td>
              <td>{{item.honnan}}</td>
              <td>{{item.hova}}</td>
              <td>{{item.tavolsag}} Km</td>
              <td>{{item.utazasiIdo}}</td>
              <td>{{this.Data_Flight[index].ara}}</td>
              <td>
                <a class="btn btn-primary" @click="selectRepuloJarat(index)">Vétel</a>
              </td>
            </tr>
          </tbody>
        </table>

      </div>
      <!--Page3-->
      <div class="col align-self-center" v-if="pVisible == 2">

      </div>

    </div>
  </div>
</template>

<script>
import {Servers} from "../assets/js/Servers.mjs";
export default {
  name: "TravelTo",
  data() {
    return {
      //page1
      "pVisible" : 0,
      "varosSelect1":"",
      "varosSelect2":"",
      //page2
      "filter_Data_Airline": [],
      //page2.5
      "letezik" : false,
      "selected_id" : -1,
      "ara" : -1,
      "ferohely" : -1,
      "foglaltHelyek" : 0,
      "foglalasokOsszege" : 0,
      //api
      "ServerIp": Servers.find(x=>x.Name == "RestApi").Ip,
      "Data_City": [],
      "Data_Airline" : [],
      "Data_Flight" : [],
      "Data_Reservations" : []
    }
  },
  methods: {
    toNextPage() {
      if (this.pVisible == 0 && this.varosSelect1 == '' || this.varosSelect2 == '') return;
      if (this.pVisible == 0 && this.ifSameVaros || this.ifDosentHaveUtazasiLehetoseg) return;

      this.filter_Data_Airline = this.Data_Airline.filter(x=>x.honnan == this.varosSelect1 && x.hova == this.varosSelect2);
      this.pVisible++;
    },
    selectRepuloJarat(index) {
      let temp = this.Data_Reservations.find(x=>x.menetrend_ID = index+1);
      console.log(temp);
      if (temp != undefined) {
        this.letezik = true;
        this.foglaltHelyek = temp.foglaltHelyek;
        this.foglalasokOsszege = temp.foglalasokOsszege;
      }
      this.selected_id = index+1;
      this.ara = this.Data_Flight[index].ara;
      this.ferohely = this.Data_Flight[index].ferohely;
      this.toNextPage()
    }
  },
  computed: {
    ifSameVaros() {
      return this.varosSelect1 != '' && this.varosSelect1 != '' && this.varosSelect1 == this.varosSelect2;
    },
    ifDosentHaveUtazasiLehetoseg() {
      let temp = this.Data_Airline.filter(x=>x.honnan == this.varosSelect1 && x.hova == this.varosSelect2);
      return this.varosSelect1 !='' && this.varosSelect2!='' && this.varosSelect1 != this.varosSelect2 && temp.length == 0;
    }
  },
  async mounted() {
    await fetch(this.ServerIp+"cities").then(x=>x.json()).then(x=>this.Data_City = x);
    await fetch(this.ServerIp+"airlines").then(x=>x.json()).then(x=>this.Data_Airline = x);
    await fetch(this.ServerIp+"flights").then(x=>x.json()).then(x=>this.Data_Flight = x);
    await fetch(this.ServerIp+"reservations").then(x=>x.json()).then(x=>this.Data_Reservations = x);

  }
}
</script>

<style scoped>

</style>