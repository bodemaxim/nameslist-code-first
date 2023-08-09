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
      .get('/Names')
      .then((response) => response.data)
      .catch((error) => {
        console.error('Ошибка при получении списка пользователей:', error);
        throw error;
      });
  },
};
