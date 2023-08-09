<template>
  <div>
    <h2>Новый пользователь</h2>
    <form @submit.prevent="addUser">
      <label for="firstName">Имя:</label>
      <input v-model="firstName" type="text" id="firstName" name="firstName" required><br><br>

      <label for="lastName">Фамилия:</label>
      <input v-model="lastName" type="text" id="lastName" name="lastName" required><br><br>

      <button type="submit">Добавить</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      firstName: '',
      lastName: ''
    };
  },
  methods: {
    addUser() {
      // Вместо этой части кода нужно добавить логику для обработки введенных данных
      // Например, отправка данных на сервер или их сохранение в локальное хранилище
      
      alert(`Добавлен новый пользователь:\nИмя: ${this.firstName}\nФамилия: ${this.lastName}`);
      
      // После обработки данных можно сбросить поля ввода
      this.firstName = '';
      this.lastName = '';
    }
  }
};
</script>
