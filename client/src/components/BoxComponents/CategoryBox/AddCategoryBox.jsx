import React, { Fragment, useState } from "react";
import axios from "axios";
import { Button, TextField } from "@mui/material";
import { useSelector } from "react-redux";
import { Box } from "@mui/system";

function AddCategoryBox({trigger,setTrigger}) {
  const [categoryName, setCategoryName] = useState("");
  const loginToken = useSelector((state) => state.login.loginToken);

  const addCategoryFunc = (e) => {
        e.preventDefault();
    setTrigger(trigger + 1);
    const addCategory = {
      name: categoryName,
    };

    let config = {
      headers: { Authorization: `Bearer ${loginToken}` },
    };

    axios
      .post("https://localhost:5001/api/Categories", addCategory, config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    setCategoryName("");
  };
  return (
    <Fragment>
        <Box sx={{ marginTop: "20px",marginBottom:"20px" }} component="form" onSubmit={addCategoryFunc}>
      <TextField
      required
        value={categoryName}
        label="Add Category"
        onChange={(e) => setCategoryName(e.target.value)}
      ></TextField>
      <Button
        sx={{ marginTop: "10px", marginLeft: "10px",backgroundColor:"green" }}
        onClick={addCategoryFunc}
        variant="contained"
        type="submit"

      >
        Add
      </Button>
      </Box>
    </Fragment>
  );
}

export default AddCategoryBox;
