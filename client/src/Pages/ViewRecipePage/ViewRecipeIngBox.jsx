import React, { Fragment, useState, useEffect } from "react";
import {
  Button,
  Table,
  TableRow,
  TableBody,
  TableCell,
  TableHead,
  TableContainer,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  TextField,
} from "@mui/material";
import axios from "axios";
import { Box } from "@mui/system";

function ViewRecipeIngBox({ responseData, loginState, setIngredientArray }) {
  const [listIngredients, setListIngredients] = useState([]);
  const [addIngredientId, setAddIngredientId] = useState("");
  const [addIngQuantity, setAddIngQuantity] = useState("");
  const [addIngUnit, setAddIngUnit] = useState("");
  const [rows, setRows] = useState([]);
  const viewUnitMeasure = [];

  const handleChangeUnitMeasure = (event) => {
    setAddIngUnit(event.target.value);
  };

    listIngredients.map((item) => {
      if (item.id == addIngredientId) {
        if (item.purchaseUnitMeasure == "kg" || item.purchaseUnitMeasure == "g") {
          viewUnitMeasure.push({ unitMeasure: "kg" }, { unitMeasure: "g" });
        } else if (
          item.purchaseUnitMeasure == "l" || item.purchaseUnitMeasure == "ml"
        ) {
          viewUnitMeasure.push({ unitMeasure: "l" }, { unitMeasure: "ml" });
        }
      }
    });



  const handleChangeIngredientId = (event) => {
    setAddIngredientId(event.target.value);

    if (addIngredientId == "") {
      return;
    } else {
      var singleIngredient = listIngredients.filter((x) => {
        return x.id == addIngredientId;
      });
      setAddIngUnit(singleIngredient[0].purchaseUnitMeasure);
    }
  };

  useEffect(() => {
    axios.get("https://localhost:5001/api/Ingredients").then((res) => {
      const allIngredients = res.data.data;
      setListIngredients(allIngredients);
    });
    if (responseData == null) {
      return;
    } else {
      responseData.forEach((item, i) => {
        item.key = i + 1;
      });
      setRows(responseData);
      setIngredientArray(responseData);
    }
  }, [responseData]);

  function deleteItem(key) {
    var lists = rows.filter((x) => {
      return x.key != key;
    });
    setIngredientArray(lists);
    setRows(lists);
  }

  function addItem(e) {
    e.preventDefault();
    var singleIngredient = listIngredients.filter((x) => {
      return x.id == addIngredientId;
    });

    const newIngredient = {
      name: singleIngredient[0].name,
      id: addIngredientId,
      purchaseQuantity: addIngQuantity,
      purchaseUnitMeasure: addIngUnit,
    };
    if (rows.some((el) => el.name == singleIngredient[0].name)) {
      alert("Can't add same ingredient!")
    }else{
      setIngredientArray((rows) => [...rows, newIngredient])
      setRows((rows) => [...rows, newIngredient]);
    }
   
  }

  return (
    <Fragment>
      <TableContainer
        sx={{ height: "auto", maxHeight: 250, width: "auto", margin: "20px" }}
      >
        <Table sx={{ height: "max-content" }}>
          <TableHead
            sx={{
              position: "sticky",
              top: 0,
              backgroundColor: "white",
              zIndex: 1,
            }}
          >
            <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>Quantity</TableCell>
              <TableCell>Unit</TableCell>
              <TableCell>Price</TableCell>
              {loginState && <TableCell>Actions</TableCell>}
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.map((item) => {
              return (
                <TableRow key={item.key}>
                  <TableCell>{item.name}</TableCell>
                  <TableCell>{item.purchaseQuantity}</TableCell>
                  <TableCell>{item.purchaseUnitMeasure}</TableCell>
                  <TableCell>{item.purchasePrice}KM</TableCell>
                  {loginState && (
                    <TableCell>
                      <Button
                        sx={{ backgroundColor: "red" }}
                        onClick={() => deleteItem(item.key)}
                        variant="contained"
                      >
                        Delete
                      </Button>
                    </TableCell>
                  )}
                </TableRow>
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
      {loginState && (    <Box onSubmit={addItem} component="form">
        <FormControl sx={{ width: "20%" }}>
          <InputLabel id="demo-simple-select-label">Ingredients</InputLabel>
          <Select
            required
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={addIngredientId ?? ""}
            label="Ingredients"
            onChange={handleChangeIngredientId}
          >
            {listIngredients.map((item) => (
              <MenuItem key={item.id} value={item.id}>
                {item.name}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <TextField
        type="number"
          required
          value={addIngQuantity ?? ""}
          onChange={(e) => setAddIngQuantity(e.target.value)}
          label="Quantity"
          sx={{ width: "20%", marginLeft: "20px", marginRight: "20px" }}
        ></TextField>
        <FormControl sx={{ width: "20%" }}>
          <InputLabel id="demo-simple-select-label">Unit Measure:</InputLabel>
          <Select
            required
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={addIngUnit}
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
        <br />
        <Button
          sx={{ backgroundColor: "green",marginTop:"10px",marginBottom:"10px" }}
          type="submit"
          variant="contained"
        >
          Add
        </Button>
      </Box>)}
    </Fragment>
  );
}

export default ViewRecipeIngBox;
