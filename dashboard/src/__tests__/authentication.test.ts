/**
 * @jest-environment node
 */
import { defaultMaxListeners } from 'node:events';
import {register, login, logout} from '../services/authentication'

define("test", () => {
  it("should register user", async () => {
    const response = await register("testuser1", "password", "Manager");
    // console.log(response);
  });
})

