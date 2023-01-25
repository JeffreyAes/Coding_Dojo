import React, { useState } from "react"
import axios from "axios"
import { Link, useNavigate } from "react-router-dom"
import NameValidator from "../components/Validator"

const CreateAuthor = () => {
    const navigate = useNavigate()
    const [name, setName] = useState("")
    const [errors, setErrors] = useState([])

    

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/authors', {
            name
        })
            .then(res => {
                
                if (errors.length === 0){
                    navigate('/authors')
                }   
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
        <div >
            <div><Link to="/authors">Home</Link></div>
            <h1>Add a Favorite Author</h1>
            <form onSubmit={onSubmitHandler}>
                {errors.map((err, index) => <p className="text-danger" key={index}>{err}</p>)}
                <div className="mb-2">
                    <label>Authors Name:</label>
                    <input type="text" onChange={(e) => setName(e.target.value)} />
                    <NameValidator name={name} />
                </div>
                <div className="d-flex gap-2">
                    <Link className="btn btn-danger" to="/authors">Cancel</Link>
                    <input className="btn btn-success" type="submit" value="Add Author" />
                </div>
            </form>
        </div>
    )
}

export default CreateAuthor