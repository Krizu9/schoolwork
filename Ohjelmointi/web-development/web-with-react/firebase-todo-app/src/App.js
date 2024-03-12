import './App.css';
import LoginPage from './components/login.jsx';
import ToDo from './components/todo.jsx';
import { Outlet } from "react-router-dom";
import React, { useState } from "react";
import {
  createBrowserRouter,
  RouterProvider
} from "react-router-dom"

const router = createBrowserRouter([
  {
    path: "/",
    element: <LoginPage />,
  },
  {
    path: "/todo",
    element: <ToDo />,
  },
]);

function App() {
  return (
    <div>
      <React.StrictMode>
        <RouterProvider router={router}>
          <Outlet />
        </RouterProvider>
      </React.StrictMode>
    </div>
  );
}

export default App;