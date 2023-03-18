import React from 'react'

const SportIcon = ({ width = '24', height = '24', stroke = '#888888' }) => {
  return (
    <svg width={width} height={height} viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M13.8275 7.99623C13.7091 5.11664 14.7355 4.23892 16.2248 4.16281L17.9973 14.612L20.4885 15.2942C22.7555 15.915 22.8966 17.7692 22.8966 19.2879C22.6092 20.7122 22.3402 21.3198 21.6856 22.1004H17.6675C16.8164 22.1004 15.7298 21.895 14.6823 21.4596C13.7896 21.0885 12.9084 20.5472 12.1949 19.8181L1.54419 8.93375C3.83858 6.58909 6.13291 4.24437 8.4273 1.89966C11.3117 2.68952 9.65303 9.81389 16.6788 7.89009M3.56573 7.02261L8.26982 11.8299L14.1408 17.8296C14.5778 18.2762 15.1376 18.6161 15.7144 18.8558C16.4207 19.1494 17.1288 19.2879 17.6676 19.2879H22.7522" stroke={stroke} strokeWidth="1.5" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
      <path d="M17.9971 14.6121L16.8413 16.6579" stroke={stroke} strokeWidth="1.2" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
      <path d="M17.0776 10.1113L15.2214 10.6196" stroke={stroke} strokeWidth="1.2" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
      <path d="M17.4531 12.325L15.5969 12.8332" stroke={stroke} strokeWidth="1.2" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
      <path d="M5.90911 18L0.984863 18" stroke={stroke} strokeWidth="1.5" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
      <path d="M9.8485 22L0.984863 22" stroke={stroke} strokeWidth="1.5" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
      <path d="M3.12129 14H0.984863" stroke={stroke} strokeWidth="1.5" strokeMiterlimit="22.9256" strokeLinecap="round" strokeLinejoin="round" />
    </svg>

  )
}

export default SportIcon;