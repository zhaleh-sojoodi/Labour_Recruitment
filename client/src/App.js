import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import Home from './views/Home';
import Dashboard from './views/Dashboard';
import AddJob from './views/client/AddJob';
import ClientProfile from './views/client/ClientProfile';
import PageNotFound from './views/PageNotFound';

import './css/styles.css';
import './css/extras.min.css';
import './css/custom.css';

const App = () => {
    return (
    <>
    <Router>
    <Switch>
        <Route path='/' exact render={props => <Home {...props} />} />
        <Route path='/dashboard' exact render={props => <Dashboard {...props} />} />

        {/* Client Views */}
        <Route path='/addjob' exact render={props => <AddJob {...props} />} />
        <Route path='/profile/client' exact render={props => <ClientProfile {...props} />} />

        <Route component={PageNotFound} />
    </Switch>
    </Router>
    </>
    );
}

export default App;