import { createSlice } from '@reduxjs/toolkit'

export const counterSlice = createSlice({
  name: 'categories',
  initialState :{
    allCategories : []
  },
  reducers: {
    setCategory: (state,action) => {
      state.allCategories = action.payload
    },
  },
})
export const { setCategory } = counterSlice.actions

export default counterSlice.reducer