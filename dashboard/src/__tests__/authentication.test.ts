/**
 * @jest-environment node
 */
import {register, login, logout, clearuser} from '../services/authentication';

class LocalStorageMock {
  store: any;
  constructor() {
    this.store = {};
  }

  clear() {
    this.store = {};
  }

  getItem(key: string) {
    return this.store[key] || null;
  }

  setItem(key: string, value: any) {
    this.store[key] = String(value);
  }

  removeItem(key: string) {
    delete this.store[key];
  }

  length = 0;

  key() {
    return null;
  }
};

global.localStorage = new LocalStorageMock;

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
    expect(response).toEqual(expect.objectContaining({ id: expect.any(Number), username: 'testuser1', role: 'Manager' }));
  });

  it("should clear user", async () => {
    await register("testuser3", "password", "Manager");
    const response = await clearuser("testuser3");
    expect(response).toBe("");
  });

  it("should authenticate user", async () => {
    await register("testuser2", "password", "Manager");
    const response = await login("testuser2", "password");
    expect(response).toEqual(expect.objectContaining({
      id: expect.any(Number), username: 'testuser2', role: 'Manager', token: expect.any(String)
    }));
  });
})

