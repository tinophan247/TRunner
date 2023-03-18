import * as React from 'react';
import { Checkbox, ListItemIcon } from '@mui/material';
import CheckedIcon from '../Icons/checked-icon';
import { useState } from 'react';
import { StyledFormControl, StyledMenuItem, StyledSelect } from '../../../styles/styles';

//fake data sports
const ITEM_HEIGHT = 50;
const ITEM_PADDING_TOP = 5;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP
    }
  }
};

const sportDatas = ['Run', 'Ride', 'Row', 'Bike', 'Other'];

const MultipleSelect = ({ name, required, value = [], onChange, valid, width = 300 }) => {
  return (
    <div>
      <div className='text-base font-barlow font-medium'>
        <p>
          {name} {required && <span className='text-red-600'>*</span>}
        </p>
        <StyledFormControl>
          <StyledSelect
            multiple
            value={value}
            onChange={onChange}
            sx={{ marginTop: '4px', height: '40px', width: width }}
            renderValue={selected => selected.join(', ')}
            MenuProps={MenuProps}
          >
            {sportDatas.length > 0 &&
              sportDatas.map(item => (
                <StyledMenuItem key={item} value={item}>
                  <ListItemIcon>
                    <Checkbox checked={value.indexOf(item) > -1} checkedIcon={<CheckedIcon />} />
                  </ListItemIcon>
                  {item}
                </StyledMenuItem>
              ))}
          </StyledSelect>
        </StyledFormControl>
      </div>
      <span hidden={valid || !required} className='text-ct4-red-1 text-sm font-barlow-regular'>
        {name} is required!
      </span>
    </div>
  );
};

export default MultipleSelect;
