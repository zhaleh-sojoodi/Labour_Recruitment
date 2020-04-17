import React from 'react';

import SideNav from '../../components/SideNav';
import TopNav from '../../components/TopNav';

import '../../css/styles.css';
import '../../css/extras.min.css';

const ClientProfile = (props) => {
    return (
    <>
    <div className="container-fluid">
    <div className="row">
      {/* Side Navigation */}
      <SideNav {...props} />

      {/* Main */}
      <main className="main-content col-lg-10 col-md-9 col-sm-12 p-0 offset-lg-2 offset-md-3">
        {/* Top Navigation */}
        <TopNav {...props} />

        {/* Content */}
        <div className="main-content-container container-fluid px-4">
          <div className="page-header row no-gutters py-4">
          <div className="col-12 col-sm-4 text-center text-sm-left mb-0">
            <h3 className="page-title">Client Profile</h3>
          </div>
          </div>

          <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ex error maxime repudiandae ipsam commodi necessitatibus reiciendis beatae deserunt placeat at veniam possimus velit, laboriosam ducimus, amet facere? Voluptatem, cum sed?</p>

        </div>
      </main>
    </div>
    </div>
    </>
    )
}

export default ClientProfile;