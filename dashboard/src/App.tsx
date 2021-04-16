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
              <Route path="/dashboard" component={TheLayout} />
              <Route exact path="/" component={TheLayout} />
              <Route >
                <Redirect to="/dashboard" />
              </Route> 
              </>
            )}
            {/* <Route exact path="/register" name="Register Page" render={props => <Register {...props}/>} />
            <Route exact path="/404" name="Page 404" render={props => <Page404 {...props}/>} />
            <Route exact path="/500" name="Page 500" render={props => <Page500 {...props}/>} />
            <Route path="/" name="Home" render={props => <TheLayout {...props}/>} /> */}
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
