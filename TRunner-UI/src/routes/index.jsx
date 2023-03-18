import React from 'react';
import { useSelector } from 'react-redux';
import { Routes, Route } from 'react-router-dom';
import AboutPage from '../views/pages/AboutPage';
import LoginPage from '../views/pages/LoginPage';
import PrivateRoute from '../views/components/PrivateRoute';
import HomePage from '../views/pages/HomePage';
import NotFoundPage from '../views/pages/NotFoundPage';
import GroupManagement from '../views/pages/AdminSide/GroupManagement';
import SportManagement from '../views/pages/AdminSide/SportManagement';
import Dashboard from '../views/pages/AdminSide/Dashboard';

const Router = () => {
  const isLoggedIn = useSelector(state => state.auth.isLoggedIn);
  return (
    <Routes>
      <Route exact path='/' element={<PrivateRoute isLoggedIn={isLoggedIn} />} />
      <Route path='/dashboard' element={<Dashboard />} />
      <Route path='/home' element={<HomePage />} />
      <Route path='/login' element={<LoginPage />} />
      <Route path='/about' element={<AboutPage />} />
      <Route path='/not-found-page' element={<NotFoundPage />} />
      <Route path='/group-management' element={<GroupManagement />} />
      <Route path='/sport-management' element={<SportManagement />} />
      <Route path='*' element={<NotFoundPage />} />
    </Routes>
  );
};

export default Router;
