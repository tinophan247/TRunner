import React from 'react';

const CheckedIcon = ({ size = '24' }) => {
  return (
    <svg width={size} height={size} viewBox="0 0 20 20" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M4 0.5H16C17.933 0.5 19.5 2.067 19.5 4V16C19.5 17.933 17.933 19.5 16 19.5H4C2.067 19.5 0.5 17.933 0.5 16V4C0.5 2.067 2.067 0.5 4 0.5Z" fill="#A0E50F" stroke="#A0E50F" />
      <path d="M15.3337 6L8.00033 13.3333L4.66699 10" stroke="#333333" strokeWidth={2} strokeLinecap="round" strokeLinejoin="round" />
    </svg>
  )
};

export default CheckedIcon;