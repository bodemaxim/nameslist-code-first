/**/

<template>
  <div>
    <h2>Список имен</h2>
    <ul>
      <li v-for="name in names" :key="name.id">
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
