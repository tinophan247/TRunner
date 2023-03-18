import { Paper, Table, TableBody, TableContainer, TableHead, TableRow } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { sportData, sportTypeDatas, activeDatas, defaultSportSort, defaultSportFilter } from '../../../../../constants';
import { StyledTableCell } from '../../../../../styles/styles/styled-table';
import FilterIcon from '../../../../components/Icons/filter-icon';
import Paginations from '../../../../components/Pagination';
import TotalResult from '../../../../components/Pagination/total-result';
import SearchFields from '../../../../components/SearchFields';
import SportTR from './sportTR';
import CloseIcon from '@mui/icons-material/Close';
import SingleSelect from '../../../../components/Dropdown/single-select';
import { checkSingleSelect } from '../../../../utils/helpers';
import SortIcon from '../../../../components/Icons/sort-icon';
import Loader from '../../../../components/Loader';

const ListSport = ({ handleCreate, handleEdit, isLoading }) => {
  const [formState, setFormState] = useState(defaultSportFilter);
  const [filterNumber, setFilterNumber] = useState(0);
  const [showFilter, setShowFilter] = useState(false);
  const [isSort, setIsSort] = useState(defaultSportSort);
  const [loading, setLoading] = useState(isLoading);

  const checkFilterValue = formState.sportType == '' && formState.active == '';

  const handleCloseFilter = () => {
    setShowFilter(false);
  };

  const handleResetFilter = () => {
    setFormState(defaultSportFilter);
    setFilterNumber(0);
    setLoading(!loading);
  };

  const handleApplyFilter = () => {
    const checkSelect = checkSingleSelect([formState.active, formState.sportType]);
    setFilterNumber(checkSelect);
    setShowFilter(false);
    setLoading(!loading);
  };

  const handleSort = type => {
    switch (type) {
      case 'Sport Name':
        {
          setIsSort({ ...isSort, sportName: !isSort.sportName });
          setLoading(!loading);
        }
        break;
      case 'Sport Type':
        {
          setIsSort({ ...isSort, sportType: !isSort.sportType });
          setLoading(!loading);
        }
        break;
      case 'Last Modified By':
        {
          setIsSort({ ...isSort, lastModifiedBy: !isSort.lastModifiedBy });
          setLoading(!loading);
        }
        break;
      case 'Last Modified Date':
        {
          setIsSort({ ...isSort, lastModifiedDate: !isSort.lastModifiedDate });
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
          setIsSort(defaultSportSort);
          setLoading(!loading);
        }
        break;
    }
  };

  return (
    <div>
      <div className='flex justify-between'>
        <p className='uppercase font-barlow font-semibold text-28'>Sports</p>
        <button
          className='uppercase w-189 h-10 bg-ct4-green-neon font-barlow font-semibold text-sm rounded'
          onClick={() => handleCreate()}
        >
          Create a New Sport
        </button>
      </div>
      <div className='flex justify-between mt-4 font-barlow text-sm'>
        <SearchFields placeholder='Search by sport name...' />
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
              <SingleSelect
                name='Sport Type'
                width='275px'
                options={sportTypeDatas}
                value={formState.sportType}
                onChange={event => setFormState({ ...formState, sportType: event.target.value })}
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
                <StyledTableCell align='left'>
                  <button
                    className=' flex items-center cursor-pointer'
                    onClick={() => handleSort('Sport Name')}
                    disabled={loading}
                  >
                    Sport Name
                    <SortIcon isSort={isSort.sportName} />
                  </button>
                </StyledTableCell>
                <StyledTableCell align='left'>
                  <button
                    className=' flex items-center cursor-pointer'
                    onClick={() => handleSort('Sport Type')}
                    disabled={loading}
                  >
                    Sport Type
                    <SortIcon isSort={isSort.sportType} />
                  </button>
                </StyledTableCell>
                <StyledTableCell align='left'>
                  <button
                    className=' flex items-center cursor-pointer'
                    onClick={() => handleSort('Last Modified By')}
                    disabled={loading}
                  >
                    Last Modified By
                    <SortIcon isSort={isSort.lastModifiedBy} />
                  </button>
                </StyledTableCell>
                <StyledTableCell align='left'>
                  <button
                    className=' flex items-center cursor-pointer'
                    onClick={() => handleSort('Last Modified Date')}
                    disabled={loading}
                  >
                    Last Modified Date
                    <SortIcon isSort={isSort.lastModifiedDate} />
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
                {sportData.length > 0 &&
                  sportData.map((item, index) => (
                    <SportTR item={item} key={index} handleEdit={() => handleEdit(item)} />
                  ))}
              </TableBody>
            )}
          </Table>
          {loading && (
            <div className='w-full h-615 flex justify-center items-center'>
              <Loader />
            </div>
          )}
          {!loading && sportData.length == 0 && (
            <div className='w-full h-14 flex justify-center items-center'>There is no data to display.</div>
          )}
        </TableContainer>
      </div>
      <div className='flex items-center justify-end m-4'>
        <TotalResult total={500} limit={50} />
        <Paginations count={10} />
      </div>
    </div>
  );
};

export default ListSport;
