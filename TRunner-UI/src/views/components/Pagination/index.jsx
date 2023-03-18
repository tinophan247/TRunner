import React from 'react';
import Stack from '@mui/material/Stack';
import { StyledPagination } from '../../../styles/styles/styled-table';

const Paginations = ({ count }) => {
  return (
    <div>
      <Stack spacing={2}>
        <StyledPagination count={count} variant='outlined' shape='rounded' />
      </Stack>
    </div>
  );
};

export default Paginations;
