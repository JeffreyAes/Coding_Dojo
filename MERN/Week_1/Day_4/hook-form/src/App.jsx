import React from 'react';
import logo from './logo.svg';
import './App.css';
import { useState } from 'react';

const App = () => {
    const [FirstName, setFirstName] = useState("");
    const [LastName, setLastName] = useState("");
    const [Email, setEmail] = useState("");
    const [Password, setPassword] = useState("");
    const [ConfirmPassword, setConfirmPassword] = useState("");


    const handleNewUser = (e) => {
      e.preventDefault();
      const newUser = { FirstName, LastName, Email, Password, ConfirmPassword };
      setFirstName(newUser.FirstName)
      setLastName(newUser.LastName)
      setEmail(newUser.Email)
      setPassword(newUser.Password)
      setConfirmPassword(newUser.ConfirmPassword)
    };
  
  return (
    <div className="App">
      <form onSubmit={(e) => {handleNewUser(e)}}>
        <div className='marginForm'>
          <label>First Name: </label>
          <input type="text" onChange={(e) => {setFirstName(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Last Name: </label>
          <input type="text" onChange={(e) => {setLastName(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Email: </label>
          <input type="text" onChange={(e) => {setEmail(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Password: </label>
          <input type="text" onChange={(e) => {setPassword(e.target.value)}}/>
        </div>
        <div className='marginForm'>
          <label>Confirm Password: </label>
          <input type="text" onChange={(e) => {setConfirmPassword(e.target.value)}}/>
        </div>
        <input type="submit" value="Add User" />
      </form>

      <table>
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
            </table>
    </div>
  );
};

export default App;
