import axios from 'axios';

const reqInstance = axios.create({
  baseURL: process.env.REACT_APP_TRUNNER_API_URL,
  headers: {
    'Content-type': 'application/json',
    'Accept': 'application/json'
  }
});

// reqInstance.interceptors.request.use(
//   async (config) => {
//     const token = localStorage.getItem('userToken');
//     if (token) {
//       config.headers.accessToken = token;
//     }
//     return config;
//   },
//   function (error) {
//     console.log("error");
//     return Promise.reject(error);
//   }
// );
// Response interceptor for API calls
reqInstance.interceptors.response.use(
  (response) => {
    if (response && response.data) {
      return response.data;
    }
    return response;
  },
  (error) => {

    // Handle errors
    return Promise.reject(error);
  }
);
export default reqInstance;
