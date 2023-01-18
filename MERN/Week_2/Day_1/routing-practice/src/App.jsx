import React from "react";
import './App.css';
import { useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import {
  Routes,
  Route,
  Link
} from "react-router-dom";


const Home = (props) => {
  return (
    <div style={{ textAlign: "center" }} >
      <h1>Welcome.</h1>
      <div>
      </div>
    </div>
  );
}

const Four = (props) => {
  const { num } = useParams()
  // const navigate = useNavigate()
  // if (isNaN(num))
  // {
  //   navigate(Hello(num))
  // }
  return (
    <div style={{ textAlign: "center" }}>
      <h1 >The magic number is {num}</h1>
    </div>
  );
}

const Hello = (props) => {
  const { word } = useParams()
  const { color } = useParams()
  const { bgcolor } = useParams()
  return (
    
    <div style={{ textAlign: "center" }}>
      <div style={{backgroundColor: bgcolor}}>
      <h1 style={{color: color}}> the word is... {word} </h1>
      </div>
      <div>
        <p>try adding colors to the link. like hello/red/blue</p>
      </div>
    </div>
  )
}

function App() {
  
  return (
    
    <div>
      <div >
      <nav >
        <ul className="NavThing">
          <li><Link to={"/"}>Home</Link></li>
          {/* <li><Link to={"/4"}>The Number Is</Link></li> */}
          {/* <li><Link to={"/hello"}>Hello</Link></li> */}
        </ul>
      </nav>
      </div>
      <Routes>

        <Route path="/:word/:color/:bgcolor" element={<Hello />} />
        <Route path= "/:word/:color" element={<Hello />} />
        <Route path="/:num" element={<Four />} />
        <Route path= "/:word" element={<Hello />} />
        <Route path="/" element={<Home />} />
      </Routes>
    </div>
  );
}

export default App