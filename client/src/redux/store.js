import { configureStore } from "@reduxjs/toolkit";
import categories from "./categories";
import ingredients from "./ingredients";
import login from "./login";

export const store = configureStore({
  reducer: {
    categories: categories,
    login: login,
    ingredients:ingredients,
  },
});
