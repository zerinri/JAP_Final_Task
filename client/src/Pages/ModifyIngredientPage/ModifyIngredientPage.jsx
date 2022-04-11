import React, { Fragment, useState } from "react";
import Navbar from "../../navbar/Navbar";
import Divider from "@mui/material/Divider";
import AddIngredientBox from "../../components/BoxComponents/IngredientsBox/AddIngredientBox";
import UpdateIngredientBox from "../../components/BoxComponents/IngredientsBox/UpdateIngredientBox";
import DeleteIngredientBox from "../../components/BoxComponents/IngredientsBox/DeleteIngredientBox";
import ViewIngredientBox from "../../components/BoxComponents/IngredientsBox/ViewIngredientBox";

function ModifyIngredientPage() {
  const [trigger, setTrigger] = useState(0);

  return (
    <Fragment>
      <Navbar />
      <br />
      <AddIngredientBox setTrigger={setTrigger} trigger={trigger} />
      <Divider />
      <UpdateIngredientBox setTrigger={setTrigger} trigger={trigger} />
      <Divider />
      <DeleteIngredientBox setTrigger={setTrigger} trigger={trigger}/>
      <Divider />
      <ViewIngredientBox trigger={trigger} />
    </Fragment>
  );
}

export default ModifyIngredientPage;
