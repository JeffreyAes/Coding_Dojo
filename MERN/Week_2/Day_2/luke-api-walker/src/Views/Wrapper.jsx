import { useState } from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import  axios  from "axios";
import ErrorCard from "./ErrorCard";

const Wrapper = (props) => {
    const navigate = useNavigate()
    const [category, setCategory] = useState("people");
    const [id, setId] = useState(null);
    const [information, setInformation] = useState({})

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("test")
        axios.get(`https://swapi.dev/api/${category}/${id}`).then(response=>{
            console.log(response.data)
            setInformation(response.data)
                
        }).catch(error=>{console.log(error.response.status)
        if(error.response.status === 404) {
            navigate("/error")
            }
    })
    }
    const displayInformation = (props) => {
        if (category == "people")
        {
            return (
                <div>
                    <h1>{information.name}</h1>
                    <p>Height: {information.height} cm</p>
                    <p>Mass: {information.mass} kg</p>
                    <p>Hair Color: {information.hair_color}</p>
                    <p>Skin Color: {information.skin_color}</p>
                </div>
            )
        }else{
            return (
                <div>
                    <h1>{information.name}</h1>
                    <p>Climate: {information.climate}</p>
                    <p>Surface Water: {information.surface_water}</p>
                    <p>Population: {information.population}</p>
                </div>
            )
        }
    }

    return (
        <div>
            <div>
            <form onSubmit={(e) => handleSubmit(e)}>
                <select onChange={(e) => setCategory(e.target.value)} name="category">
                    <option value="people">People</option>
                    <option value="planets">Planets</option>
                </select>
                <input onChange={(e) => setId(e.target.value)} type="number" name="id"/>
                <input type="submit" value="Search" />
            </form>
            </div>
            <div>
                {displayInformation()}
            </div>
        </div>
    )
}


export default Wrapper;