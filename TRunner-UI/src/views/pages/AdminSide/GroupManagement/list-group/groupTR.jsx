import React from 'react';
import { StyledTableCell, StyledTableRow } from '../../../../../styles/styles/styled-table';
import ActionIcon from '../../../../components/Icons/action-icon';
import DefaultImage from '../../../../components/Icons/default-image';

const GroupTR = ({ item, handleEdit }) => {
  return (
    <StyledTableRow>
      <StyledTableCell component='th' scope='row'>
        <DefaultImage />
      </StyledTableCell>
      <StyledTableCell align='left'>{item.groupName}</StyledTableCell>
      <StyledTableCell align='left'>{item.desc}</StyledTableCell>
      <StyledTableCell align='left'>{item.location}</StyledTableCell>
      <StyledTableCell align='left'>{item.sport.toString()}</StyledTableCell>
      <StyledTableCell align='left'>{item.groupType}</StyledTableCell>
      <StyledTableCell align='left'>{item.createdDate}</StyledTableCell>
      <StyledTableCell align='left'>{item.totalRunners}</StyledTableCell>
      <StyledTableCell align='left'>{item.active}</StyledTableCell>
      <StyledTableCell align='left' onClick={handleEdit}>
        <div className='cursor-pointer'>
          <ActionIcon />
        </div>
      </StyledTableCell>
    </StyledTableRow>
  );
};

export default GroupTR;
