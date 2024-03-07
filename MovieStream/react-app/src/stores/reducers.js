// reducers.js

const initialState = {
    token: null,
    refreshToken: null,
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
  
  export default rootReducer;
  