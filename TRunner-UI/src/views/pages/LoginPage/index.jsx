import React, { useState, useEffect } from 'react';
import { Navigate } from 'react-router-dom';
import FormInput from '../../components/FormInput';
import { useSelector, useDispatch } from 'react-redux';
import {  login } from '../../../slices/authSlice';
import TrunnerLogo from '../../components/Icons/t-runner-logo';
import Footer from '../../components/Footer/index';
import TextFields from '../../components/TextField';
import ActionAlerts from '../../components/Alert';
import Loader from '../../components/Loader';

const LoginPage = () => {
  const isLoggedIn = useSelector(state => state.auth.isLoggedIn);
  const { error, errorMessage, isLoading } = useSelector(state => state.auth);

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isHide, setIsHide] = useState(false);

  //events
  const onChangeEmail = event => {
    setEmail(event.target.value);
  };

  const onChangePassword = event => {
    setPassword(event.target.value);
  };

  const dispatch = useDispatch();

  const handleSubmit = async e => {
    e.preventDefault();
    const data = { isRunner: false, email, password };
    dispatch(login(data));
  };

  return (
    <div className='flex w-full h-full fixed'>
      {isLoading && <Loader show={isLoading} />}
      <div className='grid h-full text-center w-0.45 grid-rows-[20%_60%_20%]'>
        <div className='m-auto pt-28'>
          <div className='h-11'>
            <TrunnerLogo />
          </div>
          <label className='font-barlow font-semibold text-2xl text-ct4-dark-grey inline-block pt-2'>T-Runner</label>
        </div>
        <div className='w-500 grid m-auto'>
          <label className='font-barlow text-ct4-dark text-28 font-bold tracking-0.01 uppercase leading-0.16 text-left pb-5'>
            Sign up
          </label>
          <form onSubmit={handleSubmit} className='grid h-300 grid-rows-[30%_30%_40%]'>
            {/* <FormInput
              email={email}
              password={password}
              changeEmail={onChangeEmail}
              changePassword={onChangePassword}
              error={isError}
              isHide={isHide}
              onClick={handleClickShowPassword}
              isRegister={false}
            /> */}
            <TextFields
              type={'Email'}
              name='Email'
              placeholder={'Email'}
              value={email}
              onChange={onChangeEmail}
              width={500}
              height={40}
            />

            <TextFields
              type='password'
              name='Password'
              placeholder={'Password'}
              value={password}
              onChange={onChangePassword}
              width={500}
              height={40}
            />
            <div className='flex items-center'>
              <button
                type='submit'
                className='btn bg-ct4-green-neon font-barlow h-10 w-500 font-semibold text-ct4-dark text-base uppercase leading-0.16 p-0'
              >
                Sign In
              </button>
            </div>

            {isLoggedIn && <Navigate to='/dashboard' replace />}
          </form>
        </div>
        <div className='grid items-end pb-4'>
          <Footer />
        </div>
      </div>
      <div className='bg-background-login w-0.55 h-full bg-no-repeat bg-right absolute right-0 bg-cover' />
      {/* {error && <ActionAlerts type={'error'} message={errorMessage} />} */}
    </div>
  );
};

export default LoginPage;
