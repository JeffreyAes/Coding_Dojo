import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios';
import AuthorDelete from '../components/AuthorDelete';

const AuthorList = (props) => {
    const [authors, setAuthors] = useState([]);
    const [loaded, setLoaded] = useState(false);
    const removeFromDom = authorId => {
        setAuthors(authors.filter(author => author._id !== authorId));
    }

    useEffect(() => {
        axios.get('http://localhost:8000/api/authors')
            .then(res => {
                setAuthors(res.data);
                setLoaded(true);
            })
            .catch(err => console.error(err));
    }, [authors]);

    return (
        <div>
            <Link className='btn btn-primary' to='/authors/new'>Add Authors</Link>

            <div className="container">
                <div className="col-sm-12">


                    <table className='table  table-striped'>
                        <thead>
                            <tr>
                                <th>Authors</th>
                                <th>Actions available</th>
                            </tr>
                        </thead>
                        <tbody>

                            {loaded && authors.map((author, i) =>
                                <tr key={i}>
                                    <td >{author.name}</td>
                                    <td><Link to={`/authors/${author._id}/edit`}>Edit</Link>
                                        <AuthorDelete authorId={author._id} removeFromDom={removeFromDom} />
                                    </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )
}

export default AuthorList;