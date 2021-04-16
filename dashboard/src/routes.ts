import React from 'react';

const Login = React.lazy(() => import('./views/user/Login'));
const RollingValues = React.lazy(() => import('./views/reports/Dashboard'));
const DailyPnL = React.lazy(() => import('./views/reports/DailyPnL'));


const routes = [
  { path: '/dashboard', exact: true, name: 'Home', component: RollingValues },
  { path: '/dailypnl', exact: true, name: 'Home', component: DailyPnL },
];

export default routes;
