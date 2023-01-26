const NameValidator = (props) => {
    if (props.name.length !== 0 && props.name.length < 2) {
        return (
            <h5 className="text-danger">
                name must be at least 2 characters long
            </h5>
        )

    }
};

export default NameValidator;