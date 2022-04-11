import React, { Fragment, useState } from "react";
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

function AddIngredientBox({ setTrigger, trigger }) {
  const [nameOfIngredient, setNameOfIngredient] = useState("");
  const [ingredientPrice, setIngredientPrice] = useState(0);
  const [quantity, setQuantity] = useState(0);
  const [unitMeasure, setUnitMeasure] = useState("");
  
  const unitMeasureList = [
    { unit: "kg" },
    { unit: "g" },
    { unit: "l" },
    { unit: "ml" },
  ];
  const loginToken = useSelector((state) => state.login.loginToken);

  const handleChangeUnitMeasure = (event) => {
    setUnitMeasure(event.target.value);
  };

  const addIngredient = (e) => {
        e.preventDefault();;
    setTrigger(trigger + 1);
    let config = {
      headers: { Authorization: `Bearer ${loginToken}` },
    };

    const ingridentAdd = {
      name: nameOfIngredient,
      purchaseQuantity: quantity,
      purchaseUnitMeasure: unitMeasure,
      purchasePrice: ingredientPrice,
    };

    axios
      .post("https://localhost:5001/api/Ingredients", ingridentAdd, config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

    setNameOfIngredient("");
    setQuantity("");
    setUnitMeasure("");
    setIngredientPrice("");
  };
  return (
    <Fragment>
      <Box sx={{ marginTop: "20px" }} component="form" onSubmit={addIngredient}>
        <Grid container spacing={2}>
          <Grid item xs={6}>
            <TextField
              sx={{ width: "90%" }}
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
          sx={{ marginTop: "15px", marginBottom: "15px",backgroundColor:"green" }}
          variant="contained"
        >
          Add ingredient
        </Button>
      </Box>
    </Fragment>
  );
}

export default AddIngredientBox;
