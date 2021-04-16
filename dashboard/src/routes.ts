import React from 'react';

const Login = React.lazy(() => import('./views/user/Login'));
const RollingValues = React.lazy(() => import('./views/reports/Charts'));


const routes = [
  { path: '/dashboard', exact: true, name: 'Home', component: RollingValues },
];

export default routes;
