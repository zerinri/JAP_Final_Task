import React, { Fragment } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { useSelector } from "react-redux";
import AddRecipePage from "../Pages/AddRecipePage/AddRecipePage";
import CategoryListPage from "../Pages/ListPages/CategoryListPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import ViewRecipePage from "../Pages/ViewRecipePage/ViewRecipePage";
import RecipeListPage from "../Pages/ListPages/RecipeListPage";
import ModifyIngredientPage from "../Pages/ModifyIngredientPage/ModifyIngredientPage";
import ModifyCategoriesPage from "../Pages/ModifyCategoriesPage/ModifyCategoriesPage";

function MainRouter() {
  const loginState = useSelector((state) => state.login.loginState);
  return (
    <Fragment>
      <BrowserRouter>
        <Routes>
          <Route index element={<CategoryListPage />} />
          <Route path="/login" element={<LoginPage />} />
          {loginState && (
            <>
              <Route path="/addRecipe" element={<AddRecipePage />} />
              <Route path="/modifyIngredient" element={<ModifyIngredientPage />} />
              <Route path="/modifyCategory" element={<ModifyCategoriesPage />} />
            </>
          )}
          <Route path="/categories" element={<CategoryListPage />} />
          <Route path="/categories/:id" element={<RecipeListPage />} />
          <Route path="/viewRecipe/:id" element={<ViewRecipePage />} />
          <Route path="/viewRecipe/:search" element={<ViewRecipePage />} />
        </Routes>
      </BrowserRouter>
    </Fragment>
  );
}

export default MainRouter;
