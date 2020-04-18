import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

// General CSS
import './assets/other/bootstrap/css/bootstrap.min.css';
import './assets/fonts/circular-std/style.css';
import './assets/css/style.css';

// Data Table CSS
import './assets/other/datatables/css/dataTables.bootstrap4.css';
import './assets/other/datatables/css/buttons.bootstrap4.css';
import './assets/other/datatables/css/select.bootstrap4.css';

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);