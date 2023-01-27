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
          <div class="mb-3">
            <label for="IndulasiIdo" class="">Indulás Dátuma:</label>
            <input type="datetime-local" id="IndulasiIdo" v-model="date" :min="date" class="form-control mt-1">
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
              <td>{{this.Data_Flight[item.id-1].ara}}</td>
              <td>
                <button class="btn btn-primary" @click="selectRepuloJarat(item.id)">Vétel</button>
              </td>
            </tr>
          </tbody>
        </table>

      </div>
      <!--Page3-->
      <div class="col align-self-center" v-if="pVisible == 2">
        <form class="mt-3 border p-5 rounded">
          <div class="mb-3">
            <label for="utasokszama">Utasok Száma:</label>
            <input min="0" :max="ferohely-foglaltHelyek" v-model="utasokSzama" type="number" name="utasokszama" id="utasokszama" class="form-control mt-1">
            <div class="d-flex justify-content-between align-items-center">
              <button class="btn btn-primary mt-3" @click="foglalas">Vásárlás</button>
              <h4 class="m-0"><span class="badge bg-secondary">{{this.calculatePrice}} Ft</span></h4>
            </div>
          </div>
        </form>
        <div class="alert alert-warning mt-3" role="alert" v-if="utasokSzama <= -1">
          Minusz számú utas nem lehet !
        </div>
        <div class="alert alert-warning mt-3" role="alert" v-if="utasokSzama > ferohely-foglaltHelyek">
          Több jegyet nem tutsz venni !
        </div>
      </div>
      <!--Page3-->
      <div class="col align-self-center" v-if="pVisible == 3">
        <div class="alert alert-success mt-3 text-center">
          Vásárlás sikeres! Köszönjük a vásárlást.
        </div>
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
      "date" : "",
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
      "jaratDatuma" : "",
      //page3
      "utasokSzama": 0,
      "kiszamolAra" : 0,

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
      let temp = this.Data_Reservations.filter(x=>x.menetrend_ID == index+1);
      if (temp.length != 0) {
        this.letezik = true;
        this.foglaltHelyek = temp[0].foglaltHelyek;
        this.foglalasokOsszege = temp[0].foglalasokOsszege;
        this.jaratDatuma = temp[0].jaratDatuma;
      }
      this.selected_id = index+1;
      this.ara = this.Data_Flight[index-1].ara;
      this.ferohely = this.Data_Flight[index].ferohely;
      this.toNextPage()
    },
    foglalas() {
      //validate
      if (this.utasokSzama <= -1 ) {
        return;
      }
      if (this.utasokSzama > this.ferohely-this.foglaltHelyek) {
        return;
      }
      if (this.letezik) {
        this.putReservations(this.selected_id,this.utasokSzama,this.kiszamolAra);
      }
      else {
        this.postReservations(this.selected_id,this.date,this.utasokSzama,this.kiszamolAra);
      }
      this.pVisible++;
    },
    postReservations(menetrend_ID,jaratDatuma,foglaltHelyek,foglalasokOsszege) {
      fetch(this.ServerIp+"reservations", {
        method: "POST",
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "id": menetrend_ID,
          "menetrend_ID" : menetrend_ID,
          "jaratDatuma" : jaratDatuma,
          "foglaltHelyek" : foglaltHelyek,
          "foglalasokOsszege" : foglalasokOsszege,
          "menetrend" : null
        })
      });
    },
    putReservations(menetrend_ID,foglaltHelyek,foglalasokOsszege) {
      fetch(this.ServerIp+"reservations/"+menetrend_ID, {
        method: "PUT",
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "menetrend_ID" : menetrend_ID,
          "jaratDatuma" : this.jaratDatuma,
          "foglaltHelyek" : this.foglaltHelyek+foglaltHelyek,
          "foglalasokOsszege" : this.foglalasokOsszege+foglalasokOsszege,
          "menetrend" : null
        })
      });
    }
  },
  computed: {
    ifSameVaros() {
      return this.varosSelect1 != '' && this.varosSelect1 != '' && this.varosSelect1 == this.varosSelect2;
    },
    ifDosentHaveUtazasiLehetoseg() {
      let temp = this.Data_Airline.filter(x=>x.honnan == this.varosSelect1 && x.hova == this.varosSelect2);
      return this.varosSelect1 !='' && this.varosSelect2!='' && this.varosSelect1 != this.varosSelect2 && temp.length == 0;
    },
    calculatePrice() {
      if (this.utasokSzama == 0 || this.utasokSzama <= -1 ) {
        return 0;
      }
      this.kiszamolAra = this.utasokSzama*this.ara;
      return this.kiszamolAra;
    }
  },
  async mounted() {
    await fetch(this.ServerIp+"cities").then(x=>x.json()).then(x=>this.Data_City = x);
    await fetch(this.ServerIp+"airlines").then(x=>x.json()).then(x=>this.Data_Airline = x);
    await fetch(this.ServerIp+"flights").then(x=>x.json()).then(x=>this.Data_Flight = x);
    await fetch(this.ServerIp+"reservations").then(x=>x.json()).then(x=>this.Data_Reservations = x);

    const dateAndTime = new Date().toISOString().split('T');
    const time = dateAndTime[1].split(':');

    this.date = dateAndTime[0]+'T'+time[0]+':'+time[1]+':'+time[2].split('.')[0];
  }
}
</script>

<style scoped>

</style>