import { createRouter, createWebHistory } from 'vue-router';
import Form from './input-form.js';

const routes = [{ path: '/', component: Form }];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
