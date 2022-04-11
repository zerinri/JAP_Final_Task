import {
  Box,
  TextField,
  FormControl,
  Grid,
  Button,
  InputLabel,
  Select,
  MenuItem,
} from "@mui/material";
import React, { Fragment, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function ViewRecipeBox({
  ingredientArray,
  responseData,
  loginState,
  recipeId,
}) {
  const [category, setCategory] = useState("");
  const [recipeName, setRecipeName] = useState("");
  const [recipeDesc, setRecipeDesc] = useState("");
  const [totalCost, setTotalCost] = useState("");
  const loginToken = useSelector((state) => state.login.loginToken);
  const categoriesList = useSelector((state) => state.categories.allCategories);
  const navigate = useNavigate();
  let config = {
    headers: { Authorization: `Bearer ${loginToken}` },
  };

  const handleChangeCategory = (event) => {
    setCategory(event.target.value);
  };

  useEffect(() => {
    if (responseData == null) {
      return;
    } else {
      setRecipeName(responseData.name);
      setRecipeDesc(responseData.description);
      setTotalCost(responseData.totalCost);
      var obj = categoriesList.find(
        (find) => find.name == responseData.category
      );
      if (obj == null) {
        return;
      } else {
        setCategory(obj.id);
      }
    }
  }, [responseData]);

  function deleteRecipe() {
    axios
      .delete(`https://localhost:5001/api/Recipes/${recipeId}`,config)
      .then((res) => {
        console.log(res)
      }).catch((error)=>{
        console.log(error)
      });
      navigate("/")
  }

  function updateRecipe(e) {
    e.preventDefault();
   
    ingredientArray = ingredientArray
      .filter((item) => item.name)
      .map(({ id, purchaseQuantity, purchaseUnitMeasure }) => ({
        ingredientId: id,
        unitMeasure: purchaseUnitMeasure,
        quantity: purchaseQuantity,
      }));
    const recipeUpdate = {
      id: recipeId,
      name: recipeName,
      categoryId: category,
      description: recipeDesc,
      ingredients: ingredientArray,
    };
    axios
      .put("https://localhost:5001/api/Recipes", recipeUpdate, config)
      .then((res) => {
        console.log(res)
      }).catch((error)=>{
        console.log(error)
      });
  }

  return (
    <Fragment>
      <Box component="form" onSubmit={updateRecipe}>
        <Grid container spacing={2}>
          <Grid item xs={4} md={4}>
            <TextField
              disabled={!loginState}
              value={recipeName ?? ""}
              onChange={(e) => setRecipeName(e.target.value)}
              label="Name"
              sx={{ width: "auto" }}
            ></TextField>
          </Grid>
          <Grid item xs={4} md={4}>
            <FormControl sx={{ width: "90%" }}>
              <InputLabel id="demo-simple-select-label">Category</InputLabel>
              <Select
                disabled={!loginState}
                required
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={category ?? ""}
                label="Category"
                onChange={handleChangeCategory}
              >
                {categoriesList.map((item) => (
                  <MenuItem key={item.id} value={item.id}>
                    {item.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={4} md={4}>
            <TextField
              disabled={true}
              label="TotalCost"
              value={totalCost + " KM" ?? ""}
              sx={{ width: "auto" }}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              disabled={!loginState}
              value={recipeDesc ?? ""}
              onChange={(e) => setRecipeDesc(e.target.value)}
              multiline
              rows={6}
              sx={{ width: "90%" }}
              label="Description"
            ></TextField>
          </Grid>
        </Grid>
        {loginState && (
          <>
          <Button
            type="submit"
            variant="contained"
            sx={{marginTop:"10px" }}
          >
            Update Recipe
          </Button>
             <Button
             onClick={deleteRecipe}
             variant="contained"
             sx={{marginTop:"10px",marginLeft:"10px",backgroundColor:"red" }}
           >
             Delete Recipe
           </Button>
           </>
        )}
      </Box>
    </Fragment>
  );
}

export default ViewRecipeBox;
