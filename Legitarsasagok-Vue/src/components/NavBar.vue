<template>
  <nav class="navbar navbar-expand-sm nav-bg fixed-top ">
    <div class="container-fluid">
      <a class="navbar-brand" href="/"><img id="nav-icon" height="40" width="40" src="@icon/icofont/icons/ui-flight.svg" /></a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <router-link class="nav-link" exact-active-class="active" to="/">Kezdőoldal</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" exact-active-class="active" to="/Foglalas">Jegy fogalalás</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" exact-active-class="active" to="/Osszegzo">Foglalás összegzés</router-link>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: "NavBar"
}
</script>

<style scoped>
.nav-bg{
  background-color: rgb(62, 210, 230);
}
nav li:hover {
  text-shadow: 2px 2px 25px rgb(0, 0, 138,);
}
.nav-link:active{
  text-shadow: 2px 2px 10px rgb(0, 91, 177);
}
</style>