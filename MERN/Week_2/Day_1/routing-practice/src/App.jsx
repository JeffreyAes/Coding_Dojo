import React from "react";
import './App.css';
import { useState } from "react";
import { useParams } from "react-router-dom";
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
      <div>

      </div>
    </div>
  );
}

const Four = (props) => {
  return (
    <div style={{ textAlign: "center" }}>
      <h1 >The magic number is 4</h1>
      <div>

      </div>
      <div>

      </div>
    </div>
  );
}

const Hello = (props) => {
  
  const { color } = useParams()
  const { bgcolor } = useParams()
  return (
    <div style={{ textAlign: "center" }}>
      <div style={{backgroundColor: bgcolor}}>
      <h1 style={{color: color}}> the word is... hello </h1>
      </div>
      <div>
        <p>try adding colors to the link. like hello/red/blue</p>

      </div>
      <div>

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
          <li><Link to={"/4"}>The Number Is</Link></li>
          <li><Link to={"/hello"}>Hello</Link></li>
        </ul>
      </nav>
      </div>
      <Routes>

        <Route path="/hello/:color/:bgcolor" element={<Hello />} />
        <Route path="/hello/:color" element={<Hello />} />
        <Route path="/hello/" element={<Hello />} />
        <Route path="/4" element={<Four />} />
        <Route path="/" element={<Home />} />
      </Routes>
    </div>
  );
}

export default App