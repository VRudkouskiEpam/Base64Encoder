import { combineReducers } from "redux";
import { createReducer } from "@reduxjs/toolkit";
import actions from "./actions";

const loading = createReducer(true, {
  [actions.setLoading]: (_, { payload }) => payload,
});

const apiBaseUrl = createReducer(null, {
  [actions.setApiBaseUrl]: (_, { payload }) => payload,
});

export default combineReducers({
  loading,
  apiBaseUrl,
});
