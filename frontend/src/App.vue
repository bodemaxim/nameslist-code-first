<template>
  <div id="app">
    <router-view />
    <router-view name="namesList" />
    <NamesList />
  </div>
</template>

<script>
import { ref, onMounted } from 'vue'; // Импортируем ref и onMounted

import NamesList from '@/views/NamesList.vue';

export default {
  components: {
    NamesList,
  },
  setup() {
    const updateNames = ref(false); // Создаем реактивную переменную для обновления списка имен

    onMounted(() => {
      updateNames.value = false; // При монтировании компонента сбрасываем флаг обновления
    });

    return {
      updateNames, // Возвращаем реактивную переменную из setup
    };
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
