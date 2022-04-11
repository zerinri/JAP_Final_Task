import React, { Fragment, useState, useLayoutEffect } from "react";
import Navbar from "../../navbar/Navbar";
import { useParams } from "react-router-dom";
import axios from "axios";
import ViewRecipeBox from "../../components/BoxComponents/RecipeBox/ViewRecipeBox";
import { setCategory } from "../../redux/categories";
import { useDispatch, useSelector } from "react-redux";
import ViewRecipeIngBox from "./ViewRecipeIngBox";

function ViewRecipePage() {
  const { id } = useParams();
  const [responseData, setResponseData] = useState([]);
  const[ingredientArray, setIngredientArray]= useState([]);
  const loginState = useSelector((state) => state.login.loginState);
  const dispatch = useDispatch();

  useLayoutEffect(() => {
    axios.get(`https://localhost:5001/api/Categories/all`).then((res) => {
      const allCategories = res.data.data;
      dispatch(setCategory(allCategories));
    });
    axios
      .get(`https://localhost:5001/api/Recipes/GetRecipeById/${id}`)
      .then((res) => {
        const allRecipes = res.data.data;
        setResponseData(allRecipes);
      });
  }, []);

  return (
    <Fragment>
      <Navbar />
      <br />
      <ViewRecipeBox responseData={responseData} loginState={loginState} recipeId={id} ingredientArray={ingredientArray}/>
      <ViewRecipeIngBox
        setIngredientArray={setIngredientArray}
        responseData={responseData.ingredients}
        loginState={loginState}
      />
    </Fragment>
  );
}

export default ViewRecipePage;
