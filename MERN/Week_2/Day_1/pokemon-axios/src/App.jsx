import React, { useState } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [pokemon, setPokemon] = useState([])
  const fetchPokemon = (e) => {
    e.preventDefault();
    axios.get("https://pokeapi.co/api/v2/pokemon?limit=807&offset=0")
    .then(response => {
      setPokemon(response.data.results)

      // we now run another promise to parse the HTTP response into usable JSON

      console.log(response);
    }).catch(err => {
      console.log(err);
    });
  }
  return (
    <div className="App">
      <header className="App-header">
        <div>
          {/* using callback to invoke a function, for passing multiple arguments */}
            <button onClick={(e) => fetchPokemon(e)}>Fetch Pokemon</button>
            <div>
              {
                pokemon.map((poke, i) => {
                  return (
                    <h1 key={i}>
                      {i +1 + ".) "}
                      {poke.name}
                    </h1>
                    )
                })
              }
            </div>
        </div>
      </header>
    </div>
  );
}

export default App;
