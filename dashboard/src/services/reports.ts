import { getCurrentUser } from './authentication';
import axios from "axios";
import https from 'https';

const API_URL = "https://localhost:5001/Data/";

const instance = axios.create({
  httpsAgent: new https.Agent({  
      rejectUnauthorized: false
  })
});

export const getTimeSeries = async () => {
  const user = getCurrentUser();
  //TODO: Add user.token to Auth bearer header for JWT Auth
  return instance.get(API_URL + "timeseries", {}).then((response) => {
    return response.data;
  });
};

export const getCommodityModels = async (model: string | null = null, commodity: string | null = null) => {
  const user = getCurrentUser();
  //TODO: Add user.token to Auth bearer header for JWT Auth
  return instance.get(API_URL + "models", {
    params: {
      model, commodity
    }
  }).then((response) => {
    return response.data;
  });
};