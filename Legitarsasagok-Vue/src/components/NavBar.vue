<template>
  <nav class="navbar navbar-expand-sm nav-bg fixed-top ">
    <div class="container-fluid">
      <a class="navbar-brand" href="/"><img height="40" width="40" src="@icon/icofont/icons/ui-flight.svg" /></a>
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
  background: linear-gradient(90deg, rgba(0,207,194,1) 51%, rgba(22,60,135,1) 100%);
  color: ;
}
.nav-link:hover {
  text-shadow: 2px 2px 20px rgb(0, 0, 83);
}
.nav-link:active{
  text-shadow: 2px 2px 10px rgb(0, 0, 83);
}
.navbar{
  padding-bottom: 5px;
  padding-top: 5px;
}
</style>