import React from "react";
import "./notification.css";
import {Alert_Info} from "../Info/AlertInfos.js";


interface AlertData{
    Id:number;
    CrimeType:string;
    Title:string;
}

interface Props{
    className:any;
}

const Notification: React.FC =({className}:Props)=>{
    const notifications: AlertData[] = Alert_Info.map((info) => ({
        Id: info.Id,
        CrimeType: info.CrimeType,
        Title: info.Title,
      }));
return (
    <div className={`frame ${className}`}>
    <div className="overlap-group">
      <div className="notification-list">
      <ul className="text-wrapper" >
        {notifications.map((notification)=>(
            <li className="notification-item" key={notification.Id}>
            {notification.Title}
            </li>
        ))}
        </ul>
        </div>
    </div>
    <div className="overlap">
      <div className="notification-icon" />
      <div className="alert-icon" />
    </div>
  </div>
);
};

export default Notification;