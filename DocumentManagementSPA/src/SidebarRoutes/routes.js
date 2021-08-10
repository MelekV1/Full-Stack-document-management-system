import { GiBookshelf, GiKeyboard } from "react-icons/gi";
import { RiUserSearchFill, RiLogoutBoxFill, RiLoginBoxFill} from "react-icons/ri";
import {FaPenAlt} from "react-icons/fa";
import Logout from "../views/Logout"
import Dashboard from "../views/Dashboard";
import Documents from "../views/Documents";
import Users from "../views/Users";
import Login from "../views/Login";
import Authors from "../views/Authors";

var routes = [
  {
    path: "/dashboard",
    name: "Dashboard",
    icon: <GiKeyboard/>,
    component: Dashboard,
    layout: "/admin",
  },
  {
    path: "/users",
    name: "Users",
    icon: <RiUserSearchFill/>,
    component: Users,
    layout: "/admin",
  },
  {
    path: "/documents",
    name: "Documents",
    icon: <GiBookshelf/>,
    component: Documents,
    layout: "/admin",
  },
  {
    path: "/authors",
    name: "Authors",
    icon: <FaPenAlt/>,
    component: Authors,
    layout: "/admin",
  },
  {
    path: "/login",
    name: "Login",
    icon: <RiLoginBoxFill/>,
    component: Login,
    layout: "/admin",
  },
  {
    path: "/logout",
    name: "Logout",
    icon: <RiLogoutBoxFill/>,
    component: Logout,
    layout: "/admin",
  },
];
export default routes;
