import React from 'react'

const DashboardIcon = ({ width = '22', height = '22', stroke = '#888888' }) => {
  return (
    <svg width={width} height={height} viewBox="0 0 22 22" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M1.40002 1.40002H10.5001V10.2847H1.40002V1.40002ZM1.40002 13.5001H10.5001V20.5001L1.40002 20.6V13.5001ZM13.4 11H20.6V20.6H13.4V11ZM13.4 1.40002H20.6V8.00012H13.4V1.40002Z" stroke={stroke} strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round">
      </path>
    </svg>
  )
}

export default DashboardIcon;