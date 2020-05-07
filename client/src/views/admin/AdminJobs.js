import React, { useState, useEffect } from 'react';

import * as Auth from '../../utils/Auth';
import * as DataSanitizer from '../../utils/DataSanitizer';

import Loader from '../components/Loader';
import Layout from '../components/Layout';
import PageHeader from '../components/PageHeader';
import Table from '../components/Table';
import ErrorMessage from '../components/ErrorMessage';
import UnauthorizedMessage from '../components/UnauthorizedMessage';

const BASE_URL = "http://localhost:5001/api";

const AdminJobs = (props) => {

    // Authorization
    const [authorized] = useState(Auth.authenticateAdmin());

    // Components
    const [loaded, setLoaded] = useState(false);

    // Data
    const [jobs, setJobs] = useState();
    const [jobsTableColumns, setJobsTableColumns] = useState();

    const fetchJobs = async() => {
        try {
            const URI = BASE_URL + "/Job/GetAllActiveJobs";
            let response = await fetch(URI, {
                method: "GET",
                headers: {
                    "Authorization": `Bearer ${Auth.getToken()}`
                }
            });

            if(response.status !== 200) {
                throw response;
            }

            let data = await response.json();

            if(data.length) {
                let formattedData = data.map(d => ({
                    id: d.jobId,
                    title: d.title,
                    startdate: DataSanitizer.formatDateString(d.startDate),
                    enddate: DataSanitizer.formatDateString(d.endDate),
                    status: d.isComplete ? "Complete" : "In Progress"
                }));

                setJobs(formattedData);
                setJobsTableColumns([
                    {Header: 'Job Title', accessor: 'title'},
                    {Header: 'Start Date', accessor: 'startdate'},
                    {Header: 'End Date', accessor: 'enddate'},
                    {Header: 'Completion Status', accessor: 'status'},
                ]);
            }
        } catch(e) {
            console.error(e);
        }

        // Set loading state
        setLoaded(true);
    }

    useEffect(() => {
        if(authorized) fetchJobs();
    }, [])

    const content = (
    <>
    <PageHeader
        title={`Manage Jobs`}
        breadcrumbs={[
            { name: "Home", path: "/dashboard" },
            { name: "Jobs" }
        ]}
    />

    <Loader loaded={loaded}>
        {/* Jobs Table */}
        <div className="row">
            <div className="col">
            <div className="card">
            <h5 className="card-header">Active Jobs</h5>
            <div className="card-body">
                { !jobs ? <ErrorMessage message={"No jobs to display."} /> :
                <Table
                    data={jobs}
                    columns={jobsTableColumns}
                    path="/job"
                    searchable={true}
                    striped={true}
                    {...props}
                />
                }
            </div>
            </div>
            </div>
        </div>
    </Loader>
    </>
    );

    return <Layout content={authorized ? content : <UnauthorizedMessage />} />;
}

export default AdminJobs;