const Todo = (props) => {
    const todoClass = ["bold"]
    if (props.todo.complete) {
        todoClass.push("strike");
    }
    return (
        <div>
            <input onChange={(e) => {
                props.handleToggleComplete(props.i);
            }} checked={props.todo.complete} type="checkbox" />
            <span className={todoClass.join(" ")}>{props.todo.text}</span>
            <button style={{ margin: "10px" }} onClick={(e) => {
                props.handleTodoDelete(props.i);
            }}>Delete</button>
        </div>
    )
}
export default Todo