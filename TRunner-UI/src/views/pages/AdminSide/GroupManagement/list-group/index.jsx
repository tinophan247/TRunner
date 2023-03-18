import { Paper, Table, TableBody, TableContainer, TableHead, TableRow } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { activeDatas, defaultGroupFilter, defaultGroupSort, groupData, groupTypeDatas } from '../../../../../constants';
import FilterIcon from '../../../../components/Icons/filter-icon';
import Paginations from '../../../../components/Pagination';
import TotalResult from '../../../../components/Pagination/total-result';
import SearchFields from '../../../../components/SearchFields';
import GroupTR from './groupTR';
import TextFields from '../../../../components/TextField';
import MultipleSelect from '../../../../components/Dropdown/multi-select';
import SingleSelect from '../../../../components/Dropdown/single-select';
import CloseIcon from '@mui/icons-material/Close';
import { checkMultipleSelect, checkSingleSelect } from '../../../../utils/helpers';
import { sum } from 'lodash';
import { StyledTableCell } from '../../../../../styles/styles/styled-table';
import SortIcon from '../../../../components/Icons/sort-icon';
import Loader from '../../../../components/Loader';

const ListGroup = ({ handleEdit, handleCreate }) => {
  const [formState, setFormState] = useState(defaultGroupFilter);
  const [showFilter, setShowFilter] = useState(false);
  const [filterNumber, setFilterNumber] = useState(0);
  const [isSort, setIsSort] = useState(defaultGroupSort);
  const [loading, setLoading] = useState(false);

  const checkFilterValue =
    formState.location == '' && formState.sport.length == 0 && formState.groupType == '' && formState.active == '';

  const handleCloseFilter = () => {
    setShowFilter(false);
  };

  const handleResetFilter = () => {
    setFormState(defaultGroupFilter);
    setFilterNumber(0);
    setLoading(!loading);
  };

  const handleApplyFilter = () => {
    const checkSelect = checkSingleSelect([formState.location, formState.active, formState.groupType]);
    const checkSport = checkMultipleSelect(formState.sport);
    const result = sum([checkSport, checkSelect]);
    setFilterNumber(result);
    setShowFilter(false);
    setLoading(!loading);
  };

  useEffect(() => {
    if (loading) {
      setTimeout(() => {
        setLoading(false);
      }, 1000);
    }
  }, [loading]);

  const handleSort = type => {
    switch (type) {
      case 'Group Name':
        {
          setIsSort({ ...isSort, groupName: !isSort.groupName });
          setLoading(!loading);
        }
        break;
      case 'Location':
        {
          setIsSort({ ...isSort, location: !isSort.location });
          setLoading(!loading);
        }
        break;
      case 'Sport':
        {
          setIsSort({ ...isSort, sport: !isSort.sport });
          setLoading(!loading);
        }
        break;
      case 'Group Type':
        {
          setIsSort({ ...isSort, groupType: !isSort.groupType });
          setLoading(!loading);
        }
        break;
      case 'Created Date':
        {
          setIsSort({ ...isSort, createdDate: !isSort.createdDate });
          setLoading(!loading);
        }
        break;
      case 'Total Runners':
        {
          setIsSort({ ...isSort, totalRunners: !isSort.totalRunners });
          setLoading(!loading);
        }
        break;
      case 'Active':
        {
          setIsSort({ ...isSort, active: !isSort.active });
          setLoading(!loading);
        }
        break;
      default:
        {
          setIsSort(defaultGroupSort);
          setLoading(!loading);
        }
        break;
    }
  };

  return (
    <div>
      <div className='flex justify-between'>
        <p className='uppercase font-barlow font-semibold text-28'>Groups</p>
        <button
          className='uppercase w-189 h-10 bg-ct4-green-neon font-barlow font-semibold text-sm rounded'
          onClick={() => handleCreate()}
        >
          Create a New Group
        </button>
      </div>
      <div>
        <div className='flex justify-between mt-4 font-barlow text-sm'>
          <SearchFields placeholder='Search by group name...' />
          <div className='cursor-pointer bg-ct4-soft-green flex items-center pr-3' onClick={() => setShowFilter(true)}>
            <FilterIcon />
            <p className='uppercase text-sm text-ct4-dark-green font-semibold'>
              Filter {filterNumber ? `(${filterNumber})` : null}
            </p>
          </div>
        </div>
        {showFilter && (
          <div className='w-full h-100 border border-ct4-border-gray rounded mt-3'>
            <div className='flex justify-between cursor-pointer p-4'>
              <div className='flex gap-8'>
                <TextFields
                  name='Location'
                  width='275px'
                  placeholder={'Location'}
                  value={formState.location}
                  onChange={event => setFormState({ ...formState, location: event.target.value })}
                />
                <MultipleSelect
                  name='Sport'
                  width='275px'
                  value={formState.sport}
                  onChange={event => setFormState({ ...formState, sport: event.target.value })}
                />
                <SingleSelect
                  name='Group Type'
                  width='275px'
                  options={groupTypeDatas}
                  value={formState.groupType}
                  onChange={event => setFormState({ ...formState, groupType: event.target.value })}
                />
                <SingleSelect
                  name='Active'
                  width='275px'
                  options={activeDatas}
                  value={formState.active}
                  onChange={event => setFormState({ ...formState, active: event.target.value })}
                />
                <div className='flex items-end'>
                  <button
                    className='uppercase w-24 h-10 border border-ct4-border-gray font-barlow font-bold text-sm rounded mr-3'
                    onClick={handleResetFilter}
                  >
                    Reset
                  </button>
                  <button
                    className={`uppercase w-24 h-10 ${
                      checkFilterValue ? 'bg-ct4-disable text-ct4-disable-2 ' : 'bg-ct4-green-neon'
                    }   font-barlow font-semibold text-sm rounded`}
                    disabled={checkFilterValue}
                    onClick={handleApplyFilter}
                  >
                    Apply
                  </button>
                </div>
              </div>
              <div className='cursor-pointer' onClick={handleCloseFilter}>
                <CloseIcon />
              </div>
            </div>
          </div>
        )}
        <div className='mt-4'>
          <TableContainer sx={{ maxHeight: 665 }} component={Paper}>
            <Table sx={{ minWidth: 700 }} size='small' aria-label='customized table'>
              <TableHead sx={{ textTransform: 'uppercase' }}>
                <TableRow>
                  <StyledTableCell></StyledTableCell>
                  <StyledTableCell align='left' sx={{ width: '150px' }}>
                    <button
                      className=' flex items-center cursor-pointer'
                      onClick={() => handleSort('Group Name')}
                      disabled={loading}
                    >
                      Group Name
                      <SortIcon isSort={isSort.groupName} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>Description</StyledTableCell>
                  <StyledTableCell align='left'>
                    <button className='flex items-center' onClick={() => handleSort('Location')} disabled={loading}>
                      Location
                      <SortIcon isSort={isSort.location} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>
                    <button
                      className=' flex items-center cursor-pointer'
                      onClick={() => handleSort('Sport')}
                      disabled={loading}
                    >
                      Sport
                      <SortIcon isSort={isSort.sport} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>
                    <button
                      className=' flex items-center cursor-pointer'
                      onClick={() => handleSort('Group Type')}
                      disabled={loading}
                    >
                      Group Type
                      <SortIcon isSort={isSort.groupType} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>
                    <button
                      className=' flex items-center cursor-pointer'
                      onClick={() => handleSort('Created Date')}
                      disabled={loading}
                    >
                      Created Date
                      <SortIcon isSort={isSort.createdDate} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>
                    <button
                      className=' flex items-center cursor-pointer'
                      onClick={() => handleSort('Total Runners')}
                      disabled={loading}
                    >
                      Total Runners
                      <SortIcon isSort={isSort.totalRunners} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>
                    <button
                      className=' flex items-center cursor-pointer'
                      onClick={() => handleSort('Active')}
                      disabled={loading}
                    >
                      Active
                      <SortIcon isSort={isSort.active} />
                    </button>
                  </StyledTableCell>
                  <StyledTableCell align='left'>Action</StyledTableCell>
                </TableRow>
              </TableHead>
              {!loading && (
                <TableBody>
                  {groupData.length > 0 &&
                    groupData.map((item, index) => (
                      <GroupTR item={item} key={index} handleEdit={() => handleEdit(item)} />
                    ))}
                </TableBody>
              )}
            </Table>
            {loading && (
              <div className='w-full h-615 flex justify-center items-center'>
                <Loader />
              </div>
            )}
            {!loading && groupData.length == 0 && (
              <div className='w-full h-14 flex justify-center items-center'>There is no data to display.</div>
            )}
          </TableContainer>
        </div>
        <div className='flex items-center justify-end m-4'>
          <TotalResult total={500} limit={50} />
          <Paginations count={10} />
        </div>
      </div>
    </div>
  );
};

export default ListGroup;
