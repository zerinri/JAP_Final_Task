import React, { Fragment, useState, useEffect } from "react";
import {Table,TableHead,TableRow,TableContainer,TableCell,TableBody} from '@mui/material';
import axios from "axios";
import { useDispatch } from "react-redux";
import { setIngredients } from "../../../redux/ingredients";

function ViewIngredientBox({trigger}) {
  const [responseData, setResponseData] = useState([]);
  const dispatch = useDispatch();

  useEffect(() => {
    axios.get(`https://localhost:5001/api/Ingredients`).then((res) => {
      setResponseData(res.data.data);
      dispatch(setIngredients(res.data.data));
    });
  }, [trigger,dispatch]);

  return (
    <Fragment>
      <TableContainer sx={{ maxHeight: "250px",marginBottom: "30px"}}>
        <Table stickyHeader sx={{ marginTop:2,marginLeft:5,marginRight:5,width:"90%" }} aria-label="simple table">
          <TableHead>
            <TableRow>
            <TableCell align="left">Id</TableCell>
              <TableCell>Ingredients</TableCell>
              <TableCell align="right">Price</TableCell>
              <TableCell align="right">Quantity</TableCell>
              <TableCell align="right">UnitMeasure</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {responseData.map((item) => (
              <TableRow
                key={item.name}
              >
                <TableCell align="left">{item.id}</TableCell>
                <TableCell component="th" scope="row">
                  {item.name}
                </TableCell>
                <TableCell align="right">{item.purchasePrice}KM</TableCell>
                <TableCell align="right">{item.purchaseQuantity}</TableCell>
                <TableCell align="right">{item.purchaseUnitMeasure}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Fragment>
  );
}

export default ViewIngredientBox;
