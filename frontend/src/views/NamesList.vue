/**/

<template>
  <div class="names-list">
    <h2 class="names-list__title">Список имен</h2>
    <ul class="names-list__ul">
      <li v-for="name in names" :key="name.id" class="names-list__item">
        {{ name.firstName }} {{ name.lastName }}
      </li>
    </ul>
  </div>
</template>

<script>
import { ref, onMounted, watch } from 'vue';
import api from '@/api';

export default {
  setup() {
    const names = ref([]);
    const updateNames = ref(false);

    onMounted(() => {
      fetchNames();
    });

    watch(updateNames, () => {
      if (updateNames.value) {
        fetchNames();
        updateNames.value = false;
      }
    });

    const fetchNames = () => {
      api.userList().then((response) => {
        names.value = response;
      });
    };

    return {
      names,
      updateNames,
    };
  },
};
</script>

<style>
* {
  box-sizing: border-box;
}

.names-list {
  margin: 2em auto;
  width: 70%;
  width: 70%;
  text-align: left;
  border: solid;
  border-width: 3px;
  border-radius: 5px;
  padding: 10px 20px;
}

/*Media Queries*/
/*XS*/

@media (max-width: 576px) {
  body {
    font-size: 12px;
  }
  .names-list {
    width: 95%;
  }
}
</style>
