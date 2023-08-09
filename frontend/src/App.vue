<template>
  <div id="app">
    <router-view />
    <router-view name="namesList" />
    <NamesList />
  </div>
</template>

<script>
import mitt from 'mitt'; // Импортируйте библиотеку mitt

const emitter = mitt(); // Создайте экземпляр эмиттера

export default {
  created() {
    emitter.on('updateNames', () => {
      this.$refs.namesList.fetchNames();
    });
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
