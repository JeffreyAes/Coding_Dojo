import React, { useEffect, useState } from 'react'
import {Link} from 'react-router-dom'
import AuthorList from '../components/AuthorList';
import axios from 'axios';

const Main = (props) => {
    const [authors, setAuthors] = useState([]);
    const [loaded, setLoaded] = useState(false);

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
            <Link to ="/authors/new">Add an Author</Link>
            {/* <PersonForm /> */}
            {/* <hr /> */}
            {loaded && <AuthorList authors={authors} setAuthors={setAuthors} />}
        </div>
    )
}

export default Main;