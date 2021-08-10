import React, {useState} from 'react'
import axios from 'axios'

export default function Users() {
    const[users, setUsers] = useState([])
    const BASE_URL = 'https://localhost:44346'
    const axiosInstance = 
      axios.create({ baseURL: BASE_URL })

    var token =localStorage.getItem('AccessToken');
    const api ="api/user/getusers"

    const fetchAPI = () =>{
      axiosInstance.get(api, { headers: 
        {"Authorization" : `Bearer ${token}`} 
      })
      .then(res => {
          setUsers(res.data);
          console.log(res.data);
      })
    }
    return (
        <div className="content">
            <button onClick={fetchAPI}>Fetch users </button>
            <table className="table table-dark">
              <thead>
                <tr>
                  <th >UserId</th>
                  <th >Email Address</th>
                  <th >HashedPassword</th>
                  <th >FullName</th>
                  <th >Source</th>
                  <th >HireDate</th>

                </tr>
              </thead>
              <tbody>
                {users.map((el,i)=>
                  <tr key={i}>
                    <th>{el.userId}</th>
                    <th>{el.emailAddress}</th>
                    <th>{el.password}</th>
                    <th>{el.firstName} {el.lastName}</th>
                    <th>{el.source}</th>
                    <th>{el.hireDate}</th>
                  </tr>
                )}
              </tbody>
            </table>
        </div>
    );
}
