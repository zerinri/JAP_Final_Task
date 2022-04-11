import React, { Fragment, useState,useEffect } from "react";
import axios from "axios";
import { Button, TextField } from "@mui/material";
import { useSelector } from "react-redux";
import { Box } from "@mui/system";

function UpdateCategoryBox({ trigger, setTrigger }) {
  const [categoryName, setCategoryName] = useState("");
  const [categoryId, setCategoryId] = useState("");
  const loginToken = useSelector((state) => state.login.loginToken);
  const [disable, setDisable] = useState(true);
  const categoryList = useSelector(
    (state) => state.categories.allCategories
  );

  useEffect(() => {
    const found = categoryList.some((el) => el.id == categoryId);
    if (found == false) {
    setCategoryName("");
      setDisable(true);
    } else if (found == true) {
      var item = categoryList.find((item) => item.id == categoryId);
      setCategoryName(item.name);
      setDisable(false);
    }
  }, [categoryId]);

  const updateCategoryFunc = (e) => {
        e.preventDefault();
    setTrigger(trigger + 1);
    const updateCategory = {
      id: categoryId,
      name: categoryName,
    };

    let config = {
      headers: { Authorization: `Bearer ${loginToken}` },
    };

    axios
      .put("https://localhost:5001/api/Categories", updateCategory, config)
      .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    setCategoryName("");
    setCategoryId("")
  };

  return (
    <Fragment>
      <Box sx={{ marginTop: "20px",marginBottom:"20px" }} component="form" onSubmit={updateCategoryFunc}>
      <TextField
      required
      sx={{marginRight:"10px"}}
        value={categoryId}
        label="Category Id"
        onChange={(e) => setCategoryId(e.target.value)}
      ></TextField>
      <TextField
      disabled={disable}
        value={categoryName}
        label="Update Category"
        onChange={(e) => setCategoryName(e.target.value)}
      ></TextField>
      <Button
        sx={{ marginTop: "10px", marginLeft: "10px", }}
        onClick={updateCategoryFunc}
        variant="contained"
        type="submit"
      >
        Update
      </Button>
      </Box>
    </Fragment>
  );
}

export default UpdateCategoryBox;
