import React from "react";
import './App.css';
import { Navigate } from "react-router-dom";
import {
  Routes,
  Route,
} from "react-router-dom";
import Wrapper from "./Views/Wrapper";
import ErrorCard from "./Views/ErrorCard";

function App() {
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
