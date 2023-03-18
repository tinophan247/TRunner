import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import Router from '../src/routes';

const App = (props) => {
  return (
    <BrowserRouter>
      <Router />
    </BrowserRouter>
  )
};

export default App;