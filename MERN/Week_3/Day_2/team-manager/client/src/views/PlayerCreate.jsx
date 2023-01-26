import React, { useState } from 'react'
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom';
import NameValidator from '../components/nameValidator';
    const PlayerCreate = (props) => {
    const navigate = useNavigate()
    const [name, setName] = useState("");
    const [position, setPosition] = useState("");
    const [errors, setErrors] = useState([])


    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/players', {
            name,
            position
        })
        .then(res => {
            navigate('/players/list')
            console.log(res)
        })
        // If successful, do something with the response. 
        .catch(err => {
            const errorResponse = err.response.data.errors;
            // Get the errors from err.response.data
            const errorArr = [];
            // Define a temp error array to push the messages in
            for (const key of Object.keys(errorResponse)) {
                // Loop through all errors and get the messages
                errorArr.push(errorResponse[key].message)
            }
            // Set Errors
            setErrors(errorArr);
        })
    }

    return (
        <div className='container mt-3'>
            <div className='d-flex gap-3'>

            <Link className='btn btn-primary' to="/players/list">List</Link>
            <Link className='btn btn-info' to="/players/new">Add a Player</Link>
            </div>
            <div className="text-center">

            <form onSubmit={onSubmitHandler}>
            {errors.map((err, index) => <p className="text-danger" key={index}>{err}</p>)}
                    <label>Player Name: </label><br />
                    <input type="text" onChange={(e) => setName(e.target.value)} value={name} />
                    <NameValidator name={name} />
                <p>
                    <label>Player Position: </label><br />
                    <input type="text" onChange={(e) => setPosition(e.target.value)} value={position} />
                </p>
                <input className='btn btn-success' type="submit" />
            </form>
            </div>
        </div>
    )
}

export default PlayerCreate