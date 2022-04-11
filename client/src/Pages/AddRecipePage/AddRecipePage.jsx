import React, { Fragment, useState } from "react";
import Navbar from "../../navbar/Navbar";
import { Container } from "@mui/material";
import { recipeContainer } from "./AddRecipeStyle";
import RecipeBoxComponent from "../../components/BoxComponents/RecipeBox/RecipeBoxComponent";
import IngredientBoxComponent from "../../components/BoxComponents/IngredientsBox/IngredientBoxComponent";

function AddRecipePage() {
  const [ingredientArray, setIngredientArray] = useState([]);
   
  return (
    <Fragment>
      <Navbar />
      <Container maxWidth="hg" sx={recipeContainer}>
        <RecipeBoxComponent
          ingredientArray={ingredientArray}
          setIngredientArray={setIngredientArray}
        />
        <IngredientBoxComponent
          ingredientArray={ingredientArray}
          setIngredientArray={setIngredientArray}
        />
      </Container>
    </Fragment>
  );
}

export default AddRecipePage;
