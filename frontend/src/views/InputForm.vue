<template>
  <div class="input-form">
    <div class="input-form__container">
      <h2 class="input-form__title">Новый пользователь</h2>
      <hr class="input-form__separator" />

      <form @submit.prevent="addUser" class="input-form__form">
        <label for="firstName" class="input-form__label"></label>
        <div class="input-form__inputs">
          <div class="input-form__inputs-forms">
            <input
              v-model="firstName"
              type="text"
              id="firstName"
              name="firstName"
              required
              class="input-form__input input-form__input--margin-right"
              placeholder="Введите имя"
            />

            <label for="lastName" class="input-form__label"></label>
            <input
              v-model="lastName"
              type="text"
              id="lastName"
              name="lastName"
              required
              class="input-form__input"
              placeholder="Введите фамилию"
            />
          </div>

          <button type="submit" class="input-form__inputs-button">
            Добавить
          </button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import api from '@/api';
import emitter from '@/store/emitter'; //служит для создания и отправки события 'updateNames', которое слушается в компоненте NamesList

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

        // сбрасываем поля ввода
        this.firstName = '';
        this.lastName = '';

        // эмитируем событие для обновления списка
        emitter.emit('updateNames');
      });
    },
  },
};
</script>

<style>
/*Main styles*/
* {
  box-sizing: border-box;
}

/*Fonts*/
* {
  font-family: Roboto, Helvetica, sans-serif;
  font-size: 14px;
}

/*Elements*/
.input-form {
  margin: 2em auto;
  width: 70%;
}

.input-form__container {
  width: 70%;
  text-align: left;
  border: solid;
  border-width: 3px;
  border-radius: 5px;
  padding: 10px 20px;
}

.input-form__separator {
  margin: 2em auto;

  border: none;
  border-top: 2px solid black;
}

.input-form__input {
  padding: 8px;
  font-family: 'Roboto', sans-serif;
  font-size: 1em;
  border-radius: 5px;
  margin: 3px 0px;
}

.input-form__input:hover {
  border-width: 3px;
}

.input-form__inputs {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.input-form__input--margin-right {
  margin-right: 10px;
}

.input-form__inputs-button {
  padding: 8px 20px;
  font-size: 1em;
  background-color: #42b983;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin: 3px 0px;
}

.input-form__inputs-button:hover {
  background-color: #000000;
  color: white;
}

/*Media Queries*/
/*XS*/

@media (max-width: 576px) {
  body {
    font-size: 12px;
  }
  .input-form {
    width: 95%;
  }
  .input-form__container {
    width: 100%;
  }
  .input-form__inputs {
    display: block;
  }
  .input-form__inputs-button,
  .input-form__input {
    width: 100%;
  }
}

/*S*/

@media (min-width: 576px) and (max-width: 768px) {
  .input-form__container {
    width: 100%;
  }
}
</style>
