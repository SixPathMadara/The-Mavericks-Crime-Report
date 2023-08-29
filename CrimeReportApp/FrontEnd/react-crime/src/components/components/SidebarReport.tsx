// src/components/SidebarReport.tsx
import React from "react";

const SidebarReport: React.FC = () => {
  return (
    <div className="sidebarReport">
      <div className="border shadow">
        <h2>Report</h2>
        <h3>Type of crime:</h3>
        <label className="material-checkbox">
          <input type="checkbox" />
          <span className="checkmark"></span>
          Vandilism
        </label>
        <label className="material-checkbox">
          <input type="checkbox" />
          <span className="checkmark"></span>
          Robbery
        </label>
        <label className="material-checkbox">
          <input type="checkbox" />
          <span className="checkmark"></span>
          Burglarly
        </label>
        <h3>Description:</h3>
        <textarea name="" id="" cols={80} rows={10}></textarea>
        <h3>Location:</h3>
        <form>
          <div className="users">
            <input type="text" name="" required />
            <label>City</label>
          </div>
          <div className="users">
            <input type="password" name="" required />
            <label>Area</label>
          </div>
        </form>
        <button className="btnSubReport">Submit Report</button>
      </div>
    </div>
  );
};

export default SidebarReport;
