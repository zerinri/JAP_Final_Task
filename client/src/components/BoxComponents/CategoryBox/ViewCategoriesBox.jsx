import React, { Fragment, useState, useEffect } from "react";
import {
  Table,
  TableHead,
  TableRow,
  TableContainer,
  TableCell,
  TableBody,
} from "@mui/material";
import { useDispatch } from "react-redux";
import { setCategory } from "../../../redux/categories";
import axios from "axios";

function ViewCategoriesBox({trigger}) {
  const [responseData, setResponseData] = useState([]);
  const dispatch = useDispatch();
  
  useEffect(() => {
    axios.get(`https://localhost:5001/api/Categories/all`).then((res) => {
      const allCategories = res.data.data
      setResponseData(allCategories);
      dispatch(setCategory(allCategories));
      console.log(allCategories)
    });
  }, [trigger]);
console.log(responseData)
  return (
    <Fragment>
      <TableContainer sx={{ maxHeight: "250px" }}>
        <Table
          stickyHeader
          sx={{ marginTop: 2, marginLeft:"25%", marginRight:"25%", width: "50%" }}
          aria-label="simple table"
        >
          <TableHead>
            <TableRow>
              <TableCell align="left">Id</TableCell>
              <TableCell align="right">Categories</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {responseData.map((item) => (
              <TableRow key={item.name}>
                <TableCell align="left">{item.id}</TableCell>
                <TableCell align="right" component="th" scope="row">
                  {item.name}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Fragment>
  );
}

export default ViewCategoriesBox;
