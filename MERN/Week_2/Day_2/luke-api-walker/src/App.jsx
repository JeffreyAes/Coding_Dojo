import React from "react";
import './App.css';
import { useState } from "react";
import { useParams } from "react-router-dom";
import { Navigate } from "react-router-dom";
import {
  Routes,
  Route,
  Link
} from "react-router-dom";
import Wrapper from "./Views/Wrapper";
import ErrorCard from "./Views/ErrorCard";
import PersonCard from "./Views/PersonCard";
import PlanetCard from "./Views/PlanetCard";

function App() {
  const [information, setInformation] = useState()
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Navigate to="/home" replace /> }/>
        <Route path="/home" replace element={<Wrapper/>}/>
        <Route path="*" element={<ErrorCard />} />
      </Routes>
    </div>
    
  );
}

export default App;
