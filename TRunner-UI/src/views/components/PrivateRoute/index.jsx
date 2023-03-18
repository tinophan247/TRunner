import React from 'react';
import { Navigate } from 'react-router-dom';

const PrivateRoute = ({ isLoggedIn }) => {
    return isLoggedIn ? (<Navigate to='/dashboard' replace />) : (<Navigate to='/login' replace />)
}

export default PrivateRoute;