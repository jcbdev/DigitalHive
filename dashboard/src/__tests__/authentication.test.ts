/**
 * @jest-environment node
 */
import {register, login, logout, clearuser} from '../services/authentication';

describe("test", () => {
  beforeAll(async () => {
    await clearuser("testuser1");
    await clearuser("testuser2");
    await clearuser("testuser3");
  })

  afterAll(async () => {
    await clearuser("testuser3");
    await clearuser("testuser1");
    await clearuser("testuser2");
  })

  it("should register user", async () => {
    const response = await register("testuser1", "password", "Manager");
    expect(response.status).toBe(200);
    expect(response.data).toEqual(expect.objectContaining({ id: expect.any(Number), username: 'testuser1', role: 'Manager' }));
  });

  it("should clear user", async () => {
    await register("testuser3", "password", "Manager");
    const response = await clearuser("testuser3");
    expect(response.status).toBe(200);
  });

  it("should authenticate user", async () => {
    await register("testuser2", "password", "Manager");
    const response = await login("testuser2", "password");
    expect(response).toEqual(expect.objectContaining({
      id: expect.any(Number), username: 'testuser2', role: 'Manager', token: expect.any(String)
    }));
  });
})

