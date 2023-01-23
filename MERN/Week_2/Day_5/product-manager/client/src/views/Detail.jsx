import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { useParams, Link, useNavigate } from "react-router-dom";
import ProductDelete from '../components/ProductDelete';


const Detail = (props) => {
    const [product, setProduct] = useState({})
    const { id } = useParams();
    const navigate = useNavigate()

    useEffect(() => {
        axios.get('http://localhost:8000/api/products/' + id)
            .then(res => setProduct(res.data))
            .catch(err => console.error(err));
    }, []);


    return (
        <div>
            <Link to={"/products/" + product._id + "/edit"}>
                Edit
            </Link>
            <div>

            
            </div>


            <p>Title: {product.title}</p>
            <p>Price: {product.price}</p>
            <p>Description: {product.description}</p>
            <div>
                <Link to={'/products'}>Back</Link>
            </div>
            <ProductDelete product={product} products={props.products} setProducts={props.setProducts} loaded={props.loaded} setLoaded={props.setLoaded} />
        </div>
    )
}

export default Detail;