import React, { useState } from 'react'
import Ratings from 'react-ratings-declarative';
import * as Auth from '../../utils/Auth';

const BASE_URL = "http://localhost:5001/api";
const RateWorkers = (props) => {
    
    const changeRating = async(newRating) => {
        props.changeRating(newRating)
    }
    
    return (
        <Ratings
            rating= {5}
            widgetDimensions="14px"
            name = "rating"
            changeRating = { 
                props.clientId == Auth.getID() ?
                changeRating : null
            }
        >
            <Ratings.Widget widgetHoverColor="#6d7a82"/>
            <Ratings.Widget widgetHoverColor="#6d7a82"/>
            <Ratings.Widget widgetHoverColor="#6d7a82"/>
            <Ratings.Widget widgetHoverColor="#6d7a82"/>
            <Ratings.Widget widgetHoverColor="#6d7a82"/> 
        </Ratings>
    )

}

export default RateWorkers;