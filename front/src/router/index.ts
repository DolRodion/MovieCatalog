import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Movies from '../views/Movies.vue';


Vue.use(VueRouter);

const routes: RouteConfig[] = [
  {
    path: '/',
    name: 'Movie',
    component: Movies,
  }, 

];

const router = new VueRouter({
  routes,
});

export default router;
