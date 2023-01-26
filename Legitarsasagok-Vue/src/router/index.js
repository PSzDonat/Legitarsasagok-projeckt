import { createRouter, createWebHistory } from 'vue-router'
import Index from "@/views/Index.vue";
import Foglalas from "@/views/Foglalas.vue";
import Osszegzo from "@/views/Osszegzo.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Index',
      component: Index
    },
    {
      path: '/Foglalas',
      name: 'Foglalas',
      component: Foglalas
    },
    {
      path: '/Osszegzo',
      name: 'Osszegzo',
      component: Osszegzo
    },
  ]
})

export default router
