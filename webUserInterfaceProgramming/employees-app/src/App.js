import './App.css';
import React, { useEffect, useState } from 'react';
import axios from 'axios';

function Employee(props) {
  return (
    <div class="card">
      <img class="image" src={props.employee.image} alt="image" />
      <h1>{props.employee.lastName} {props.employee.firstName} </h1>
      <p class="information">
        {props.employee.title} @ {props.employee.department}
      </p>
      <p class="information"> {props.employee.phone} {props.employee.email}
      </p>
    </div>
  )
}
function App() {
  const [employees, setEmployees] = useState([]);
  useEffect(() => {
    axios
      .get('http://localhost:3001/employees') //in my .json file, some of the pictures did not work for somereason
      .then(response => {
        setEmployees(response.data)
      })
  }, [])

  const employeeItems = employees.map((employee, index) =>
    <Employee key={index} employee={employee} />
  );
  return (
    <ul class="card-container">
      {employeeItems}
    </ul>
  );
}

export default App;
