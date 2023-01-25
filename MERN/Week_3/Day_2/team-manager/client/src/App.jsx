import logo from './logo.svg';
import './App.css';
import Main from './views/Main';
import {Routes, Route, Navigate } from 'react-router-dom'
import PlayerCreate from './views/PlayerCreate';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route element={<Navigate to='/players/list' replace />} path='/'></Route>
        <Route element={<Main />} path="/players/list" ></Route>
        <Route element={<PlayerCreate />} path="/players/new" ></Route>
        {/* <Route element={<Games />} path="/games/:id" ></Route> */}
      </Routes>
    </div>
  );
}

export default App;
