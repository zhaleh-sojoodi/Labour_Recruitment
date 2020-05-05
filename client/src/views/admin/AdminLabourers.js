import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import * as Auth from '../../utils/Auth';
import * as DataSanitizer from '../../utils/DataSanitizer';

import Layout from '../components/Layout';
import Loader from '../components/Loader';
import Table from '../components/Table';
import ErrorMessage from '../components/ErrorMessage';

import { LABOURERS_TABLE_COLUMNS   } from '../../utils/TableColumns';

const BASE_URL = "http://localhost:5001/api";

const AdminLabourers = (props) => {

    const [labourers, setLabourers] = useState([]);
    const [loaded, setLoaded] = useState(false);

    const fetchLabourers = async() => {
        try {
            let response = await fetch(BASE_URL + "/LabourerProfile", {
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${Auth.getToken()}`
                }
            });

            if(response.status !== 200) {
                throw response;
            }

            let data = await response.json();

            if(data && data.length) {
                setLabourers(DataSanitizer.cleanLabourersData(data));
            }
        } catch(e) {
            console.error(e);
        }
        setLoaded(true);
    }

    useEffect(() => {
        fetchLabourers();
    }, [])

    const content = (
        <>
        {/* Page Header */}
        <div className="page-header">
        <h2 className="pageheader-title">
            Manage Labourers
        </h2>
        <div className="page-breadcrumb">
        <nav aria-label="breadcrumb">
        <ol className="breadcrumb">
            <li className="breadcrumb-item">
                <Link to="/dashboard" className="breadcrumb-link">Home</Link>
            </li>
            <li className="breadcrumb-item active" aria-current="page">
                Labourers
            </li>
        </ol>
        </nav>
        </div>
        </div>

        {/* Labourers Table */}
        <div className="row">
        <div className="col">
        <div className="card">
            <h5 className="card-header">All Labourers</h5>
            <div className="card-body">
                <Loader loaded={loaded}>
                    { !labourers.length ? <ErrorMessage message={"No labourer data."} /> : 
                    <Table 
                        columns={LABOURERS_TABLE_COLUMNS}
                        data={labourers}
                        path={"/profile/labourer"}
                        {...props}
                    />
                    }
                </Loader>
            </div>
        </div>
        </div>
        </div>
        </>
    );

    return <Layout content={content} />;
}

export default AdminLabourers;