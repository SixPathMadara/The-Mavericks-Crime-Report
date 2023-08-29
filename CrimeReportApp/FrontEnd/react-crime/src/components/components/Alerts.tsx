import React from "react";
import { Alert_Info } from "../Info/AlertInfos";
import { useState ,useEffect} from "react";
import "./Alert.css";


interface AlertData{
    Id:number;
    AlertType:string;
    Title:string;
    Message:string;
    ImageUrls?:string[];
}


const Alerts: React.FC = ()=>{
return (
    <div className="div-wrapper">
      {Alert_Info.map((alertData)=>(
      <div className="alert-wrapper" key={alertData.Id}>
        <div className="overlap-group">
          <div className="alert">
            <div className="header-wrapper">
            <div className="image-left">
                <img src={alertData?.ImageUrls?.[0] || ""} alt="" />
            </div>
            <div className="image-center">
                <img src={alertData?.ImageUrls?.[1] || ""} alt="" />
            </div>
            <div className="image-right">
                <img src={alertData?.ImageUrls?.[2] || ""} alt="" />
            </div>
                    <div className="label">
            <div className="alert-header">{alertData?.Title}</div>
            </div>
                    </div>
                    <div className="content-wrapper">
                    <p className="alert-content">
                    {alertData.Message}
                    </p>
                </div>
                </div>
                </div>
            </div>
            ))}
            </div>
);
};

export default Alerts;