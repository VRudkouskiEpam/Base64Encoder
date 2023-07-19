import actions from "./actions";

export const getConfig = () => async (dispatch) => {
  dispatch(actions.setLoading(true));
  const response = await fetch("configuration");
  const data = await response.json();
  dispatch(actions.setLoading(false));

  dispatch(actions.setApiBaseUrl(data.apiBaseUrl));
};

const operations = {
  getConfig,
};

export default operations;
