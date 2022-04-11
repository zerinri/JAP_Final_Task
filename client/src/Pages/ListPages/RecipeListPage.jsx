import React, { Fragment, useEffect, useState } from "react";
import MainGridComponent from "../../components/MainGrid/MainGridComponent";
import axios from "axios";
import { useParams } from "react-router-dom";
import { Button, TextField } from "@mui/material";
import Navbar from "../../navbar/Navbar";

function RecipeListPage() {
  const recipeObject = { title: "Recipes:", hrefLocation: "/viewRecipe/" };
  const [responseData, setResponseData] = useState([]);
  const [limit, setLimit] = useState(0);
  const [search, setSearch] = useState("");
  const [disabled, setDisabled] = useState(true);
  const { id } = useParams();

  useEffect(() => {
    axios
      .get(`https://localhost:5001/api/Recipes/GetRecipeByCategoryId`, {
        params: { CategoryId: id, Skip: limit, PageSize: 5 },
      })
      .then((res) => {
        const allRecipes = res.data.data;
        setResponseData(allRecipes);
      });
  }, [id, limit]);

  const searchByRecipe = () => {
    axios
      .get(`https://localhost:5001/api/Recipes/GetRecipeBySearch/${search}`)
      .then((res) => {
        const allRecipes = res.data.data;
        setResponseData(allRecipes);
      });
    setSearch("");
    setDisabled(true);
  };

  const searchItems = (searchValue) => {
    setSearch(searchValue);
    if (searchValue == "") {
      setDisabled(true);
    } else {
      setDisabled(false);
    }
  };
  return (
    <Fragment>
      <Navbar />
      <br />
      <div
        style={{ marginLeft: "60px", marginBottom: "-30px" }}
      >
        <TextField
          value={search}
          label="Search"
          onChange={(e) => searchItems(e.target.value)}
        ></TextField>
        <Button
          variant="contained"
          disabled={disabled}
          style={{ marginTop: "10px", marginLeft: "10px" }}
          onClick={() => searchByRecipe()}
        >
          Search
        </Button>
      </div>
      <MainGridComponent
        limit={limit}
        setLimit={setLimit}
        setResponseData={setResponseData}
        defaultObject={recipeObject}
        responseData={responseData}
      />
    </Fragment>
  );
}

export default RecipeListPage;
