import { config } from './config';
import { history } from './helpers/history';
import { Router, Route, Switch } from 'react-router-dom';
import Error404 from './components/Error404'
import MuiThemeProvider from '@material-ui/core/styles/MuiThemeProvider';
import { createMuiTheme } from '@material-ui/core'
import React from 'react';
import Dashboard from './layout/Dashboard'


const theme = createMuiTheme({
  palette: {
    type: "dark",
    //primary: blue,
    //secondary: deepPurple
  }
});

class App extends React.Component {

  render() {
    return (
      <Router history={history}>
        <MuiThemeProvider theme={theme}>
          <Route path={config.homePath + "/"} >
            <Switch>
              <Route path={config.homePath + "/"} exact component={Dashboard} />
              {/*from && <Redirect to={from}/>*/}
              {/* <Route path={config.homePath + "/login"} component={Login} /> */}
              {/* <PrivateRoute path={config.homePath + "/"} component={Main} /> */}
              <Route component={Error404} />
            </Switch>
          </Route>
        </MuiThemeProvider>
      </Router>
    )
  }
}

export default App
