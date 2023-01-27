<template>
  <NavBar></NavBar>
  <RouterView></RouterView>
  <Footer></Footer>
</template>

<script>
import {RouterView} from "vue-router";
import NavBar from "@/components/NavBar.vue";
import Footer from "./components/Footer.vue";
export default {
  components:{
    NavBar,
    RouterView,
    Footer
}
}
</script>

<style scoped>

</style>
