import React ,{useState} from 'react';
import Register from '../layouts/AuthLayout/RegisterSection';
import LoginSection from '../layouts/AuthLayout/LoginSection';

function Login(props) {
    const [componentToRender,setComponentToRender]=useState('x');
    return (
        <div className="content">
        <div className="row">
            <div className="col-md-6 offset-md-3">
                <div className="card login-logout-tab">
                    <div className="card-header m-3">
                        <ul className="nav nav-tabs card-header-tabs d-flex justify-content-center">
                            <li className="nav-item">
                                <button className="nav-link m-3" onClick={(e)=>{setComponentToRender('x')}}>Sign In</button>
                            </li>
                            <li className="nav-item">
                                <button className="nav-link m-3" onClick={(e)=>{setComponentToRender('o')}}>Sign Up</button>
                            </li>
                        </ul>
                    </div>
                    <div className="card-content">
                        <div className="col-md-12">
                            {componentToRender === 'o' ?  <Register/> :<LoginSection/>}
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    );
}

export default Login;