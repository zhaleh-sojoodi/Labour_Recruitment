import React from 'react';
import { Link } from 'react-router-dom';

const SideNav = (props) => {
    return (
        <aside className="main-sidebar col-12 col-md-3 col-lg-2 px-0">

            {/* Logo */}
            <div className="main-navbar">
            <nav className="navbar align-items-stretch navbar-light bg-white flex-md-nowrap border-bottom p-0">
              <a href="/" className="navbar-brand w-100 mr-0" style={{lineHeight:'25px'}}>
                <div className="d-table m-auto">
                  <span className="d-none d-md-inline">Labourer Recruitment Platform</span>
                </div>
              </a>
              <span className="toggle-sidebar d-sm-inline d-md-none d-lg-none">
                <i className="material-icons">&#xE5C4;</i>
              </span>
            </nav>
            </div>

            {/* Side Navigation */}
            <div className="nav-wrapper">

            {/* NOTE: We should check what TYPE of user is logged in before loading the correct links below here */}
            <ul className="nav flex-column">
              <li className="nav-item">
                <Link className="nav-link" to='/dashboard'>
                  <i className="material-icons">dashboard</i>
                  <span>Dashboard</span>
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/addjob">
                  <i className="material-icons">create</i>
                  <span>Add Job</span>
                </Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/profile/client">
                  <i className="material-icons">person</i>
                  <span>Profile</span>
                </Link>
              </li>
            </ul>

            </div>
        </aside> 
    )
}

export default SideNav;