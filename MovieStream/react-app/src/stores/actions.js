export const increment = () => ({
    type: 'INCREMENT',
  });
  
  export const decrement = () => ({
    type: 'DECREMENT',
  });
  export const setToken = (token) => {
    localStorage.setItem('token', token); // Token'i localStorage'a kaydet
    return {
      type: 'SET_TOKEN',
      payload: token,
    }
  };
  export const setResfreshToken = (token) => ({
    type: 'SET_REFRESH_TOKEN',
    payload: token,
  });
  