import React from 'react';
import { FormControl, InputAdornment } from '@mui/material';
import SearchIcon from '../Icons/search-icon';
import { StyledTextField } from '../../../styles/styles';

const SearchFields = ({ placeholder = 'Search...', sx = { width: '360px', height: '40px', borderRadius: '4px' } }) => {
  return (
    <div>
      <FormControl>
        <StyledTextField
          placeholder={placeholder}
          size='small'
          variant='outlined'
          InputProps={{
            endAdornment: (
              <InputAdornment position='end'>
                <SearchIcon />
              </InputAdornment>
            )
          }}
          sx={sx}
        />
      </FormControl>
    </div>
  );
};

export default SearchFields;
