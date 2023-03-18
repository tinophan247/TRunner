import React from 'react';

const SortIcon = ({ isSort, onClick }) => {
  return (
    <svg
      className={`ml-1 cursor-pointer transform ${isSort ? 'rotate-0' : 'rotate-180'}`}
      width={13}
      height={15}
      viewBox='0 0 10 12'
      fill='none'
      xmlns='http://www.w3.org/2000/svg'
    >
      <path
        d='M8.33329 7.66667L4.99996 11M4.99996 11L1.66663 7.66667M4.99996 11V1'
        stroke='#686868'
        strokeWidth='1.5'
        strokeLinecap='round'
        strokeLinejoin='round'
      />
    </svg>
  );
};

export default SortIcon;
