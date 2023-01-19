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

function App() {
  const [category, setCategory] = useState()
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Navigate to="/home" replace /> }/>
        <Route path="/home" replace element={<Wrapper/>}/>
        <Route path="/home/:category/:id" element={<Wrapper />} />
        <Route path="*" element={<ErrorCard />} />
      </Routes>
    </div>
    
  );
}

export default App;
