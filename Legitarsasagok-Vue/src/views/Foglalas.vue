<template>
  <div class="container">
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
          A kettö ország között nincs utazási lehetöség !
        </div>
      </div>
      <!--Page2-->
      <div class="col align-self-center" v-if="pVisible == 1">

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

      //api
      "ServerIp": Servers.find(x=>x.Name == "RestApi").Ip,
      "Data_City": [],
      "Data_Airline" : []
    }
  },
  methods: {
    toNextPage() {
      if (this.pVisible == 0 && this.ifSameVaros || this.ifDosentHaveUtazasiLehetoseg) {
        return;
      }
      console.log(this.pVisible);
      console.log(this.ifSameVaros);
      console.log(this.ifDosentHaveUtazasiLehetoseg);


      this.pVisible++;
    },
    callAirline() {

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

  }
}
</script>

<style scoped>

</style>