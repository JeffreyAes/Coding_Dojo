import './App.css';
import { Routes, Route, Navigate, Link } from 'react-router-dom'
import PlayerCreate from './views/PlayerCreate';
import PlayerList from './views/Main';
import Games from './views/Games';

function App() {
  return (
    <div className="">
      <div className='d-flex gap-3 justify-content-center mt-2'>
        <Link className='btn btn-outline-secondary' to='/players/list'>Manage Players</Link>
        <Link className='btn btn-outline-secondary' to='status/game/1'>Mange Player Status</Link>
      </div>
      <Routes>
        <Route element={<Navigate to='/players/list' replace />} path='/'></Route>
        <Route element={<PlayerList />} path="/players/list" ></Route>
        <Route element={<PlayerCreate />} path="/players/new" ></Route>
        <Route element={<Games />} path="/status/game/:id" ></Route>
      </Routes>
    </div>
  );
}

export default App;
