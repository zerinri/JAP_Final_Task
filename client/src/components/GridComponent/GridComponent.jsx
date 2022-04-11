import {
  Grid,
  Card,
  CardActionArea,
  CardContent,
  Typography,
} from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";

function GridComponent({ name, id, defaultObject, totalCost }) {
  const viewCost = [];
  if (totalCost == null) {
    viewCost.push(<div key={id}></div>);
  } else {
    viewCost.push(<Typography key={id}>TotalCost: {totalCost}KM</Typography>);
  }
  return (
    <Grid item md={4} xs={6}>
      <Card>
        <Link to={`${defaultObject.hrefLocation}${id}`}>
          <CardActionArea>
            <CardContent>
              <Typography>{name}</Typography>
              {viewCost}
            </CardContent>
          </CardActionArea>
        </Link>
      </Card>
    </Grid>
  );
}

export default GridComponent;
