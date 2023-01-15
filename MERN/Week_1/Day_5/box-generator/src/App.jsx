import './App.css';
import { useState } from 'react';
import ColorPicker from './Components/ColorPicker';
import Box from './Components/Box';

function App() {
  const [boxes, setBoxes] = useState([]);
  const handleSubmit = (e, newBox) => {
    e.preventDefault();
    setBoxes([...boxes, newBox])
  }


  return (
    <div>
      <ColorPicker handleSubmit={handleSubmit} />
      <div style={{
        display: "flex"
      }}>

        {
          boxes.map((box, i) => {
            return <Box Key={i} box={box} />
          })
        }
      </div>
    </div>
  );
}

export default App;
