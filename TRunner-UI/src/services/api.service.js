import reqInstance from '../config/axios/reqInstance';

export class ApiService {
  constructor() {
    const service = reqInstance;
    this.service = service;
  }

  handleErrorResponse = (err) => {
    let message = ''
    if (err && err.response) {
      const data = err.response.data;
      if (data.status === 400) {
        message = data.message;
      }
    }
    return message;
  }

  async get(path) {
    return this.service.get(path).then(data => {
      return data;
    }).catch(err => {
      let message = '';
      message = this.handleErrorResponse(err);
      const error = new Error(message);
      return Promise.reject(error);
    });
  }

  async post(path, payload) {
    return this.service.request({
      method: 'POST',
      url: path,
      responseType: 'json',
      data: payload
    }).then(data => {
      return data;
    }).catch(err => {
      let message = '';
      message = this.handleErrorResponse(err);
      console.log("error", message);
      const error = new Error(message);
      return Promise.reject(error);
    });
  }

  async put(path, payload) {
    return this.service.request({
      method: 'PUT',
      url: path,
      responseType: 'json',
      data: payload
    }).then(data => {
      return data;
    }).catch(err => {
      let message = '';
      message = this.handleErrorResponse(err);
      const error = new Error(message);
      return  Promise.reject(error);
    });
  }

  async delete(path, payload) {
    return this.service.request({
      method: 'DELETE',
      url: path,
      responseType: 'json',
      data: payload
    }).then(data => {
      return data;
    }).catch(err => {
      let message = '';
      message = this.handleErrorResponse(err);
      const error = new Error(message);
      return Promise.reject(error);
    });
  }
}

export default new ApiService;
