import React from 'react'
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom'
import ProductDelete from './ProductDelete';

const ProductList = (props) => {
    const { removeFromDom } = props;

    return (
        <div>
            {props.products.map((product, i) => 
                <div>
                <Link to={`/products/${product._id}`}
                    key={i}>
                    <p>
                        {product.title}
                    </p>
                </Link>
                    
                    <ProductDelete product={product}  setProducts={props.setProducts} loaded={props.loaded} setLoaded={props.setLoaded}/>
                    
                </div>
            )}
        </div>
    )
}

export default ProductList;