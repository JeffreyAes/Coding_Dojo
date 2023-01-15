import { useState } from "react";

const ColorPicker = (props) => {
    const { handleSubmit } = props;
    //          <<<combining state by creating an object>>>
    const [newBox, setNewBox] = useState({
        color: "",
        width: "",
        height: ""
    })
    //          <<<old code before combining state>>>
    // const [color, setColor] = useState("")
    // const [width, setWidth] = useState("")
    // const [height, setHeight] = useState("")

    // function for handling the object setBoxes
    const handleOnChange = (e) => {
        setNewBox({
            ...newBox,
            [e.target.name]: e.target.value
        })
    }

    const { color, width, height } = newBox

    return (
        <form onSubmit={(e) => handleSubmit(e, newBox)}>
            <input
                type="text"
                placeholder="Pick a color"
                name="color"
                onChange={handleOnChange}
                value={color}
            />
            <input
                type="text"
                placeholder="Pick a width"
                name="width"
                onChange={handleOnChange}
                value={width}
            />
            <input
                type="text"
                placeholder="Pick a height"
                name="height"
                onChange={handleOnChange}
                value={height}
            />

            <input
                type="submit"
                value="Add Box"
            />
        </form>
    )
}

export default ColorPicker;