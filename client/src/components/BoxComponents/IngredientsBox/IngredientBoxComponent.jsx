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
import axios from "axios";

function IngredientBoxComponent({ setIngredientArray }) {
  const [nameOfIngredient, setNameOfIngredient] = useState("");
  const [ingredientId, setIngredientId] = useState("");
  const [quantity, setQuantity] = useState(0);
  const [unitMeasure, setUnitMeasure] = useState("");
  const [responseData, setResponseData] = useState([]);

  const handleChangeUnitMeasure = (event) => {
    setUnitMeasure(event.target.value);
  };
  const viewUnitMeasure = [];

  responseData.map((item) => {
    if (item.name == nameOfIngredient) {
      if (item.purchaseUnitMeasure == "kg" || item.purchaseUnitMeasure == "g") {
        viewUnitMeasure.push({ unitMeasure: "kg" }, { unitMeasure: "g" });
      } else if (item.purchaseUnitMeasure == "l" || item.purchaseUnitMeasure == "ml") {
        viewUnitMeasure.push({ unitMeasure: "l" }, { unitMeasure: "ml" });
      }
    }
  });

  const handleChangeName = (event) => {
    setNameOfIngredient(event.target.value);
  };

  useEffect(() => {
    axios
      .get(`https://localhost:5001/api/Ingredients`)
      .then((res) => {
        const allIngredients = res.data.data;
        setResponseData(allIngredients);
      });
  }, []);

  const addIngredient = (e) => {
        e.preventDefault();;

    const ingridentAdd = {
      nameOfIngredient: nameOfIngredient,
      ingredientId: ingredientId,
      quantity: quantity,
      unitMeasure: unitMeasure,
    };
    setIngredientArray((recipeArray) => [...recipeArray, ingridentAdd]);
    setNameOfIngredient("");
    setQuantity("");
    setUnitMeasure("");
    setIngredientId("");
  };

  return (
    <Fragment>
      <Box component="form" onSubmit={addIngredient}>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <FormControl sx={{ width: "80%" }}>
              <InputLabel id="demo-simple-select-label">
                Ingredients:
              </InputLabel>
              <Select
                required
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={nameOfIngredient}
                label="Ingredients"
                onChange={handleChangeName}
                name={ingredientId}
              >
                {responseData.map((item) => (
                  <MenuItem
                    onClick={() => setIngredientId(item.id.toString())}
                    key={item.id}
                    value={item.name}
                  >
                    {item.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={6}>
            <TextField
              required
              sx={{ width: "80%" }}
              label="Quantity"
              value={quantity}
              type="number"
              onChange={(e) => setQuantity(e.target.value)}
            />
          </Grid>
          <Grid item xs={6}>
            <FormControl sx={{ width: "80%" }}>
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
                {viewUnitMeasure.map((item, index) => (
                  <MenuItem key={index} value={item.unitMeasure}>
                    {item.unitMeasure}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
        </Grid>
        <Button
          type="submit"
          sx={{ marginTop: "15px", marginBottom: "15px" }}
          variant="contained"
        >
          Add ingredient
        </Button>
      </Box>
    </Fragment>
  );
}

export default IngredientBoxComponent;
