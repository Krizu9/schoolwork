import React from 'react'
import ReactDOM from 'react-dom/client'
import {
  createBrowserRouter,
  RouterProvider,
  Route
} from 'react-router-dom'
import Root, {
  loader as rootLoader,
  action as rootAction
} from './routes/root'
import ErrorPage from './error-page'
import Contact, {
  loader as contactLoader,
  action as contactAction
} from './routes/contact'
import EditContact, {
  action as editAction
} from './routes/edit'
import { action as destroyAction } from './routes/destroy'
import Index from './routes'
import './index.css'


const router = createBrowserRouter([
  {
    path: '/',
    errorElement: <ErrorPage />,
    element: <Root />,
    loader: rootLoader,
    action: rootAction,
    children: [
      {
        errorElement: <ErrorPage />,
        children: [
          { index: true, element: <Index /> },
          {
            path: 'contacts/:contactId',
            element: <Contact />,
            loader: contactLoader,
            action: contactAction
          },
          {
            path: 'contacts/:contactId/edit',
            element: <EditContact />,
            loader: contactLoader,
            action: editAction
          },
          {
            path: 'contacts/:contactId/destroy',
            errorElement: <div>Oops! There was an error.</div>,
            action: destroyAction,
          }
        ]
      }
    ]
  }
])


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
)
