import React, { useEffect, useState } from 'react';
import PlayerList from '../components/PlayerList';
import PlayerCreate from './PlayerCreate';

    const Main = (props) => {
        const [players, setPlayers] = useState([]);
        const [loaded, setLoaded] = useState(false);

        useEffect(() => {
            axios.get('http://localhost:8000/api/players')
                .then(res => {
                    setPlayers(res.data);
                    setLoaded(true);
                })
                .catch(err => console.error(err));
        }, [authors]);
        return (
            <div>
                <Link to ="/players/new">Add player</Link>
                {loaded && <PlayerList players={players} setPlayers={setPlayers} />}
            </div>
        )
    }