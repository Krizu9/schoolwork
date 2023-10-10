
import './App.css';
import React from 'react';
import * as ReactDOM from 'react-dom';
import { useState } from "react";
import Person from './Person.js';

const persons = [
  {
    name: "Kirsi Kernel",
    image: "https://randomuser.me/api/portraits/women/31.jpg"
  },
  {
    name: "Matti Mainio",
    image: "https://randomuser.me/api/portraits/men/1.jpg"
  },
  {
    name: "Matti Merkusson",
    image: "https://randomuser.me/api/portraits/men/2.jpg"
  }
];

function App() {

  return (
    <div className="App">
      <h1>Persons</h1>
      <div>
        {persons.map((person, index) => (
          <Person key={index} person={person} />
        ))}
      </div>
    </div>
  );
}

export default App;
