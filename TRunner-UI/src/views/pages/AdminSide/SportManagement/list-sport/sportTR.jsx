import React from 'react';
import ActionIcon from '../../../../components/Icons/action-icon';
import DefaultImage from '../../../../components/Icons/default-image';
import { StyledTableCell, StyledTableRow } from '../../../../../styles/styles/styled-table';

const SportTR = ({ item, handleEdit }) => {
  return (
    <StyledTableRow>
      <StyledTableCell align='right' component='th' scope='row'>
        <DefaultImage />
      </StyledTableCell>
      <StyledTableCell align='left'>{item.sportName}</StyledTableCell>
      <StyledTableCell align='left'>{item.sportType}</StyledTableCell>
      <StyledTableCell align='left'>{item.lastModifiedBy}</StyledTableCell>
      <StyledTableCell align='left'>{item.lastModifiedDate}</StyledTableCell>
      <StyledTableCell align='left'>{item.active}</StyledTableCell>
      <StyledTableCell align='left' onClick={handleEdit}>
        <div className='cursor-pointer'>
          <ActionIcon />
        </div>
      </StyledTableCell>
    </StyledTableRow>
  );
};

export default SportTR;
