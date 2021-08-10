import React from "react";

const RegisterSection = ()=>{
    return (
        <form method="post" className="p-1">
        <div className="text-danger"></div>
        <div className="row">
            <div className="col-md-6">
                <div className="form-group">
                    <label >FirstName</label>
                    <input  className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
            <div className="col-md-6">
                <div className="form-group">
                    <label >lastName</label>
                    <input className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
        </div>
        <div className="form-group">
            <label >Email</label>
            <input className="form-control" />
            <span className="text-danger"></span>
        </div>
        <div className="row">
            <div className="col-md-6">
                <div className="form-group">
                    <label >Password</label>
                    <input className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
            <div className="col-md-6">
                <div className="form-group">
                    <label >Password confirmation</label>
                    <input className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
        </div>
        <button type="submit" className="btn btn-primary">Register</button>
    </form>
    );
}

export default RegisterSection;