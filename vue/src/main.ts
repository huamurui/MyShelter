import { createApp } from 'vue'
import App from './App.vue'
import axios from './components/services/axiosInstance'


App.config.globalProperties.$axios=axios;  //配置axios的全局引用

createApp(App).mount('#app')
