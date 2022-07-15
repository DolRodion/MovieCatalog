import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Movie from '../views/Movie.vue';
import ReviewTask from '../views/ReviewTask.vue';
import Tehknology from '../views/Tehknology.vue';


Vue.use(VueRouter);

const routes: RouteConfig[] = [
  {
    path: '/',
    name: 'Movie',
    component: Movie,
  },
  {
    path: '/Movie/ReviewTask',
    name: 'ReviewTask',
    component: ReviewTask,
  },
  {
    path: '/Movie/Tehknology',
    name: 'Tehknology',
    component: Tehknology,
  },

  

];

const router = new VueRouter({
  routes,
});

export default router;
