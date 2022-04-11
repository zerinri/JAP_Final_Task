import React, { Fragment, useState } from "react";
import "./LoginPageStyle.js";
import { Card, TextField, Grid, Typography, Button } from "@mui/material";
import { loginGrid, loginCard, loginButton } from "./LoginPageStyle.js";
import axios from "axios";
import { Navigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { setLoginState,setLoginToken } from "../../redux/login";

function LoginPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState([]);
  const dispatch = useDispatch();
  const loginState = useSelector((state) => state.login.loginState);

  if (loginState) {
    return <Navigate to="/categories" />;
  }

  const onSubmit = (event) => {
    event.preventDefault();
    const user = { username: username, password: password };

    axios
      .post("https://localhost:5001/Auth/Login", user)
      .then(function (response) {
        console.log(response.data.data)
        dispatch(setLoginToken(response.data.data));
        dispatch(setLoginState(response.data.success));
      })
      .catch(function (error) {
        console.log(error);
      });
    setErrorMessage("User not found , or wrong username/password provided");
  };

  return (
    <Fragment>
      <Grid sx={loginGrid} container>
        <Card sx={loginCard}>
          <Typography variant="h2">Login</Typography>{" "}
          <Typography variant="h6">Username</Typography>
          <form onSubmit={onSubmit}>
            <TextField
              required
              label="Required"
              onChange={(e) => setUsername(e.target.value)}
            />
            <br />
            <Typography variant="h6">Password</Typography>
            <TextField
              type="password"
              className="loginTextField"
              required
              label="Required"
              onChange={(e) => setPassword(e.target.value)}
            />
            <br />
            <Typography>{errorMessage}</Typography>
            <Button
              sx={loginButton}
              color="primary"
              variant="contained"
              type="submit"
            >
              Login
            </Button>
          </form>
        </Card>
      </Grid>
    </Fragment>
  );
}

export default LoginPage;
