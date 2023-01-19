
import { useState } from "react"

const DisplayInformation = (props) => {
    
    if (category == "people")
    {
        return (
            <div>
                <h1>{information.name}</h1>
            </div>
        )
    }else{
        return (
            <div>
                <h1>{information.terrain}</h1>
            </div>
        )
    }
}
export default DisplayInformation