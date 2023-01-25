import React from 'react'
import axios from 'axios';
import { useNavigate } from 'react-router-dom'

const AuthorDelete = (props) => {
    const navigate = useNavigate()

    const deleteAuthor = (authorId) => {
        
        axios.delete('http://localhost:8000/api/delete/' + authorId)
            .then(res => {
                removeFromDom(authorId)
    
            })
            .catch(err => console.log(err));
    }
    const removeFromDom = authorId => {
        props.setAuthors(props.authors.filter(author => author._id !== authorId));
    }

    return (
        <div>
            <button onClick={(e) => deleteAuthor(props.authorId)}>Delete</button>
        </div>
    )
}

export default AuthorDelete