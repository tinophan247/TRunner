import React from 'react'

const FilterIcon = ({ width = '30', height = '40' }) => {
  return (
    <svg width={width} height={height} viewBox="0 0 30 40" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M9.25 16L21.75 16" stroke="#457900" strokeWidth="1.5" strokeLinecap="round" />
      <path d="M11.75 20L19.25 20" stroke="#457900" strokeWidth="1.5" strokeLinecap="round" />
      <path d="M14.25 24L16.75 24" stroke="#457900" strokeWidth="1.5" strokeLinecap="round" />
    </svg>
  )
}

export default FilterIcon;