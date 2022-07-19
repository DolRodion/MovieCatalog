import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import vuetify from './plagins/vuetify';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import Vuetify from 'vuetify';

Vue.config.productionTip = false;
Vue.use(Vuetify);

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount('#app');
