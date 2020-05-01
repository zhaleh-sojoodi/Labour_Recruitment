import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import * as Auth from '../../utils/Auth';
import * as DataSanitizer from '../../utils/DataSanitizer';

import TopNav from '../components/TopNav';
import SideNav from '../components/SideNav';
import Footer from '../components/Footer';
import ErrorMessage from '../components/ErrorMessage';
import Table from '../components/Table';
import { JOBS_TABLE_COLUMNS   } from '../../utils/TableColumns';

const BASE_URL = "http://localhost:5001/api";

const ClientProfile = (props) => {

    const [client, setClient] = useState();
    const [jobs, setJobs] = useState();
    const [displayEditButton, setDisplayEditButton] = useState(false);

    const fetchClientData = async(id) => {
        // Get client profile data
        try {
            let response = await fetch(BASE_URL + `/ClientProfile/${id}`, {
                method: "GET",
                headers: {
                  "Authorization": `Bearer ${Auth.getToken()}`
                }
            });

            let data = await response.json();

            if(response.status === 200 && data.client) {
                setClient({...data.client, rating: data.averageRating});
                console.log(data)
            } else {
                console.log("No profile found.");
                throw response;
            }
        } catch(e) {
            console.error(e);
        }

        // Get client jobs
        try {
            let response = await fetch(BASE_URL + `/Job/GetJobByClientId/${id}`, {
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${Auth.getToken()}`
                }
            });

            let data = await response.json();
            if(response.status === 200 && data.length) {
                setJobs(DataSanitizer.cleanJobsData(data));
                console.log(data);
            }
        } catch(e) {
            console.error(e);
        }
    }

    useEffect(() => {
        if(props.match.params.id) {
            if(Number.isInteger(Number(props.match.params.id))) {
                fetchClientData(props.match.params.id);
            }
        } else {
            fetchClientData(Auth.getID());
            setDisplayEditButton(true);
        }
    }, [])

    return (
    <>
    <div className="dashboard-main-wrapper">
        <TopNav />
        <SideNav />

        <div className="dashboard-wrapper">
            <div className="container-fluid dashboard-content">
                {/* Page Header */}
                <div className="row">
                <div className="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div className="page-header">
                    <h2 className="pageheader-title">Profile</h2>
                    <div className="page-breadcrumb">
                    <nav aria-label="breadcrumb">
                    <ol className="breadcrumb">
                        <li className="breadcrumb-item">
                            <Link to="/dashboard" className="breadcrumb-link">Home</Link>
                        </li>
                        <li className="breadcrumb-item active" aria-current="page">
                            Profile
                        </li>
                    </ol>
                    </nav>
                    </div>
                </div>
                </div>
                </div>

                { !client ? <ErrorMessage message={"No profile found."} /> :
                <div className="row">
                    {/* Client Details */}
                    <div className="col-xl-4 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div className="card">
                            <div className="card-body">
                                <h1 className="font-26 mb-2">{client.clientName}</h1>
                            </div>
                            { client.clientDescription &&
                            <div className="card-body border-top">
                                <p>{client.clientDescription}</p>
                            </div>
                            }
                            <div className="card-body border-top">
                                <h3 className="font-16">Average Quality Rating</h3>
                                <p className="font-18">{ client.rating ? `${Math.round((client.rating / 5) * 100)}%` : "N/A" }</p>
                            </div>
                            <div className="card-body border-top">
                                <h3 className="font-16">Contact Information</h3>
                                <ul className="list-unstyled mb-0 icon-list">
                                    <li className="mb-2">
                                        <i className="material-icons">email</i>
                                        <span>{client.clientEmail}</span>
                                    </li>
                                    <li className="mb-2">
                                        <i className="material-icons">phone</i>
                                        <span>{DataSanitizer.phone(client.clientPhoneNumber)}</span>
                                    </li>
                                </ul>
                            </div>
                            <div className="card-body border-top">
                                <h3 className="font-16">Location</h3>
                                <address className="mb-0">
                                    {`${client.clientCity}, ${client.clientState}`}
                                </address>
                            </div>
                            { displayEditButton &&
                            <div className="card-body border-top">
                                <Link
                                    to="/profile/edit"
                                    className="btn btn-light"
                                >
                                    Edit Profile
                                </Link>
                            </div>
                            }
                        </div>
                    </div>

                    {/* Tables */}
                    <div className="col-xl-8 col-lg-12 col-md-12 col-sm-12 col-12">

                        {/* Active Jobs */}
                        <div className="card">
                            <h5 className="card-header">Active Jobs</h5>
                            <div className="card-body">
                            { jobs ?
                            <Table
                                columns={JOBS_TABLE_COLUMNS}
                                data={jobs}
                                path={'/job'}
                                {...props}
                            />
                            :
                            <p className="lead">No jobs to display.</p>
                            }
                            </div>
                        </div>
                    </div>
                </div>
                }

            </div>
            <Footer />
        </div>
    </div>
    </>
    )
}

export default ClientProfile;