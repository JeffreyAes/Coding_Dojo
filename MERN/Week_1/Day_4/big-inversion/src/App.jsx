import React from 'react';
import logo from './logo.svg';
import './App.css';
import PersonCardComponent from './components/PersonCard';
// make an array of dictionaries to store information
const peopleArr = [
  { "firstName": "Jane", "lastName": "Doe", "age": 45, "hairColor": "Black" },
  { "firstName": "John", "lastName": "Smith", "age": 88, "hairColor": "Brown" },
  { "firstName": "Millard", "lastName": "Fillmore", "age": 50, "hairColor": "Brown" },
  { "firstName": "Maria", "lastName": "Smith", "age": 62, "hairColor": "Brown" }
]

function App() {
  return (
    <div className="App">
      {/* mapping from the array defined above, to pull values with "person.[blank]" */}
      {peopleArr.map(person => {
        // attatches the values to a key, filling the Component Dictionary to be used later

        return <PersonCardComponent firstName={person.firstName} lastName={person.lastName} age={person.age} hairColor={person.hairColor} />
      })

      }

    </div>
  );
}

export default App;
