import React, { Fragment, useState, useEffect } from "react";
import {
  Grid,
  TextField,
  Select,
  MenuItem,
  FormControl,
  InputLabel,
  Button,
} from "@mui/material";
import { Box } from "@mui/system";
import { useSelector } from "react-redux";
import axios from "axios";

function UpdateIngredientBox({setTrigger,trigger}) {
  const [ingredientId, setIngredientId] = useState("");
  const [nameOfIngredient, setNameOfIngredient] = useState("");
  const [ingredientPrice, setIngredientPrice] = useState("");
  const [quantity, setQuantity] = useState("");
  const [unitMeasure, setUnitMeasure] = useState("");
  const [disable, setDisable] = useState(true);

  const loginToken = useSelector((state) => state.login.loginToken);
  const ingredientList = useSelector(
    (state) => state.ingredients.allIngredients
  );

  const unitMeasureList = [
    { unit: "kg" },
    { unit: "g" },
    { unit: "l" },
    { unit: "ml" },
  ];

  const handleChangeUnitMeasure = (event) => {
    setUnitMeasure(event.target.value);
  };

  useEffect(() => {
    const found = ingredientList.some((el) => el.id == ingredientId);
    if (found == false) {
      setNameOfIngredient("");
      setIngredientPrice("");
      setQuantity("");
      setUnitMeasure("");
      setDisable(true);
    } else if (found == true) {
      var item = ingredientList.find((item) => item.id == ingredientId);
      console.log(item);
      setNameOfIngredient(item.name);
      setIngredientPrice(item.purchasePrice);
      setQuantity(item.purchaseQuantity);
      setUnitMeasure(item.purchaseUnitMeasure);
      setDisable(false);
    }
  }, [ingredientId]);

  const updateIngredient = (e) => {
        e.preventDefault();;
    setTrigger(trigger + 1);
    let config = {
      headers: { Authorization: `Bearer ${loginToken}` },
    };
    const ingridentUpdate = {
      id: ingredientId,
      name: nameOfIngredient,
      purchaseQuantity: quantity,
      purchaseUnitMeasure: unitMeasure,
      purchasePrice: ingredientPrice,
    };
    axios
      .put("https://localhost:5001/api/Ingredients", ingridentUpdate, config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

    setIngredientId("");
    setNameOfIngredient("");
    setQuantity("");
    setUnitMeasure("");
    setIngredientPrice("");
  };
  return (
    <Fragment>
      <Box
        sx={{ marginTop: "20px" }}
        component="form"
        onSubmit={updateIngredient}
      >
        <Grid container spacing={2}>
          <Grid item xs={3}>
            <TextField
              sx={{ width: "80%" }}
              required
              value={ingredientId}
              onChange={(e) => setIngredientId(e.target.value)}
              label="Id"
              type="number"
            />
          </Grid>
          <Grid item xs={3}>
            <TextField
              disabled={disable}
              sx={{ width: "80%" }}
              required
              value={nameOfIngredient}
              onChange={(e) => setNameOfIngredient(e.target.value)}
              label="Name of ingredient"
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ width: "90%" }}>
              <InputLabel id="demo-simple-select-label">
                Unit Measure:
              </InputLabel>
              <Select
                disabled={disable}
                required
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={unitMeasure}
                label="Unit Measure:"
                onChange={handleChangeUnitMeasure}
              >
                {unitMeasureList.map((item, index) => (
                  <MenuItem key={index} value={item.unit}>
                    {item.unit}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <TextField
              disabled={disable}
              required
              sx={{ width: "90%" }}
              label="Quantity"
              value={quantity}
              type="number"
              onChange={(e) => setQuantity(e.target.value)}
            />
          </Grid>
          <Grid item xs={6}>
            <TextField
              disabled={disable}
              required
              sx={{ width: "90%" }}
              label="Price of ingredient"
              value={ingredientPrice}
              type="number"
              onChange={(e) => setIngredientPrice(e.target.value)}
            />
          </Grid>
        </Grid>
        <Button
          type="submit"
          sx={{ marginTop: "15px", marginBottom: "15px" }}
          variant="contained"
        >
          Update ingredient
        </Button>
      </Box>
    </Fragment>
  );
}

export default UpdateIngredientBox;
