import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ProductForm from '../components/ProductForm';
import ProductList from '../components/ProductList';


const Main = (props) => {

    useEffect(() => {
        axios.get('http://localhost:8000/api/products')
            .then(res => {
                props.setProducts(res.data);
                props.setLoaded(true);
            })
            .catch(err => console.error(err));
    }, [props.products]);

    

    return (
        <div>
            <ProductForm />
            <hr />
            {props.loaded && <ProductList products={props.products} setProducts={props.setProducts} loaded={props.loaded} setLoaded={props.setLoaded}/>}
        </div>
    )
}

export default Main;