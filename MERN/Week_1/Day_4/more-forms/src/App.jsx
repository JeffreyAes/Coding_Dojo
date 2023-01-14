import React from 'react';
import logo from './logo.svg';
import './App.css';
import { useState } from 'react';
import Table from 'react-bootstrap/Table';
import Form from 'react-bootstrap/Form'
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
    const [FirstName, setFirstName] = useState("");
    const [LastName, setLastName] = useState("");
    const [Email, setEmail] = useState("");
    const [Password, setPassword] = useState("");
    const [ConfirmPassword, setConfirmPassword] = useState("");
    // instead we can make an object with key value pairs so theres only one variable 
    // example user = {[firstName:"", lastName:"", ect]}

// old code for trying to lift state without knowing how to.
    // const handleNewUser = (e) => {
    //   e.preventDefault();
    //   const newUser = { FirstName, LastName, Email, Password, ConfirmPassword };
    //   setFirstName(newUser.FirstName)
    //   setLastName(newUser.LastName)
    //   setEmail(newUser.Email)
    //   setPassword(newUser.Password)
    //   setConfirmPassword(newUser.ConfirmPassword)
    // };

    const formMessageFirst = () => {
      if( FirstName.length != 0 && FirstName.length < 2 ) {
    return "name must be at least 2 characters long";
    
} 
  };

  const formMessageSecond = () => {
    if( LastName.length != 0 && LastName.length < 2 ) {
  return "name must be at least 2 characters long";
    }
  };

  const formMessageEmail = () => {
    if( Email.length != 0 && Email.length < 5 ) {
  return "email must be at least 5 characters long";
    }
  };

  const formMessagePassword = () => {
    if( Password.length != 0 && Password.length < 8 ) {
  return "password must be at least 8 characters long";
    }
  };

  const formMessageConfirmPassword = () => {
    if( Password.localeCompare(ConfirmPassword) && ConfirmPassword.length > 0) {
  return "must be the same";
    }
  };

  
  
  return (
    <div className="App">
      <form className='form-control'>
        <div className='marginForm'>
          <label>First Name: </label>
          <input className='form-control' type="text" onChange={(e) => {setFirstName(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Last Name: </label>
          <input className='form-control' type="text" onChange={(e) => {setLastName(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Email: </label>
          <input className='form-control' type="text" onChange={(e) => {setEmail(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Password: </label>
          <input className='form-control' type="text" onChange={(e) => {setPassword(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Confirm Password: </label>
          <input className='form-control' type="text" onChange={(e) => {setConfirmPassword(e.target.value)}}/>
        </div>
        <input type="submit" value="Add User" />
      </form>

      <table className='table table-striped'>
                <thead>
                    <tr>
                      
                        <th className='padding'>Your First Name:</th>
                        <th className='padding'>Your Last Name:</th>
                        <th className='padding'>Your Email:</th>
                        <th className='padding'>Your Password (this is normal i swear): </th>
                        <th className='padding'>Your Confirm Password (incase you didn't get it the first time):</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{FirstName}</td>
                        <td>{LastName}</td>
                        <td>{Email}</td>
                        <td>{Password}</td>
                        <td>{ConfirmPassword}</td>
                    </tr>
                </tbody>
                <tfoot>
                  <tr>
                    <td className='redText'>{formMessageFirst()}</td>
                    <td className='redText'>{formMessageSecond()}</td>
                    <td className='redText'>{formMessageEmail()}</td>
                    <td className='redText'>{formMessagePassword()}</td>
                    <td className='redText'>{formMessageConfirmPassword()}</td>
                  </tr>
                </tfoot>
            </table>
    </div>
  );
};

export default App;
