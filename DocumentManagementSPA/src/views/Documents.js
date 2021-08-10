import React, {useState} from 'react';
import axios from "axios";
import { Button, ButtonGroup, FormGroup,  Label, Input, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

const ModalExample = (props) => {
  const {
    buttonLabel="Add new document",
    className
  } = props;

  const [modal, setModal] = useState(false);
  const [rSelected, setRSelected] = useState(null);
  const [documentData, setDocumentData] = useState(
    {title:"",authorId:"",categoryId:"",publishedDate:""});
  const handleInputChange = (e) => {
    setDocumentData((prevState) => {
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
                    <label >Title</label>
                    <input name="title" onChange={(e)=>handleInputChange(e)} className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
        </div>
        <div className="row">
            <div className="col-md-6">
                <div className="form-group">
                    <label >AuthorId</label>
                    <input name="authorId" onChange={(e)=>handleInputChange(e)} className="form-control" />
                    <span className="text-danger"></span>
                </div>
            </div>
        </div>
        <div className="row">
          <div className="col-md-6">
            <div className="form-group">
              <ButtonGroup>
                <Button color="primary" name ="categoryId" value="11" onClick={(e) => {setRSelected(11); handleInputChange(e)}} active={rSelected === 11}>Computer science</Button>
                <Button color="primary" name ="categoryId" value="12" onClick={(e) => {setRSelected(12); handleInputChange(e)}} active={rSelected === 12}>Novels and stories</Button>
                <Button color="primary" name ="categoryId" value="13" onClick={(e) => {setRSelected(13); handleInputChange(e)}} active={rSelected === 13}>Business and Management</Button>
              </ButtonGroup>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-md-6">
            <FormGroup>
              <Label for="exampleDate">Pubslihed date</Label>
              <Input
                type="date"
                name="publishedDate"
                id="exampleDate"
                placeholder="date placeholder"
                onChange={(e)=>handleInputChange(e)}
              />
            </FormGroup>
          </div>
        </div>
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={()=>{toggle(); props.Save(documentData)}}>Save</Button>{' '}
          <Button color="secondary" onClick={toggle}>Cancel</Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}


function Documents(props) {
    const[documents, setDocuments] = useState([])

    const BASE_URL = 'https://localhost:44380'
    const axiosInstance = 
      axios.create({ baseURL: BASE_URL })

    var token =localStorage.getItem('AccessToken')

    const fetchAPI = () =>{
      const api ="api/document/getalldocuments"
      axiosInstance.get(api, { headers: 
        {"Authorization" : `Bearer ${token}`} 
      })
      .then(res => {
          setDocuments(res.data);
          console.log(res.data);
      })
    }

    const Save =(documentData)=>{
      const api ="api/document/";

      axiosInstance.post(api, documentData, { headers: 
        {"Authorization" : `Bearer ${token}`} 
      })
      .then(res => {
          console.log(documentData);
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
                  <th >DocId</th>
                  <th >Title</th>
                  <th >TypeId</th>
                  <th >AuthorId</th>
                  <th >PublishedDate</th>
                </tr>
              </thead>
              <tbody>
                {documents.map((el,i)=>
                  <tr key={i}>
                    <th>{el.docId}</th>
                    <th>{el.title}</th>
                    <th>{el.categoryId}</th>
                    <th>{el.authorId}</th>
                    <th>{el.publishedDate}</th>
                  </tr>
                )}
              </tbody>
            </table>
            <ModalExample Save={Save}/>
        </div>
    );
}

export default Documents;