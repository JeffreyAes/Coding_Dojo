import React, { useState } from 'react';
import './App.css';
import Todo from './Components/todo';

function App() {
  const [newTodo, setNewTodo] = useState("");
  const [todos, setTodos] = useState([])

  const handleNewTodoSubmit = (e) => {
    e.preventDefault();
    if (newTodo.length === 0) {
      return;
    }

    const todoItem = {
      text: newTodo,
      complete: false
    }

    setTodos([...todos, todoItem])
    setNewTodo("")


  }
  const handleTodoDelete = (delIndx) => {
    // use map when you want to grab the entirety of an array/object
    // use filter when you want selections from it
    const filteredTodos = todos.filter((todo, i) => {
      return i !== delIndx
    })
    setTodos(filteredTodos)
  }
  const handleToggleComplete = (idx) => {
    const updatedTodos = todos.map((todo, i) => {
      if (idx === i) {
        // 
        // (simpler but it mutates the set directly)
        todo.complete = !todo.complete;
        // const updatedTodos = {...todo, complete: !todo.complete}
      }
        return todo;
    })
    setTodos(updatedTodos);
  }

  return (
    <div style={{ textAlign: "center" }}>
      <header>
        <form onSubmit={(e) => {
          handleNewTodoSubmit(e)
        }}>

          <input onChange={(e) => {
            setNewTodo(e.target.value)
          }} type="text"
            value={newTodo} />
          <div>
            <button >Add</button>
          </div>
        </form>

      </header>
      {
        todos.map((todo, i) => {
          
          return (
            <Todo key={i} todo={todo} handleToggleComplete={handleToggleComplete} i={i}
            handleTodoDelete={handleTodoDelete}/>
          )
        })}
    </div> 
  );
}

export default App;
