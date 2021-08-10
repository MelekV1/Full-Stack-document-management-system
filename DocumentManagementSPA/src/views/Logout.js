import React ,{useState} from 'react';

function Logout(props) {
    const[display,setDesplay]= useState()
    const handleLogout=()=>{
        localStorage.setItem("AccessToken","");
        setDesplay("Logged out !")
        window.location.href = "http://localhost:3000/admin/login";

    }
    return (
        <div className="content">
            <button onClick={(e)=>handleLogout()}>Are you sure you want to logout?</button>
            <p>{display}</p>
        </div>
    );
}

export default Logout;