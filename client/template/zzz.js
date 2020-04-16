import React from 'react';
import './css/styles.css';
import './css/extras.min.css';

function App() {
    return (
    <>
    <div className="container-fluid">
    <div className="row">
    <aside className="main-sidebar col-12 col-md-3 col-lg-2 px-0">
          <div className="main-navbar">
            <nav className="navbar align-items-stretch navbar-light bg-white flex-md-nowrap border-bottom p-0">
              <a className="navbar-brand w-100 mr-0" href="./" style={{lineHeight:'25px'}}>
                <div className="d-table m-auto">
                  <img id="main-logo" className="d-inline-block align-top mr-1" style={{maxWidth:'25px'}} src="images/shards-dashboards-logo.svg" alt="Shards Dashboard" />
                  <span className="d-none d-md-inline ml-1">Shards Dashboard</span>
                </div>
              </a>
              <a className="toggle-sidebar d-sm-inline d-md-none d-lg-none">
                <i className="material-icons">&#xE5C4;</i>
              </a>
            </nav>
          </div>
          <form action="#" className="main-sidebar__search w-100 border-right d-sm-flex d-md-none d-lg-none">
            <div className="input-group input-group-seamless ml-3">
              <div className="input-group-prepend">
                <div className="input-group-text">
                  <i className="fas fa-search"></i>
                </div>
              </div>
              <input className="navbar-search form-control" type="text" placeholder="Search for something..." aria-label="Search" />
            </div>
          </form>
          <div className="nav-wrapper">
            <ul className="nav flex-column">
              <li className="nav-item">
                <a className="nav-link active" href="index.html">
                  <i className="material-icons">edit</i>
                  <span>Blog Dashboard</span>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link " href="components-blog-posts.html">
                  <i className="material-icons">vertical_split</i>
                  <span>Blog Posts</span>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link " href="add-new-post.html">
                  <i className="material-icons">note_add</i>
                  <span>Add New Post</span>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link " href="form-components.html">
                  <i className="material-icons">view_module</i>
                  <span>Forms &amp; Components</span>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link " href="tables.html">
                  <i className="material-icons">table_chart</i>
                  <span>Tables</span>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link " href="user-profile-lite.html">
                  <i className="material-icons">person</i>
                  <span>User Profile</span>
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link " href="errors.html">
                  <i className="material-icons">error</i>
                  <span>Errors</span>
                </a>
              </li>
            </ul>
          </div>
        </aside>    
    </div>
    </div>
    </>
    )
}

export default App;