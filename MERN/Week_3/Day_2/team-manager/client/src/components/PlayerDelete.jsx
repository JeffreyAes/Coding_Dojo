import React from 'react'
import axios from 'axios';

const PlayerDelete = (props) => {

    const deletePlayer = (playerId) => {
        
        axios.delete('http://localhost:8000/api/delete/' + playerId)
            .then(res => {
                props.removeFromDom(playerId)
    
            })
            .catch(err => console.log(err));
    }

    return (
        <div>
            <button className='btn btn-danger' onClick={(e) => deletePlayer(props.playerId)}>Delete</button>
        </div>
    )
}

export default PlayerDelete