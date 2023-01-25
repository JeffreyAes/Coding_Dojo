import React from 'react';
import CreateAuthor from './views/CreateAuthor';
import Update from './views/AuthorsUpdate';
import { Routes, Route, Navigate } from 'react-router-dom';
import AuthorList from './views/AuthorList';
function App() {
  return (
    <div className="App">
      <h1 className='text-center'>Favorite Authors</h1>

      <Routes>
        <Route element={<Navigate to="/authors" replace />} path="/" />
        <Route element={<AuthorList />} path="/authors" />
        <Route element={<CreateAuthor />} path="/authors/new" />
        <Route element ={<Update />} path="/authors/:id/edit" />

      </Routes>
    </div>
  );
}
export default App;