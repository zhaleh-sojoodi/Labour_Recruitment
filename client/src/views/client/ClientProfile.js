import React from 'react';

import SideNav from '../../components/SideNav';
import TopNav from '../../components/TopNav';

import '../../css/styles.css';
import '../../css/extras.min.css';


const ClientProfile = (props) => {
    return (
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
           <div class="row">
            <div class="col-lg-4">
              <div class="mb-4 pt-3 card card-small">
                <div class="border-bottom text-center card-header">
                  <h4 class="mb-0">Sierra Brooks</h4>
                  <span class="m-5"><i class="fas fa-star mr-2"></i>4.91 (18 ratings)</span>
                </div>
                <ul class="list-group list-group-flush">
                  <li class="p-4 list-group-item">
                    <strong class="text-muted d-block mb-2">Description</strong>
                    <span>Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio eaque, quidem, commodi soluta qui quae minima obcaecati quod dolorum sint alias, possimus illum assumenda eligendi cumque?</span>
                  </li>
                </ul>
              </div>
            </div>
            <div class="col-lg-8">
              <div class="mb-4 card card-small">
                <div class="border-bottom card-header d-flex justify-content-between">
                  <h6 class="m-0">Account Details</h6>
                  <span><i class="far fa-edit"></i></span>
                </div>
                <ul class="list-group list-group-flush">
                  <li class="p-3 list-group-item">
                    <table>
                      <tr>
                        <td class="pl-4 pr-4 pb-3">Email:</td>
                        <td class="pl-4 pr-4 pb-3">info@construction.ca</td>
                      </tr>
                      <tr>
                        <td  class="pl-4 pr-4 pb-3">Telephone No.:</td>
                        <td class="pl-4 pr-4 pb-3">(604)778-8888</td>
                      </tr>
                      <tr>
                        <td  class="pl-4 pr-4 pb-3">Address:</td>
                        <td class="pl-4 pr-4 pb-3">1234 Burrad Street, Vancouver BC</td>
                      </tr>
                    </table>
                  </li>
                  <li class="p-3 pb-4 list-group-item">
                    <div class="row">
                      <div class="col">
                        <span class="pl-4 pr-4 pb-3">Rate The Company</span>
                        <span class="pl-4 pr-4 pb-3"><i class="fas fa-star mr-2"></i><i class="fas fa-star mr-2"></i><i class="fas fa-star mr-2"></i><i class="fas fa-star mr-2"></i><i class="fas fa-star mr-2"></i></span>
                      </div>
                    </div>
                  </li>
                </ul> 
              </div> 
            </div>
          </div>
        </div>
      </main>
    </div>
    </div>

  )
}

export default ClientProfile;