import React, {useState} from "react";
import axios from 'axios';

function LoginSection(){

    const [userData,setUserData]=useState({username:"",password:""});
    const [userConnected,setUserConntected] = useState(false);
    const BASE_URL = 'https://localhost:44380'
    const axiosInstance = 
      axios.create({ baseURL: BASE_URL })
    const api ="api/user/login"
    const loggingDisplay =() =>{
                    
        if (userConnected === true)
            return (                    
            <div className="alert alert-success" role="alert">
                Successfuly logged in!
            </div>)
        else
            return (
            <div className="alert alert-danger" role="alert">
                Not logged in
            </div>)
    } 
    const loginRequest = () =>{
        axiosInstance.post(api, userData)
        .then(res => {
            //console.log(res.data.accessToken);
            setUserConntected(true);
            localStorage.setItem('AccessToken', res.data.accessToken);
            window.location.href = "http://localhost:3000/admin/dashboard";
        }).catch(er =>{
            console.log(er);
            setUserConntected(false);
        })
      }
    const handleInputChange = (e) => {
        
          setUserData((prevState) => {
            return {
              ...prevState,
              [e.target.name]: e.target.value,
            };
          });
        };

    return (
        <div className="col-md-10 offset-1">
        {/*test{Malek@isteknoloji , root} */}

        <div className="login-form-icon text-center">
            <i className="fas fa-user-circle fa-9x text-secondary"></i>
        </div>
        
        {/*<form   className="p-1">*/}
            <div className="form-group">
                <div className="input-group">
                    <div className="input-group-prepend">
                        <div className="input-group-text">
                            <i className="fas fa-envelope"></i>
                        </div>
                    </div>
                    <input className="form-control" placeholder="Email Address" name="username" onChange={(e)=>handleInputChange(e)} />
                </div>
                <span className="text-danger"></span>
            </div>
            <div className="form-group">
                <div className="input-group">
                    <div className="input-group-prepend">
                        <div className="input-group-text">
                            <i className="fas fa-lock"></i>
                        </div>
                    </div>
                    <input className="form-control" type="password" placeholder="Password" name="password" onChange={(e)=>handleInputChange(e)} />
                </div>
                <span className="text-danger"></span>
            </div>

            <div className="form-group">
                <button className="btn btn-primary btn-block" onClick={(e)=>loginRequest()}>Log in</button>
            </div>
            {loggingDisplay()}
            

{/*</form>*/}    
</div>
    );
}

export default LoginSection;