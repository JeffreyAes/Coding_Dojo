import { useState } from "react"
const PlanetCard = (props) => {
    const { information } = props;
    const { name, climate, surface_water, population } = information
    return (
        <div>
            <h1>{name}</h1>
            <p>Climate: {climate}</p>
            <p>Surface Water: {surface_water}</p>
            <p>Population: {population}</p>
        </div>
    )
}
export default PlanetCard