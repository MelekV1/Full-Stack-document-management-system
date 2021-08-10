import React from 'react';
import { Route, Switch, Redirect } from "react-router-dom";

import AdminLayout from "./layouts/Admin";

function App(props) {

    return (
        <div>
        <Switch>
            <Route path="/admin" render={(props) => 
                <AdminLayout {...props} />} />
            <Redirect to="/admin/dashboard" />
        </Switch>
        </div>
    );
}

export default App;