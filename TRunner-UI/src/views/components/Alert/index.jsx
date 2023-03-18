import React, { useEffect } from 'react';
import { Stack, Alert } from '@mui/material';
import { useSelector } from 'react-redux';
import { StyledSnackbar } from './styles';

const ActionAlerts = ({ message, type }) => {
  const { error } = useSelector(state => state.auth);

  const [open, setOpen] = React.useState(false);

  const handleClosed = () => {
    console.log('object', open);
    setOpen(!open);
  };

  useEffect(() => {
    console.log('vo nưa k 1');
    if (error) {
      setOpen(!open);
    }
  }, [error]);

  return (
    <StyledSnackbar
      open={open}
      // autoHideDuration={3000}
      onClose={() => handleClosed()}
      sx={{ width: '20%'}}
      // position='absolute'
      width='100%'
    >
      <Alert
        // sx={
        //   {
        //     // width: '80%',
        //     // margin: 'auto',
        //     //  backgroundColor: 'green'
        //   }
        // }
        severity={type}
        onClose={() => handleClosed()}
      >
        {message}
      </Alert>
    </StyledSnackbar>
  );
};
export default ActionAlerts;
