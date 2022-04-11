import React from "react";
import { Grid, Container, Typography, Button } from "@mui/material";
import { Fragment } from "react";
import GridComponent from "../GridComponent/GridComponent";

import {
  categoryGrid,
  categoryContainer,
  categoryButton,
} from "./MainGridStyle";

function MainGridComponent({ defaultObject, responseData, setLimit, limit }) {
  const limitAdd = () => {
    if (limit >= 0) {
      setLimit(limit + 5);
    }
  };
  const limitBack = () => {
    if (limit < 0) {
      setLimit(0);
    } else if (limit > 0) {
      setLimit(limit - 5);
    }
  };

  return (
    <Fragment>
      <Container maxWidth="hg" sx={categoryContainer}>
        <Typography sx={{ marginTop: "10px" }} textAlign="left" variant="h4">
          {defaultObject.title}
        </Typography>
        <Grid sx={categoryGrid} container spacing={2}>
          {responseData.length ? (
            responseData.map((item) => (
              <GridComponent
                defaultObject={defaultObject}
                totalCost={item.totalCost}
                name={item.name}
                key={item.id}
                id={item.id}
              />
            ))
          ) : (
            <Typography sx={{ marginTop: "150px" }} variant="h4">
              List is empty
            </Typography>
          )}
        </Grid>
        {responseData.length > 0 ? (
          <>
            {responseData.length == 5 ? (
             <></>
            ) : (
              <Button
                sx={categoryButton}
                onClick={() => limitBack()}
                variant="contained"
              >
                 Back
              </Button>
            )}{" "}
            <Button
              sx={categoryButton}
              onClick={() => limitAdd()}
              variant="contained"
            >
               More
            </Button>
          </>
        ) : (
          <Button
            sx={categoryButton}
            onClick={() => limitBack()}
            variant="contained"
          >
            Back
          </Button>
        )}
      </Container>
    </Fragment>
  );
}

export default MainGridComponent;
