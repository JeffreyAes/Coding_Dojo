import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { useParams, useNavigate, Link } from "react-router-dom";

const Update = (props) => {
    const navigate = useNavigate();
    const { id } = useParams();
    const [name, setName] = useState("");
    const [position, setPosition] = useState("");

    useEffect(() => {
        axios.get('http://localhost:8000/api/players/' + id)
            .then(res => {
                console.log(res.data)
                setName(res.data.name)
                setPosition(res.data.position)
            .catch(err => console.log(err.response.data.errors))
            })
    }, [id]);

    const updatePlayer = e => {
        axios.put('http://localhost:8000/api/players' + id, {
            name,
            position
        })
            .then(res => {
                console.log(res)
                navigate('/players/list')
            })
            .catch(err => console.log(err))
    }

    return (
        <div>
            <h1>Update Player</h1>
            <h6><Link to='/players/list'>Home</Link></h6>
            <form onSubmit={updatePlayer}>
                <div>
                    <label >Name: </label>
                    <input type="text"
                        name='name'
                        value={name}
                        onChange={(e) => { setName(e.target.value) }} />
                </div>
                <div>
                    <label >Position: </label>
                    <input type="text"
                        position='position'
                        value={position}
                        onChange={(e) => { setPosition(e.target.value) }} />
                </div>
                <div className='d-flex gap-2'>
                    <Link className='btn btn-danger' to='/players/list'>cancel</Link>
                    <input className='btn btn-primary' type="submit" value="Update Player" />
                </div>
            </form>
        </div>
    )
}

export default Update;
