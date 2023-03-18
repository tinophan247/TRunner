import * as React from 'react';
import CircularProgress from '@mui/material/CircularProgress';
import Box from '@mui/material/Box';
import { Backdrop } from '@mui/material';

const Loader = ({show}) => {
  return (
    // <Box sx={{ display: 'flex' }}>
    //   <CircularProgress
    //     sx={{
    //       color: '#457900'
    //     }}
    //     size={30}
    //   />
    // </Box>

    <Backdrop sx={{ color: '#fff', zIndex: theme => theme.zIndex.drawer + 1 }} open={show} close={!show}>
      <CircularProgress  sx={{
          color: '#457900'
        }} />
    </Backdrop>
  );
};
export default Loader;
