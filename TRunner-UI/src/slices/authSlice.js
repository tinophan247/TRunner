import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import ApiGateWay from '../services/apiGateWay';


export const login = createAsyncThunk(
  'auth/login',
  async (payload) => {
    const response = await ApiGateWay.loginUser(payload);
    return response;
  }
)

const initialAuthState = {
  isLoading: false,
  isLoggedIn: false,
  credentials: {
    email: '',
    name: '',
    avatar: '',
    roleName: ''
  },
  error: false,
  errorMessage: ''
};
const authSlice = createSlice({
  name: 'auth',
  initialState: initialAuthState,
  reducers: {
    logout: () => initialAuthState,

  },
  extraReducers: (builder) => {
    // Start login request
    builder.addCase(login.pending, (state) => {
      state.isLoading = true;
    });

    // Request successful
    builder.addCase(login.fulfilled, (state, action) => {
      state.isLoading = false;
      state.isLoggedIn = true;
      state.credentials = {
        email: action.payload.email,
        name: action.payload.displayName,
        roleName: action.payload.roleName,
        avatar: action.payload.avatar
      }
    });

    // Request error
    builder.addCase(login.rejected, (state, action) => {
      state.isLoggedIn = false;
      state.isLoading = false;
      state.error = true;
      state.errorMessage = action.error.message;
    });
  }
});

export const authActions = authSlice.actions;
export default authSlice.reducer;