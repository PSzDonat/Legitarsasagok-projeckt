<template>
  <div class="container-fluid">
    <div class="row align-items-center justify-content-center">
        <div class="text-center" id="mid">
          <h1>Utaznál valahova?</h1>
          <h2>Repülőven gondolkozol?</h2>
          <div id="list">
            <ul>
              <li>Népszerű</li>
              <li>Kényelmes</li>
              <li>Jól felszerelt járataink</li>
              <li>Pénztárca kímélő árakkal</li>
            </ul>
          </div>
          <h4>Gyere foglalj helyet járatunkon!</h4>
          <router-link class="btn btn-outline-dark" id="button" to="/Foglalas">Fogallás</router-link>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Foglalas"
}
</script>

<style scoped>
.container-fluid{
  height:100vh;
  width: 100vw;
  margin: 0;
}
.row{
  height: 100vh;
  margin-top: 50px;
  background-image: url(/pictures/EmptyAirport-2020-Covid.png);
  background-size: cover;
  background-position: center;
}
#mid{
  background-color: rgba(255,255,255,0.85);
  width: 40rem;
  border-radius: 1rem;
}
#button{
  margin-bottom: 1.5rem;
  font-size: 140%;

}
h4{
  margin-top: 3rem;
}
ul{
  margin: 2rem;
  text-align: left;
}
#list{
  width: 20rem;
}
</style>