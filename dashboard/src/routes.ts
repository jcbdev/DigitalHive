import React from 'react';

const Login = React.lazy(() => import('./views/user/Login'));
const RollingValues = React.lazy(() => import('./views/reports/Dashboard'));
const DailyPnL = React.lazy(() => import('./views/reports/DailyPnL'));
const PnlYtd = React.lazy(() => import('./views/reports/PnlYtd'));
const PnlLtd = React.lazy(() => import('./views/reports/PnlLtd'));
const Drawdown = React.lazy(() => import('./views/reports/Drawdown'));
const Position = React.lazy(() => import('./views/reports/Position'));
const Price = React.lazy(() => import('./views/reports/Price'));


const routes = [
  { path: '/dashboard', exact: true, name: 'Home', component: RollingValues },
  { path: '/dailypnl', exact: true, name: 'Home', component: DailyPnL },
  { path: '/pnlytd', exact: true, name: 'Home', component: PnlYtd },
  { path: '/pnlltd', exact: true, name: 'Home', component: PnlLtd },
  { path: '/drawdown', exact: true, name: 'Home', component: Drawdown },
  { path: '/position', exact: true, name: 'Home', component: Position },
  { path: '/price', exact: true, name: 'Home', component: Price },
];

export default routes;
