import React, {useState} from 'react';
import { Routes, Route } from 'react-router-dom';
import Main from './views/Main';
import Detail from './views/Detail';
import Update from './views/Update';
import axios from 'axios';

function App() {
  const [products, setProducts] = useState([]);
  const [loaded, setLoaded] = useState(false);
  return (
    <div className="App">
      <Routes>
        <Route element={<Main products={products} setProducts={setProducts} loaded={loaded} setLoaded={setLoaded} />} path="/products/" />
        <Route element={<Detail products={products} setProducts={setProducts} loaded={loaded} setLoaded={setLoaded}/>} path="/products/:id" />
        <Route element={<Update/>} path="/products/:id/edit"/>
      </Routes>
    </div>
  );
}

export default App;
