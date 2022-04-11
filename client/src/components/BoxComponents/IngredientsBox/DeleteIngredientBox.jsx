import React, { Fragment, useState,useEffect } from "react";
import axios from "axios";
import { Button, TextField } from "@mui/material";
import { useSelector } from "react-redux";
import { Box } from "@mui/system";

function DeleteIngredientBox({ trigger, setTrigger }) {
    
  const [ingredientId, setIngredientId] = useState("");
  const loginToken = useSelector((state) => state.login.loginToken);
  const ingredientList = useSelector(
    (state) => state.ingredients.allIngredients
  );

  useEffect(() => {
    const found = ingredientList.some((el) => el.id == ingredientId);
    if (found == false) {
        return
    } else if (found == true) {
      return
    }
  }, [ingredientId]);

  const deleteIngredientFunc = (e) => {
        e.preventDefault();
    setTrigger(trigger + 1);
    let config = {
      headers: { Authorization: `Bearer ${loginToken}` },
    };

    axios
      .delete(`https://localhost:5001/api/Ingredients/${ingredientId}`,config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
      setIngredientId("");
  };

  return (
    <Fragment>
       <Box
        sx={{ marginTop: "20px" }}
        component="form"
        onSubmit={deleteIngredientFunc}
      >
      <TextField
        required
        sx={{marginRight:"10px",marginBottom:"30px"}}
        value={ingredientId}
        label="Ingredient Id"
        onChange={(e) => setIngredientId(e.target.value)}
      ></TextField>
      <Button
        style={{ marginTop: "10px", marginLeft: "10px",backgroundColor:"red" }}
        type="submit"
        variant="contained"
      >
        Delete
      </Button>
      </Box>
    </Fragment>
  );
}

export default DeleteIngredientBox;
