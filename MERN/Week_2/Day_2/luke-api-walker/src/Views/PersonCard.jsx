import { useState } from "react";
const PersonCard = (props) => {
    const { handleSubmit } = props;
    const { information } = props;
    const { name, height, mass, hair_color, skin_color } = information
    return (
        <div>
            <h1>{name}</h1>
            <p>Height: {height} cm</p>
            <p>Mass: {mass} kg</p>
            <p>Hair Color: {hair_color}</p>
            <p>Skin Color: {skin_color}</p>
        </div>
    )
}
export default PersonCard

