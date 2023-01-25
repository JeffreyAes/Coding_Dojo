import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { useParams, useNavigate, Link } from "react-router-dom";
import NameValidator from '../components/Validator';

const Update = (props) => {
    const navigate = useNavigate();
    const [errors, setErrors] = useState([])
    const { id } = useParams()
    const [name, setName] = useState("")

    useEffect(() => {
        axios.get('http://localhost:8000/api/authors/' + id)
            .then(res => {
                setName(res.data.name)
            })
    }, [id]);

    const updateAuthor = e => {
        e.preventDefault()
        axios.put('http://localhost:8000/api/authors/' + id, {
            name
        })
            .then(res => console.log(res))
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
        <div>
            <h1>Update Author</h1>
            <h6><Link to='/authors'>Home</Link></h6>
            <form onSubmit={updateAuthor}>
                <div>
                    <label >Title: </label>
                    <input type="text"
                        name='name'
                        value={name}
                        onChange={(e) => { setName(e.target.value) }} />
                    {errors.map((err, index) => <p className="text-danger" key={index}>{err}</p>)}
                    <NameValidator name={name} />
                </div>

                <div className='d-flex gap-2'>
                    <Link className='btn btn-danger' to='/authors'>cancel</Link>
                    <input className='btn btn-primary' type="submit" value="Update Author" />
                </div>
            </form>
        </div>
    )
}

export default Update;