import { createSlice } from "@reduxjs/toolkit";

export const counterSlice = createSlice({
  name: "login",
  initialState: {
    loginState: false,
    loginToken:""
  },
  reducers: {
    setLoginState: (state, action) => {
      state.loginState = action.payload;
    },
    setLoginToken: (state, action) => {
      state.loginToken = action.payload;
    },
  },
});
export const { setLoginState,setLoginToken } = counterSlice.actions;

export default counterSlice.reducer;
