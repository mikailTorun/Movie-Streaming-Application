// store.js

import { createStore } from 'redux';

const initialState = {
  token: null, // Token bilgisini tutacak alan
  refreshToken: null, // Token bilgisini tutacak alan
};

function rootReducer(state = initialState, action) {
  switch (action.type) {
    case 'SET_TOKEN':
      return { ...state, token: action.payload };
    case 'SET_REFRESH_TOKEN':
      return { ...state, refreshToken: action.payload };
    default:
      return state;
  }
}
const persistedState = localStorage.getItem('reduxState')
  ? JSON.parse(localStorage.getItem('reduxState'))
  : {};
const store = createStore(rootReducer,persistedState );
store.subscribe(() => {
  localStorage.setItem('reduxState', JSON.stringify(store.getState())); // Store güncellendiğinde localStorage'ı güncelle
});

export default store;
