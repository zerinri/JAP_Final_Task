import { createSlice } from '@reduxjs/toolkit'

export const counterSlice = createSlice({
  name: 'ingredients',
  initialState :{
    allIngredients : []
  },
  reducers: {
    setIngredients: (state,action) => {
      state.allIngredients = action.payload
    },
  },
})
export const { setIngredients } = counterSlice.actions

export default counterSlice.reducer