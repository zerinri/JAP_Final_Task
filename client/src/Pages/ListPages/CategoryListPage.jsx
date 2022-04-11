import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import Navbar from "../../navbar/Navbar";
import MainGridComponent from "../../components/MainGrid/MainGridComponent";

function CategoryListPage() {
  const categoryObject = {
    title: "Categories:",
    hrefLocation: "/categories/",
    viewTotalCost: false,
  };

  const [responseData, setResponseData] = useState([]);
  const [limit,setLimit] = useState(0);

  useEffect(() => {
    axios
      .get(`https://localhost:5001/api/Categories?limit=${limit}`)
      .then((res) => {
        const allCategories = res.data.data;
        setResponseData(allCategories);
      });
  }, [limit]);

  return (
    <Fragment>
      <Navbar />
      <br />
      <MainGridComponent
        limit={limit}
        setLimit={setLimit}
        defaultObject={categoryObject}
        responseData={responseData}
      />
    </Fragment>
  );
}

export default CategoryListPage;
