import React from "react";
import { Route, Switch } from "react-router-dom";
import DemoNavbar from "../components/Navbars/DemoNavbar"
import Sidebar from "../components/Sidebar/Sidebar.js";
import routes from "../SidebarRoutes/routes";
import loggingRoutes from "../SidebarRoutes/loggingRoutes";

function Dashboard(props) {
  const mainPanel = React.useRef();
  
  return (
    <div className="wrapper">
      <Sidebar
        {...props}
        protectedroutes={routes}
        routes={loggingRoutes}
        bgColor={"black"}
        activeColor={"info"}
      />
      <div className="main-panel" ref={mainPanel}>
        <DemoNavbar {...props} />
        <Switch>
          {routes.map((prop, key) => {
            return (
              <Route
                path={prop.layout + prop.path}
                component={prop.component}
                key={key}
              />
            );
          })}
        </Switch>
      </div>
    </div>
  );
}

export default Dashboard;
