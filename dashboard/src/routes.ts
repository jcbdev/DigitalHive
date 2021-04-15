import React from 'react';

const Login = React.lazy(() => import('./views/user/Login'));


const routes = [
  { path: '/', exact: true, name: 'Home', component: Login },
];

export default routes;
