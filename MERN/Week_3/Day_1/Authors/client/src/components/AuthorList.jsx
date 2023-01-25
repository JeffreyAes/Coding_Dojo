import React from 'react'
import axios from 'axios';
import { Link } from 'react-router-dom';
import AuthorDelete from './AuthorDelete';

const AuthorList = (props) => {
    return (
        <div>

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

                            {props.authors.map((author, i) =>
                                <tr key={i}>
                                    <td >{author.name}</td>
                                    <td><Link to={`/authors/${author._id}/edit`}>Edit</Link> <AuthorDelete authors={props.authors} authorId={author._id} setAuthors={props.setAuthors}  /> </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )
}

export default AuthorList