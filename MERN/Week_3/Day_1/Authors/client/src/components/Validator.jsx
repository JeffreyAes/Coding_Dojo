const NameValidator = (props) => {
    if (props.name.length !== 0 && props.name.length < 3) {
        return (
            <h5 className="text-danger">
                name must be at least 3 characters long
            </h5>
        )

    }
};

export default NameValidator;