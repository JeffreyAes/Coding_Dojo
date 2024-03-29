import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import PlayerDelete from '../components/PlayerDelete';

const PlayerList = (props) => {
    const [players, setPlayers] = useState([]);
    const [loaded, setLoaded] = useState(false);
    const removeFromDom = playerId => {
        setPlayers(players.filter(player => player._id !== playerId))
        
    }

    useEffect(() => {
        axios.get('http://localhost:8000/api/players')
            .then(res => {
                res.data.sort((a,b) => (a.name.toLowerCase() > b.name.toLowerCase()) ? 1 : -1);
                setPlayers(res.data);
                setLoaded(true);
            })
            .catch(err => console.error(err));
    }, []);
    return (
        <div>

            <div className="container mt-3">
                <div className='d-flex gap-3'>
                    <Link className='btn btn-primary' to="/players/list">List</Link>
                    <Link className='btn btn-info' to="/players/new">Add a Player</Link>
                </div>
                <div className="col-sm-12">


                    <table className='table  table-striped'>
                        <thead>
                            <tr>
                                <th>Team Name</th>
                                <th>Prefered Position</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>

                            {loaded && players.map((player, i)  =>
                                
                                <tr key={i}>
                                    <td > <Link to={`/players/${player._id}`}>{player.name}</Link> </td>
                                    <td >{player.position}</td>
                                    <td> <Link className='btn btn-info' to={`/players/edit/${player._id}`} >Edit</Link> <PlayerDelete playerId={player._id} removeFromDom={removeFromDom} /> </td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    )
}

export default PlayerList