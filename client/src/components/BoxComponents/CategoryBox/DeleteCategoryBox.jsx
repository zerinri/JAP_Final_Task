import React, { Fragment, useState,useEffect } from "react";
import axios from "axios";
import { Box, Button, TextField } from "@mui/material";
import { useSelector } from "react-redux";

function DeleteCategoryBox({ trigger, setTrigger }) {
  const [categoryId, setCategoryId] = useState("");
  const loginToken = useSelector((state) => state.login.loginToken);
  const categoryList = useSelector(
    (state) => state.categories.allCategories
  );

  useEffect(() => {
    const found = categoryList.some((el) => el.id == categoryId);
    if (found == false) {
        return
    } else if (found == true) {
      return
    }
  }, [categoryId]);

  const deleteCategoryFunc = (e) => {
        e.preventDefault();
    setTrigger(trigger + 1);

    let config = {
      headers: { Authorization: `Bearer ${loginToken}` },
    };

    axios
      .delete(`https://localhost:5001/api/Categories/${categoryId}`,config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
      setCategoryId("");
  };

  return (
    <Fragment>
        <Box sx={{ marginTop: "20px",marginBottom:"20px" }} component="form" onSubmit={deleteCategoryFunc}>
      <TextField
      required
      sx={{marginRight:"10px"}}
        value={categoryId}
        label="Category Id"
        onChange={(e) => setCategoryId(e.target.value)}
      ></TextField>
      <Button
        sx={{ marginTop: "10px", marginLeft: "10px",backgroundColor:"red" }}
        type="submit"
        variant="contained"
      >
        Delete
      </Button>
      </Box>
    </Fragment>
  );
}

export default DeleteCategoryBox;
