import React from "react";

const LoadingComponent: React.FC = () => {
  return (
    <div className="page-loader">
      <div className="loading-container">
        <div className="bar"></div>
        <div className="bar"></div>
        <div className="bar"></div>
        <div className="bar"></div>
      </div>
    </div>
  );
};

export default LoadingComponent;
