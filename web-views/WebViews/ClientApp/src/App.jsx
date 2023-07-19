import React, { useEffect } from "react";
import { Route, Routes } from "react-router-dom";
import { useDispatch } from "react-redux";
import Home from "./views/Home/Home";
import NotFound from "./views/ErrorPages/NotFound";
import CenteredLayout from "./components/Layouts/CenteredLayout";
import operations from "./redux/operations";
import "./custom.css";

function App() {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(operations.getConfig());
  }, []);

  return (
    <CenteredLayout>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </CenteredLayout>
  );
}

export default App;
