import React from 'react'
import axios from 'axios';
import { Link } from 'react-router-dom';

const PlayerList = (props) => {
    return (
        <div>

            <div className="container">
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

                            {props.players.map((player, i) =>
                                <tr key={i}>
                                    <td >{player.name}</td>
                                    <td >{player.position}</td>
                                    <td>Delete</td>
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