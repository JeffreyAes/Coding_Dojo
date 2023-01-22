import React, { useState } from "react";

import axios from "axios";

export default props => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/people', {
            firstName,
            lastName
        })
            .then(res=>console.log("Response: ", res))
            .catch(res=>console.log("Error: ", res))
    }

    return (
        <form onSubmit={onSubmitHandler} >
            <div>
                <label >First Name: </label>
                <input type="text" onChange={e=> setFirstName(e.target.value)} />
            </div>
            <div>
                <label >Last Name: </label>
                <input type="text" onChange={e => setLastName(e.target.value)} />
            </div>
            <input type="submit" value="New Person" />
        </form>
    )
}