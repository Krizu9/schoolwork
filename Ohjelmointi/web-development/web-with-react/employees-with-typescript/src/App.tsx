import './App.css';
import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface EmployeeProps {
  employee: {
    image: string;
    lastName: string;
    firstName: string;
    title: string;
    department: string;
    phone: string;
    email: string;
  };
}

function Employee(props: EmployeeProps) {
  return (
    <div className="card">
      <img className="image" src={props.employee.image} alt="image" />
      <h1>
        {props.employee.lastName} {props.employee.firstName}
      </h1>
      <p className="information">
        {props.employee.title} @ {props.employee.department}
      </p>
      <p className="information">
        {props.employee.phone} {props.employee.email}
      </p>
    </div>
  );
}

function App() {
  const [employees, setEmployees] = useState<any[]>([]);

  useEffect(() => {
    axios
      .get('http://localhost:5001/employees')
      .then((response) => {
        setEmployees(response.data);
      });
  }, []);

  const employeeItems = employees.map((employee, index) => (
    <Employee key={index} employee={employee} />
  ));

  return <ul className="card-container">{employeeItems}</ul>;
}

export default App;
