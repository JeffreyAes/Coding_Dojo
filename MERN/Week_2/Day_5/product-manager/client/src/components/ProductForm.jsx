import React, { useState } from "react";
import axios from 'axios';


export default () => {

    const [title, setTitle] = useState("")
    const [price, setPrice] = useState("")
    const [description, setDescription] = useState("")

    const onSubmitHandler = e => {
        e.preventDefault();
        axios.post('http://localhost:8000/api/products/new', {
            title,
            price,
            description
        })
            .then(res=>console.log(res))
            .catch(err=>console.log(err))
    }
    
    return (
        <div>
            <h1>Create EPIC products</h1>
            <form onSubmit={onSubmitHandler} >
                <div>
                    <label>Product title: </label>
                    <input type="text" onChange={(e)=>setTitle(e.target.value)} />
                </div>
                <div>
                    <label>Product price: </label>
                    <input type="number" onChange={(e)=>setPrice(e.target.value)} />
                </div>
                <div>
                    <label>Product description: </label>
                    <input type="text" onChange={(e)=>setDescription(e.target.value)} />
                </div>
                <input type="submit" value="Create Product" />
            </form>
        </div>
    )
    
}
