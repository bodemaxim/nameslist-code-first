import axios from 'axios';

const API_BASE_URL = 'http://localhost:5269/api';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default {
  userCreate(firstName, lastName) {
    return api
      .post('/Names', { firstName, lastName })
      .then((response) => response.data)
      .catch((error) => {
        console.error('Ошибка при создании пользователя:', error);
        throw error;
      });
  },
  userList() {
    return api
      .get('/Names') // Проверьте путь к вашему эндпоинту
      .then((response) => response.data)
      .catch((error) => {
        console.error('Ошибка при получении списка пользователей:', error);
        throw error;
      });
  },
};

/*
export default {
  userCreate() {
    fetch('http://localhost:5269/api/Names', {
      method: 'POST',
      mode: 'no-cors',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        id: 0,
        firstName: 'string',
        lastName: 'string',
      }),
    });
    // const formData = new FormData();
    // formData.append('firstName', firstName);
    // formData.append('lastName', lastName);
    // formData.append('id', 0);

    // fetch('http://localhost:5269/api/Names', {
    //   method: 'POST',
    //   body: formData,
    // });
  },
  userList() {
    return fetch('http://localhost:5269/api/Names').then((response) =>
      response.json()
    );
  },
};
*/
