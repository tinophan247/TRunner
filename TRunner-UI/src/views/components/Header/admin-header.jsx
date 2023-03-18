import React from 'react';
import { Navigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { authActions } from '../../../slices/authSlice';
import TRunnerLogo from '../Icons/TRunner-logo';
import TRunner from '../Icons/TRunner';

const AdminHeader = () => {
  const { name, avatar } = useSelector(state => state.auth.credentials);
  const isLoggedIn = useSelector(state => state.auth.isLoggedIn);
  const dispatch = useDispatch();

  const handleLogOut = () => {
    dispatch(authActions.logout());
  };

  return (
    <div className='flex justify-between items-center w-full h-14 bg-ct4-mossy-green'>
      <div className='flex items-center ml-6'>
        <TRunnerLogo width='64' height='28' />
        <div className='ml-2'>
          <TRunner />
        </div>
      </div>
      <div className='flex items-center mr-6'>
        <img
          className='rounded-full w-9 h-9 mr-3'
          src={avatar ?? 'https://ionicframework.com/docs/img/demos/avatar.svg'}
        />
        <p className='text-white font-barlow text-base font-semibold'>{name ?? 'TRunner User'}</p>
        <div className='h-12 w-1 bg-white mr-3 ml-3' />
        <div
          onClick={() => handleLogOut()}
          className='cursor-pointer text-white text-base font-barlow font-semibold uppercase border-solid'
        >
          Log Out
          {!isLoggedIn && <Navigate to='/login' />}
        </div>
      </div>
    </div>
  );
};

export default AdminHeader;
