import React from 'react';
import { HashRouter, Redirect, Route, Switch } from 'react-router-dom';
import { TheLayout } from './containers';
import { UserProvider, useUser } from './providers/UserProvider';
import './scss/style.scss';
import Register from './views/user/Register';

const loading = (
  <div className="pt-3 text-center">
    <div className="sk-spinner sk-spinner-pulse"></div>
  </div>
)

const Login = React.lazy(() => import('./views/user/Login'));

const AvailableRoutes = () => {
  const { user } = useUser();
  return (
    <HashRouter>
        <React.Suspense fallback={loading}>
          <Switch>
            {!user && (<> 
              <Route exact path="/" component={Login} />
              <Route exact path="/register" component={Register} />
              <Route >
                <Redirect to="/" />
              </Route> 
              </>
            )}
            {user && (<> 
              <Route component={TheLayout} />
              {/* <Route exact path="/" component={TheLayout} /> */}
              {/* <Route >
                <Redirect to="/dashboard" />
              </Route>  */}
              </>
            )}
          </Switch>
        </React.Suspense>
    </HashRouter>
  )
}

function App() {
  return (
    <UserProvider>
      <AvailableRoutes />
    </UserProvider>
  );
}

export default App;
