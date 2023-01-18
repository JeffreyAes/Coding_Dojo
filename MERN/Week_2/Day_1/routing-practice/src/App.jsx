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

const Thing = (props) => {
  const { thing } = useParams()
  const { color } = useParams()
  const { bgcolor } = useParams()

  if (isNaN(thing) == false ) {
    return (

      <div style={{ textAlign: "center" }}>
        <h1 >The magic number is {thing}</h1>
      </div>
    );
  } else {
    return (
      <div style={{ textAlign: "center" }}>
        <div style={{ backgroundColor: bgcolor }}>
          <h1 style={{ color: color }}> the word is... {thing} </h1>
        </div>
        <div>
          <p>try adding colors to the link. like hello/red/blue</p>
        </div>
      </div>
    )
  }
}

// const Word = (props) => {
//   const { word } = useParams()
//   const { color } = useParams()
//   const { bgcolor } = useParams()
//   return (

//     <div style={{ textAlign: "center" }}>
//       <div style={{ backgroundColor: bgcolor }}>
//         <h1 style={{ color: color }}> the word is... {word} </h1>
//       </div>
//       <div>
//         <p>try adding colors to the link. like hello/red/blue</p>
//       </div>
//     </div>
//   )
// }

function App() {

  return (

    <div>
      <div >
        <nav >
          <ul className="NavThing">
            <li><Link to={"/"}>Home</Link></li>
          </ul>
        </nav>
      </div>
      <Routes>

        <Route path="/:thing/:color/:bgcolor" element={<Thing />} />
        <Route path="/:thing/:color" element={<Thing />} />
        <Route path="/:thing" element={<Thing />} />
        {/* <Route path="/:word" element={<Word />} /> */}
        <Route path="/" element={<Home />} />
      </Routes>
    </div>
  );
}

export default App