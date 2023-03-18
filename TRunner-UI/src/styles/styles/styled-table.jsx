import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableRow from '@mui/material/TableRow';
import { styled } from '@mui/material/styles';
import { Pagination } from '@mui/material';

export const StyledTableCell = styled(TableCell)(() => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: '#f6f6f6',
    color: '#333333',
    fontFamily: 'Barlow',
    fontWeight: 600,
    fontSize: 14,
    height: 48
  },
  [`&.${tableCellClasses.body}`]: {
    backgroundColor: '#ffffff',
    color: '#333333',
    fontFamily: 'Barlow',
    fontWeight: 400,
    fontSize: 16,
    height: 56
  }
}));

export const StyledTableRow = styled(TableRow)(() => ({
  '&:nth-of-type(odd)': {
    backgroundColor: '#ffffff'
  }
}));

export const StyledPagination = styled(Pagination)(() => ({
  '& button': {
    '&.Mui-selected': {
      borderColor: '#457900',
      color: '#457900',
      backgroundColor: '#fff'
    }
  }
}));
