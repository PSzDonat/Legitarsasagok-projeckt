import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import '@icon/icofont/icofont.css'

const app = createApp(App)

app.use(router)

app.mount('#app')
