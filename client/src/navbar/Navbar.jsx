import React, { useEffect, useState } from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  Container,
  Menu,
  MenuItem,
  Box,
  Tooltip,
  Typography,
} from "@mui/material";
import { containerStyle } from "./NavbarStyle";
import { Link, useNavigate } from "react-router-dom";
import { useSelector,useDispatch } from "react-redux";
import LoginIcon from '@mui/icons-material/Login';
import MenuIcon from "@mui/icons-material/Menu";
import { setLoginState,setLoginToken } from "../redux/login";

export default function Navbar() {
  const loginState = useSelector((state) => state.login.loginState);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const settings = [
    "Add Recipe",
    "Modify Ingredient",
    "Modify Category",
    "Filter Ingredients",
    "Logout",
  ];
  const [open, setOpen] = useState(null);
  const [settingsValue, setSettingsValue] = useState("");

  useEffect(() => {
    if (settingsValue == "Add Recipe") {
      navigate(`/addRecipe`);
    } else if (settingsValue == "Logout") {
      dispatch(setLoginToken(""));
      dispatch(setLoginState(false));
      navigate(`/`);
    }else if (settingsValue == "Modify Ingredient") {
      navigate(`/modifyIngredient`);
    }else if (settingsValue == "Modify Category") {
      navigate(`/modifyCategory`);
    }
  }, [settingsValue]);
 
  const handleOpenNavMenu = (event) => {
    setOpen(event.currentTarget);
  };
  const handleCloseNavMenu = () => {
    setOpen(null);
  };
  return (
    <AppBar position="static">
      <Toolbar>
        <Link to="/categories">
          <IconButton edge="start">Yup-Task</IconButton>
        </Link>
        <Container sx={containerStyle}>
          {loginState ? (
            <Box sx={{ flexGrow: 0 }}>
              <Tooltip title="Open settings">
                <IconButton
                  size="large"
                  aria-label="account of current user"
                  aria-controls="menu-appbar"
                  aria-haspopup="true"
                  onClick={handleOpenNavMenu}
                  color="inherit"
                >
                  <MenuIcon />
                </IconButton>
              </Tooltip>
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={open}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(open)}
                onClose={handleCloseNavMenu}
              >
                {settings.map((setting) => (
                  <MenuItem
                    key={setting}
                    onClickCapture={() => setSettingsValue(setting)}
                    onClick={handleCloseNavMenu}
                  >
                    <Typography textAlign="center">{setting}</Typography>
                  </MenuItem>
                ))}
              </Menu>
            </Box>
          ) : (
            <Link to="/login">
            <IconButton edge="end">Login<LoginIcon/></IconButton>
          </Link>
          )}
        </Container>
      </Toolbar>
    </AppBar>
  );
}
