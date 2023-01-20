import { useState } from "react";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import ErrorCard from "./ErrorCard";
import PersonCard from "./PersonCard";
import PlanetCard from "./PlanetCard";

const Wrapper = (props) => {
    const navigate = useNavigate()
    const [category, setCategory] = useState("people");
    const [id, setId] = useState(null);
    const [information, setInformation] = useState({})

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("test")
        axios.get(`https://swapi.dev/api/${category}/${id}`).then(response => {
            console.log(response.data)
            setInformation(response.data)

        }).catch(error => {
            console.log(error.response.status)
            if (error.response.status === 404) {
                navigate("/error")
            }

        })

    }

    return (
        <div>
            <div>
                <form onSubmit={(e) => handleSubmit(e)}>
                    <select onChange={(e) => setCategory(e.target.value)} name="category">
                        <option value="people">People</option>
                        <option value="planets">Planets</option>
                    </select>
                    <input onChange={(e) => setId(e.target.value)} type="number" name="id" />
                    <input type="submit" value="Search" />
                </form>
            </div>
            {
                category == "people"?
                <div>
                    {<PersonCard information={information}></PersonCard>}
                </div>:
                <div>
                    {<PlanetCard information = {information}/>}
                </div>
            }
        </div>
    )
}


export default Wrapper;