import React from 'react';
import { OutlinedInput, InputAdornment, IconButton } from '@mui/material';
import { Visibility, VisibilityOff } from '@mui/icons-material';

const FormInput = ({ email, password, changeEmail, changePassword, onClick, isHide, error, isRegister }) => {
  return (
    <div className='pt-5 pb-5 grid gap-2'>
      <OutlinedInput
        required
        className='mt-5 w-full'
        placeholder='Email'
        type='text'
        value={email}
        onChange={changeEmail}
        autoFocus={true}
      />
      {error ? <p className='text-red-600 font-barlow text-left'>Email is correct</p> : null}
      <OutlinedInput
        required
        placeholder='Password'
        className='mt-5 w-full'
        type={isHide ? 'text' : 'password'}
        value={password}
        onChange={changePassword}
        endAdornment={
          <InputAdornment position='end'>
            <IconButton aria-label='toggle password visibility' onClick={onClick}>
              {isHide ? <Visibility /> : <VisibilityOff />}
            </IconButton>
          </InputAdornment>
        }
      />
      {error ? <p className='text-red-600 font-barlow text-left'>Password is correct</p> : null}
      {isRegister && (
        <p className='text-gray-600 my-2 font-barlow text-sm text-left'>Passwords must contain at least 8 charaters.</p>
      )}
    </div>
  );
};

export default FormInput;
