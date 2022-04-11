import React, { Fragment, useState } from "react";
import { useSelector } from "react-redux";
import axios from "axios"
import {
  Grid,
  Container,
  Typography,
  TextField,
  Select,
  MenuItem,
  FormControl,
  List,
  InputLabel,
  ListItem,
  ListItemText,
  Button,
  Divider,
  Snackbar,
} from "@mui/material";
import {
  recipeGrid,
  recipeList,
  recipeTextField,
  recipeContainerTwo,
} from "./RecipeComponentStyle"
import { Box } from "@mui/system";

function RecipeBoxComponent({ ingredientArray, setIngredientArray,modifyRecipe }) {
  const [nameOfRecipe, setNameofRecipe] = useState("");
  const [categoryRecipe, setCategoryRecipe] = useState("");
  const [descriptionRecipe, setDescriptionRecipe] = useState("");
  const [openSnack, setOpenSnack] = useState(false);
  const categories = useSelector((state) => state.categories.allCategories);
  const loginToken = useSelector((state) => state.login.loginToken);
  
   const handleChangeCategory = (event) => {
    setCategoryRecipe(event.target.value);
  };

  const addDetails = (e) => {
    e.preventDefault();
    let config = {
      headers: { Authorization: `Bearer ${loginToken}`}
    }
    ingredientArray = ingredientArray
      .filter((item) => item.nameOfIngredient)
      .map(({ ingredientId, quantity, unitMeasure }) => ({
        ingredientId,
        quantity,
        unitMeasure,
      }));
    const recipeAdd = {
      name: nameOfRecipe,
      categoryId: categoryRecipe,
      description: descriptionRecipe,
      recipeIngredients: ingredientArray,
    };
    if (ingredientArray.length === 0) {
      return setOpenSnack(true);
    }
    axios
      .post("https://localhost:5001/api/Recipes", recipeAdd,config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    setNameofRecipe("");
    setCategoryRecipe("");
    setDescriptionRecipe("");
    setIngredientArray([]);
  };

  return (
    <Fragment>
      <Snackbar
        open={openSnack}
        onClose={() => setOpenSnack(false)}
        autoHideDuration={4000}
        message="Ingredient list is empty, please add at least 1 ingredient !!"
      />
      <Box sx={{ marginBottom: "50px" }} component="form" onSubmit={addDetails}>
        <Typography sx={{ marginTop: "10px" }} textAlign="left" variant="h4">
         {modifyRecipe ? "Modify Recipe:" : "Add Recipe:"} 
        </Typography>
        <Grid container spacing={2} sx={{ marginTop: "20px", width: "100%" }}>
          <Grid item xs={6}>
            <TextField
              required
              sx={{ width: "90%" }}
              label="Name of the recipe:"
              value={nameOfRecipe}
              onChange={(e) => setNameofRecipe(e.target.value)}
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ width: "90%" }}>
              <InputLabel id="demo-simple-select-label">Category</InputLabel>
              <Select
                required
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={categoryRecipe}
                label="Category"
                onChange={handleChangeCategory}
              >
                {categories.map((item) => (
                  <MenuItem key={item.id} value={item.id}>
                    {item.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
        </Grid>
        <Divider sx={{ marginTop: "20px" }} />
        <Grid container spacing={2} sx={recipeGrid}>
          <Grid item xs={6}>
            <TextField
              required
              value={descriptionRecipe}
              sx={recipeTextField}
              onChange={(e) => setDescriptionRecipe(e.target.value)}
              label="Description"
              multiline
              rows={10}
            />
          </Grid>
          <Grid item xs={6}>
            <Container sx={recipeContainerTwo}>
              <Typography variant="h5">Ingredient list</Typography>
              <List sx={recipeList}>
                {ingredientArray.map((item, index) => (
                  <ListItem key={index}>
                    <ListItemText
                      secondary="Ingredient"
                      primary={item.nameOfIngredient}
                    />
                    <ListItemText
                      secondary={item.unitMeasure}
                      primary={item.quantity}
                    />
                  </ListItem>
                ))}
              </List>
            </Container>
            <Button
              type="submit"
              sx={{ marginTop: "15px" }}
              variant="contained"
            >
              Add Recipe
            </Button>
          </Grid>
        </Grid>
      </Box>
    </Fragment>
  );
}

export default RecipeBoxComponent;
