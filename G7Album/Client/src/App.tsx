import React, { useEffect, useState } from 'react';
import './App.css';

function App() {

  const probandoConexion = async () => {

    const res = await fetch("https://localhost:7040/Api/Album/GetAll")

    const data = await res.json();
    console.log("🚀 ~ file: App.tsx ~ line 16 ~ probandoConexion ~ data", data)
  }

  useEffect(()=>{
    probandoConexion()
  }, [])

  
  return (
    <div className="App">
      <header className="App-header">
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
