import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Link, useParams } from 'react-router-dom'

const Games = (props) => {

    const [allPlayers, setAllPlayers] = useState([])
    const [loaded, setLoaded] = useState(false)
    const { id } = useParams()

    useEffect(() => {
        axios.get('http://localhost:8000/api/players')
            .then(res => {
                res.data.sort((a,b) => (a.name.toLowerCase() > b.name.toLowerCase()) ? 1 : -1);
                setAllPlayers(res.data);
                setLoaded(true);
                console.log("meme")
            })
            .catch(err => console.error(err));
    }, [allPlayers]);

    const updatePlayer = (e, player) => {
        let tempArr = player.action
        console.log(tempArr)
        tempArr[id] = parseInt(e.target.value)
        axios.put(`http://localhost:8000/api/players/${player._id}`, {
            action: tempArr
        })
            .then(res => console.log(res))
            .catch(err => console.log(err))
    }


    return (
        <div>
            <div className='d-flex justify-content-center gap-3'>
                <Link to='/status/game/1'>Game 1</Link>
                <Link to='/status/game/2'>Game 2</Link>
                <Link to='/status/game/3'>Game 3</Link>
            </div>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Team Name</th>
                        <th>actions</th>
                    </tr>
                </thead>
                <tbody>
                    {loaded && allPlayers.map((player, i) =>
                        <tr key={i}>
                            <td >{player.name}</td>
                            <td>
                                <button onClick={(e) => updatePlayer(e, player)} style={player.action[id] === 1 ? { backgroundColor: "green" } : {}} value={1}>Playing</button>
                                <button onClick={(e) => updatePlayer(e, player)} style={player.action[id] === -1 ? { backgroundColor: "red" } : {}} value={-1}>Not Playing</button>
                                <button onClick={(e) => updatePlayer(e, player)} style={player.action[id] === 0 ? { backgroundColor: "yellow" } : {}} value={0}>Undecided</button>
                            </td>
                        </tr>
                    )}

                </tbody>
            </table>
        </div>
    )

}
export default Games