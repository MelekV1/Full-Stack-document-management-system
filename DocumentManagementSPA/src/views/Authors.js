import React, {useState} from 'react';
import axios from "axios";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

const ModalExample = (props) => {
  const {
    buttonLabel="Add new Author",
    className
  } = props;

  const [modal, setModal] = useState(false);
  const [authorData, setAuthorData] = useState({});
  const handleInputChange = (e) => {
    setAuthorData((prevState) => {
      return {
        ...prevState,
        [e.target.name]: e.target.value,
      };
    });
  };
  const toggle = () => setModal(!modal);

  return (
    <div>
      <Button color="danger" onClick={toggle}>{buttonLabel}</Button>
      <Modal isOpen={modal} toggle={toggle} className={className}>
        <ModalHeader toggle={toggle}>New document</ModalHeader>
        <ModalBody>
        <div className="row">
            <div className="col-md-6">
                <div className="form-group">
                    <label >Name</label>
                    <input name="fullName" onChange={(e)=>handleInputChange(e)} className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
        </div>
        <div className="row">
            <div className="col-md-6">
                <div className="form-group">
                    <label >Address</label>
                    <input name="Address" onChange={(e)=>handleInputChange(e)} className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
        </div>
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={()=>{toggle(); props.Save(authorData)}}>Save</Button>{' '}
          <Button color="secondary" onClick={toggle}>Cancel</Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}


function Authors(props) {
    const[authors, setAuthors] = useState([])

    const BASE_URL = 'https://localhost:44380'
    const axiosInstance = 
      axios.create({ baseURL: BASE_URL })

    var token =localStorage.getItem('AccessToken')

    const fetchAPI = () =>{
      const api ="api/author/getauthors"
      axiosInstance.get(api, { headers: 
        {"Authorization" : `Bearer ${token}`} 
      })
      .then(res => {
          setAuthors(res.data);
          console.log(res.data);
      })
    }

    const Save =(authorData)=>{
      const api ="api/author/";

      axiosInstance.post(api, authorData, { headers: 
        {"Authorization" : `Bearer ${token}`} 
      })
      .then(res => {
          console.log(authorData);
      })
    }
    return (
        <div className="content">
            <div>
              <Button onClick={fetchAPI} color="primary">fetchData</Button>{' '}
            </div>
            <table className="table table-dark">
              <thead>
                <tr>
                  <th >Author Id</th>
                  <th >Author Name</th>
                  <th >Origin country</th>
                </tr>
              </thead>
              <tbody>
                {authors.map((el,i)=>
                  <tr key={i}>
                    <th>{el.authorId}</th>
                    <th>{el.fullName}</th>
                    <th>{el.address}</th>
                  </tr>
                )}
              </tbody>
            </table>
            <ModalExample Save={Save}/>
        </div>
    );
}

export default Authors;