import React, { useEffect, useState } from 'react'
import axios from 'axios';
import { useParams, Link } from "react-router-dom";
import PlayerDelete from '../components/PlayerDelete';

const Detail = (props) => {
    const [player, setPlayer] = useState({})
    const { id } = useParams();
    


    useEffect(() => {
        axios.get('http://localhost:8000/api/players/' + id)
            .then(res => setPlayer(res.data))
            .catch(err => console.error(err));
    }, [id]);


    return (
        <div>
            <Link to={"/players/edit/" + player._id}>
                Edit
            </Link>
            <div>


            </div>


            <p>Name: {player.name}</p>
            <p>Position: {player.position}</p>
            <div>
                <Link to={'/players/list'}>Back</Link>
            </div>
            <PlayerDelete playerId={player._id} />
        </div>
    )
}

export default Detail;