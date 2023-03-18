import React from 'react';
import Box from '@mui/material/Box';
import { StyledTextField } from '../../../styles/styles';

const TextArea = ({ name, required, value, onChange, type, width = '600px', height = '120px', placeholder, valid }) => {
  return (
    <div className='text-base font-barlow font-medium'>
      <p>
        {name} {required && <span className='text-red-600'>*</span>}
      </p>
      <Box
        component='form'
        sx={{
          '& .MuiTextField-root': { width: width, height: height, marginTop: '4px' }
        }}
        autoComplete='off'
      >
        <StyledTextField
          size='small'
          value={value}
          onChange={onChange}
          required={required ?? null}
          type={type}
          placeholder={placeholder}
          multiline
          InputProps={{
            rows: 5
          }}
        />
      </Box>
      <span hidden={valid || !required} className='text-ct4-red-1'>
        {name} is required!
      </span>
    </div>
  );
};

export default TextArea;
