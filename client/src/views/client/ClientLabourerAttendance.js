import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import TopNav from '../components/TopNav';
import SideNav from '../components/SideNav';
import Footer from '../components/Footer';

import * as Auth from '../../utils/Auth';
import * as DataSanitizer from '../../utils/DataSanitizer';

import RateWorkers from '../components/RateWorkers';

const BASE_URL = "http://localhost:5001/api";
const ClientLabourerAttendance = (props) => {

    const [list, setList] = useState();
    
    const changeRating = async(newRating, labourerId) => {
        let token = Auth.getToken()
        if (token == null) {
            Auth.forceLogout()
        }
        try{
            const response = await fetch(BASE_URL + '/LabourerAttendance', {
                method : 'PUT',
                headers : {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                    'Authorization': `Bearer ${token}`
                }, 
                body : JSON.stringify({
                    JobId : props.match.params.id,
                    LabourerId : labourerId,
                    DailyQualityRating : newRating,
                    Date : props.match.params.date + "T00:00:00"
                })
            })
            const data = await response.json()
            if (data) {
                console.log(data)
            }
        } catch (err) {
            console.error(err);
        }
    }
    const getList = async(id, date) => {
        try {
            const response = await fetch(BASE_URL + `/LabourerAttendance/data?jobId=${id}&date=${date}`, {
                method : 'GET',
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${Auth.getToken()}`
                }
            })
            let data = await response.json();
            setList(DataSanitizer.cleanAttendanceRatingsData(data));
        } catch (err) {
            console.error(err);
        }
    }

    useEffect(() =>{
        if(props.match.params.id && props.match.params.date) {
            let date = props.match.params.date + "T00:00:00"
            getList(props.match.params.id, date);
        }
    }, [])


    return (
    <div className="dashboard-main-wrapper">
        <TopNav />
        <SideNav />

        <div className="dashboard-wrapper">
            <div className="container-fluid dashboard-content">

                {/* Page Header */}
                <div className="row">
                <div className="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div className="page-header">
                    <h2 className="pageheader-title">
                        {`Labourer Attendance for ${DataSanitizer.formatDateString(props.match.params.date)}`}
                    </h2>
                    <hr />
                    <h5 onClick={() => props.history.goBack()} className="text-muted" style={{cursor:'pointer'}}>&larr; Go back</h5>
                </div>
                </div>
                </div>

               <div className="card">
                   <div className="card-body">
                   { list &&
                        <table className="table table-bordered table-striped table-hover">
                            <thead>
                                <tr>
                                    <th>Labourer Name</th>
                                    <th>Quality Rating</th>
                                </tr>
                            </thead>
                            <tbody>
                                {list.map((l,i) => (
                                    <tr key = {i}>
                                        <td>{l.name}</td>
                                        <td>
                                            <RateWorkers  changeRating={changeRating} 
                                                          rating={l.rating} 
                                                          clientId={l.clientId} 
                                                          labourerId={l.labourerId} />
                                        </td>
                                    </tr>
                                ))
                            }
                            </tbody>   
                        </table>
                   } 
                   </div>
               </div>
                
            </div>

            <Footer />
        </div>
    </div>
    )
}

export default ClientLabourerAttendance;