import React from 'react'
import axios from 'axios';
import {useNavigate} from 'react-router-dom'

const PlayerDelete = (props) => {

    const navigate = useNavigate()
    const deletePlayer = (playerId) => {
        
        axios.delete('http://localhost:8000/api/delete/' + playerId)
            .then(res => {
                if(props.removeFromDom){
                    props.removeFromDom(playerId)
                }
                else{
                    navigate('/players/list')
                }
    
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