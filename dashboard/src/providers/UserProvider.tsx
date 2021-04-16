import React, { useMemo, useState } from "react";
import { register as registerService, login as loginService, logout as logoutService, getCurrentUser } from '../services/authentication';

export type UserContextProps = {
  user: User | null;
  register: (username: string, password: string, role: string) => Promise<User>;
  login: (username: string, password: string) => Promise<User>;
  logout: () => void;
}

export type User = {
  id: number;
  username: string;
  token: string;
  role: string;
}

export const UserContext = React.createContext<UserContextProps>({} as UserContextProps);

export const UserProvider: React.FC<{}> = ({children}) => {
  const [user, setUser] = useState<User | null>(null);

  React.useEffect(() => {
    setUser(getCurrentUser());
  }, []);

  const register = async (username: string, password: string, role: string): Promise<User> => {
    let response = await registerService(username, password, role);
    if (response.message) throw new Error('Could not register user');
    return response;
  }

  const login = async (username: string, password: string): Promise<User> => {
    let response = await loginService(username, password);
    console.log(response)
    if (response.message) throw new Error('Could not login');
    setUser(response);
    return response;
  }

  const logout = (): void => {
    logoutService();
    setUser(null);
  }

  const values: UserContextProps = useMemo(
    () => ({
      user,
      register,
      login,
      logout
    }),
    [
      user
    ],
  );

  return <UserContext.Provider value={values}>{children}</UserContext.Provider>;
};

export const useUser = () => {
  const context = React.useContext(UserContext);

  if (context === undefined) {
    throw new Error('`useProfile` hook must be used within a `UserProvider` component');
  }
  return context;
};