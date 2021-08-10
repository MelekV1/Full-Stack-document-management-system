import React from "react";
import { NavLink } from "react-router-dom";
import { Nav } from "reactstrap";
import logo from "../../logo.svg";

function Sidebar(props) {
  //const[routesToDisplay,setRoutesToDisplay]=useState(props.protectedroutes)
/*   useEffect(() => {
    if(localStorage.getItem('AccessToken')==='')
      setRoutesToDisplay(props.routes)
    else
      setRoutesToDisplay(props.protectedroutes);
    //console.log(routesToDisplay);
  },[props.protectedroutes,props.routes,routesToDisplay]); */
  const sidebar = React.useRef();
  // verifies if routeName is the one active (in browser input)
  const activeRoute = (routeName) => {
    return props.location.pathname.indexOf(routeName) > -1 ? "active" : "";
  };
  
  return (
    <div
      className="sidebar"
      data-color={props.bgColor}
      data-active-color={props.activeColor}
    >
      <div className="logo">
        <a
          href="http://localhost:3000/admin/"
          className="simple-text logo-mini"
        >
          <div className="logo-img">
            <img src={logo} alt="react-logo" />
          </div>
        </a>
        <a
          href="http://localhost:3000/admin/"
          className="simple-text logo-normal"
        >
          DokümanYönetimi
        </a>
      </div>
      <div className="sidebar-wrapper" ref={sidebar}>
        <Nav>
          {props.protectedroutes.map((prop, key) => {
            //console.log(prop.path)
            return (
              <li
                className={
                  activeRoute(prop.path) + 
                  (prop.pro ? " active-pro" : "")
                }
                key={key}
              >
                <NavLink
                  to={prop.layout + prop.path}
                  className="nav-link"
                  activeClassName="active"
                >  
                  <p>{prop.icon} - {prop.name}</p>
                </NavLink>
              </li>
            );
          })}
        </Nav>
      </div>
    </div>
  );
}

export default Sidebar;
