const Box = (props) => {
    // we have to use "props.box" for deconstructing an object.
    const {color, width, height} = props.box;
    // we can also say const {box} = props.box, but we would say box.width in the 
    // form
    return (
        <div
            style={{
                width: width+"px",
                height: height+"px",
                backgroundColor: color,
                margin: "10px"
            }}
        ></div>
    )
}

export default Box;