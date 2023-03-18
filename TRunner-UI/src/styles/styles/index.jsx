import { FormControl, MenuItem } from '@mui/material';
import Select from '@mui/material/Select';
import { styled } from '@mui/material/styles';
import TextField from '@mui/material/TextField';

export const StyledSelect = styled(Select)(() => ({
  width: '600px',
  height: '40px',
  fontSize: '16px',
  fontFamily: 'Barlow'
}));

export const StyledFormControl = styled(FormControl)(() => ({
  '& .MuiInputBase-root': {
    borderColor: '#dfdfdf',
    borderWidth: '1px',
    borderStyle: 'solid'
  },
  '& .MuiOutlinedInput-root': {
    '& fieldset': {
      borderColor: '#dfdfdf'
    },
    '&:hover fieldset': {
      borderColor: '#457900'
    },
    '&.Mui-focused fieldset': {
      borderColor: '#457900'
    }
  }
}));

export const StyledMenuItem = styled(MenuItem)(() => ({
  fontSize: '14px',
  fontFamily: 'Barlow',
  color: '#000000',
  '& .MuiMenuItem-root': {
    backgroundColor: '#000000'
  }
}));

export const StyledTextField = styled(TextField)(() => ({
  '& input::placeholder': {
    fontSize: '16px',
    fontFamily: 'Barlow'
  },
  '& input': {
    fontSize: '16px',
    fontFamily: 'Barlow'
  },
  '& textarea::placeholder': {
    fontSize: '16px',
    fontFamily: 'Barlow'
  },
  '& textarea': {
    fontSize: '16px',
    fontFamily: 'Barlow'
  },
  '& .MuiOutlinedInput-root': {
    '& fieldset': {
      borderColor: '#dfdfdf'
    },
    '&:hover fieldset': {
      borderColor: '#457900'
    },
    '&.Mui-focused fieldset': {
      borderColor: '#457900'
    }
  }
}));
