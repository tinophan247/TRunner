import React from 'react'
import Footer from '../Footer';
import AdminHeader from '../Header/admin-header';
import LeftSideBar from '../LeftSidebar';

const PageLayout = ({ children }) => {
  return (
    <div>
      <AdminHeader />
      <div className='flex '>
        <LeftSideBar />
        <div className='px-8 my-6 w-full grid'>
          {children}
          <div className='m-auto -mb-2'>
            <Footer />
          </div>
        </div>
      </div>
    </div>
  )
}

export default PageLayout;