import React, { Fragment, useState } from "react";
import Navbar from "../../navbar/Navbar";
import { Divider } from "@mui/material";
import AddCategoryBox from "../../components/BoxComponents/CategoryBox/AddCategoryBox";
import UpdateCategoryBox from "../../components/BoxComponents/CategoryBox/UpdateCategoryBox";
import DeleteCategoryBox from "../../components/BoxComponents/CategoryBox/DeleteCategoryBox";
import ViewCategoriesBox from "../../components/BoxComponents/CategoryBox/ViewCategoriesBox";

function ModifyCategoriesPage() {
  const [trigger, setTrigger] = useState(0);
  return (
    <Fragment>
      <Navbar />
      <br />
      <AddCategoryBox setTrigger={setTrigger} trigger={trigger} />
      <Divider />
      <br />
      <UpdateCategoryBox setTrigger={setTrigger} trigger={trigger} />
      <Divider />
      <DeleteCategoryBox setTrigger={setTrigger} trigger={trigger} />
      <Divider />
      <ViewCategoriesBox trigger={trigger} />
      <Divider />
    </Fragment>
  );
}

export default ModifyCategoriesPage;
