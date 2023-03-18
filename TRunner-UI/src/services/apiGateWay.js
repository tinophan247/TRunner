import { ApiService } from './api.service';

export class ApiGateWay extends ApiService {

  loginUser(payload) {
    return this.post('/login', payload);
  };
}
export default new ApiGateWay;