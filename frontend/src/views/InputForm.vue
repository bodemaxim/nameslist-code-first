<template>
  <div>
    <h2>Новый пользователь</h2>
    <form @submit.prevent="addUser">
      <label for="firstName">Имя:</label>
      <input
        v-model="firstName"
        type="text"
        id="firstName"
        name="firstName"
        required
      /><br /><br />

      <label for="lastName">Фамилия:</label>
      <input
        v-model="lastName"
        type="text"
        id="lastName"
        name="lastName"
        required
      /><br /><br />

      <button type="submit">Добавить</button>
    </form>
  </div>
</template>

<script>
import api from '@/api';

export default {
  data() {
    return {
      firstName: '',
      lastName: '',
    };
  },
  methods: {
    addUser() {
      api.userCreate(this.firstName, this.lastName).then(() => {
        alert(
          `Добавлен новый пользователь:\nИмя: ${this.firstName}\nФамилия: ${this.lastName}`
        );

        // После обработки данных можно сбросить поля ввода
        this.firstName = '';
        this.lastName = '';

        // Устанавливаем флаг обновления списка имен
        this.updateNames = true;
      });
    },
  },
};
</script>
