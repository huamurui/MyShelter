import { createApp } from 'vue'
import App from './App.vue'
import axios from './components/services/axiosInstance'


App.config.globalProperties.$axios=axios;  //����axios��ȫ������

createApp(App).mount('#app')
