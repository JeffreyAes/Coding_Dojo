import React, {useState} from 'react'
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom'

const ProductDelete = (props) => {
    const navigate = useNavigate()

    const deleteProduct = (productId) => {
        axios.delete('http://localhost:8000/api/delete/' + productId)
            .then(res => {
                removeFromDom(productId)
                navigate('/products')
    
            })
            .catch(err => console.log(err));
    }
    const removeFromDom = productId => {
        props.setProducts(props.products.filter(product => product._id !== productId));
    }

    return (
        <div>
            <button onClick={(e) => deleteProduct(props.product._id)}>Delete</button>
        </div>
    )
}

export default ProductDelete