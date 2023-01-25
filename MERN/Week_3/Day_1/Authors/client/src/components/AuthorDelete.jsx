import React from 'react'
import axios from 'axios';
import { useNavigate } from 'react-router-dom'

const AuthorDelete = (props) => {
    const navigate = useNavigate()

    const deleteAuthor = (authorId) => {
        
        axios.delete('http://localhost:8000/api/delete/' + authorId)
            .then(res => {
                props.removeFromDom(authorId)
    
            })
            .catch(err => console.log(err));
    }

    return (
        <div>
            <button onClick={(e) => deleteAuthor(props.authorId)}>Delete</button>
        </div>
    )
}

export default AuthorDelete