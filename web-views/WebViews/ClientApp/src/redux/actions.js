import { createAction } from "@reduxjs/toolkit";

const setLoading = createAction("loading/set");

const setApiBaseUrl = createAction("apiBaseUrl/set");

const actions = {
  setLoading,
  setApiBaseUrl,
};

export default actions;
