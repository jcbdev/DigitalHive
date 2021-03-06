import axios from "axios";
import https from 'https';

const API_URL = "https://localhost:5001/Users/";

const instance = axios.create({
  httpsAgent: new https.Agent({  
      rejectUnauthorized: false
  })
});

export const register = async (username: string, password: string, role:string) => {
  return instance.post(API_URL + "register", {
    username,
    password,
    role
  }).then((response) => {
    return response.data;
  });
};

export const clearuser = async (username: string) => {
  return instance.post(API_URL + "clear", {
    username,
  }).then((response) => {
    return response.data;
  });
};

export const login = async (username: string, password: string): Promise<any> => {
  return instance
    .post(API_URL + "authenticate", {
      username,
      password,
    })
    .then((response) => {
      console.log(response)
      if (response.data.token) {
        console.log('setting token')
        localStorage.setItem("user", JSON.stringify(response.data));
      }

      return response.data;
    });
};

export const logout = () => {
  localStorage.removeItem("user");
};

export const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem("user") ?? "null");
};
