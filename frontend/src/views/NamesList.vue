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
import { ref, onMounted, watch } from 'vue'; // Импортируем ref, onMounted и watch
import api from '@/api';

export default {
  name: 'NamesList',
  setup(props, context) {
    const names = ref([]); // Создаем реактивную переменную для списка имен
    const updateNames = ref(false); // Создаем реактивную переменную для флага обновления

    onMounted(() => {
      fetchNames(); // Вызываем метод для получения списка имен при монтировании
    });

    // При изменении флага обновления, вызываем метод для обновления списка имен
    watch(updateNames, () => {
      if (updateNames.value) {
        fetchNames();
        updateNames.value = false;
      }
    });

    const fetchNames = () => {
      api.userList().then((response) => {
        names.value = response; // Обновляем список имен
      });
    };

    return {
      names, // Возвращаем реактивную переменную из setup
      updateNames, // Возвращаем реактивную переменную из setup
    };
  },
};
</script>
