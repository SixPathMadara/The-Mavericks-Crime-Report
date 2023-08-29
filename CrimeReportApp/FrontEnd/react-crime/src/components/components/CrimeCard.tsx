/* CrimeCard.tsx */
import React from "react";

interface CrimeCardProps {
  title: string;
  description: string;
  location: string;
  reportDate: string;
}

const CrimeCard: React.FC<CrimeCardProps> = ({
  title,
  description,
  location,
  reportDate,
}) => {
  return (
    <div className="crime-card">
      <h2 className="crime-title">
        <a href="#">{title}</a>
      </h2>
      <p className="crime-description">{description}</p>
      <p className="crime-location">{location}</p>
      <p className="crime-report-date">Report Date: {reportDate}</p>
      <button className="witness-btn">Witness</button>
    </div>
  );
};

export default CrimeCard;
