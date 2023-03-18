import { configureStore } from '@reduxjs/toolkit';
import storage from 'redux-persist/lib/storage';
import { combineReducers } from 'redux';
import { persistReducer } from 'redux-persist'
import thunk from 'redux-thunk';

import authReducer from './../slices/authSlice';

const reducer = combineReducers({
    auth: authReducer
});

//blacklist: After render state will reset to init
//whitelist: After render state will not update your current state update
const persistConfig = {
    key: 'root',
    storage,
    whitelist: ['auth'],
    // blacklist: ['auth']
};

const persistedReducer = persistReducer(persistConfig, reducer);

const store = configureStore({
    reducer: persistedReducer,
    middleware: [thunk]
})

export default store;
