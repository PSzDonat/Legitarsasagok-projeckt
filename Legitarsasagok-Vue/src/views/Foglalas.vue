<template>
  <div class="container">
    <div class="row align-items-center">
      <div class="col align-self-center">
        <h1 class="text-center mt-2">Jegy Lefoglalása</h1>
        <form class="mt-3 border p-5 rounded">
          <div class="mb-3">
            <label for="Honnan">Honnan:</label>
            <select class="form-select" id="RepuloJaratok">
              
            </select>
          </div>
          <div class="mb-3">
            <label for="Hova">Hova:</label>
            <select class="form-select" id="RepuloJaratok">
              
            </select>
          </div>
          <div class="mb-3">
            <label for="RepuloJaratok" class="mb-1">Repülőjáratok:</label>
            <select class="form-select" id="RepuloJaratok">
              <option value="1">One</option>
              <option value="2">Two</option>
              <option value="3">Three</option>
            </select>
          </div>
          <div class="mb-3">
            <label for="IndulasiIdo">Indulás Dátuma:</label>
            <input type="datetime-local" id="IndulasiIdo" v-model="dateNow" :min="dateNow" class="form-control">
          </div>
          <div class="mb-3">
            <label for="Utassam">Utassam</label>
            <input id="Utassam" type="number" class="form-control">
          </div>
          <button type="submit" class="btn btn-primary">Foglalas</button>
        </form>
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
      "dateNow" : "",
      "orszagok" : Array()
    }
  },
  mounted() {


    const dateAndTime = new Date().toISOString().split('T');
    const time = dateAndTime[1].split(':');
  
    this.dateNow = dateAndTime[0]+'T'+time[0]+':'+time[1]+':'+time[2].split('.')[0];
    let Api_City = fetch(Servers.find(x=>x.Name == "RestApi").Ip+"cities");
  }
}
</script>

<style scoped>

</style>