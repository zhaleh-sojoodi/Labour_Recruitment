import React from 'react';
import { Link } from 'react-router-dom';

import avatar from '../images/avatars/turner.jpg';

const TopNav = (props) => {
    return (
        <div className="main-navbar sticky-top bg-white">
        <nav className="navbar align-items-stretch navbar-light flex-md-nowrap p-0 d-flex justify-content-end">
        <ul className="navbar-nav border-left flex-row">

            {/* User Info */}
            <li className="nav-item dropdown">
              <span className="nav-link dropdown-toggle text-nowrap px-3" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" style={{cursor:'pointer'}}>
                <img className="user-avatar rounded-circle mr-2" src={avatar} alt="User Avatar" />
                <span className="d-none d-md-inline-block">Turner Construction</span>
              </span>

              {/* Client */}
              <div className="dropdown-menu dropdown-menu-small">
                <Link className="dropdown-item" to="/profile/client">
                  <i className="material-icons">&#xE7FD;</i>&nbsp;Profile
                </Link>
                <Link className="dropdown-item" to="/profile/client">
                  <i className="material-icons">edit</i>&nbsp;Edit Profile
                </Link>
                <div className="dropdown-divider"></div>
                <a className="dropdown-item text-danger" href="/" onClick={() => alert("You have been logged out.")}>
                  <i className="material-icons text-danger">&#xE879;</i>&nbsp;Logout
                </a>
              </div>
            </li>
        </ul>

        {/* Mobile Menu Toggle Button */}
        <nav className="nav">
            <a href="./" className="nav-link nav-link-icon toggle-sidebar d-md-inline d-lg-none text-center border-left" data-toggle="collapse" data-target=".header-navbar" aria-expanded="false" aria-controls="header-navbar">
            <i className="material-icons">&#xE5D2;</i>
            </a>
        </nav>
        </nav>
        </div>    
    )
}

export default TopNav;