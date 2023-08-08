import { createRouter, createWebHistory } from 'vue-router';
import InputForm from '../views/InputForm.vue';
import NamesList from '../views/NamesList.vue';

const routes = [
  {
    path: '/',
    name: 'home',
    components: {
      default: InputForm, // Компонент InputForm будет отображаться в основной точке монтирования
      namesList: NamesList,
    },
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
