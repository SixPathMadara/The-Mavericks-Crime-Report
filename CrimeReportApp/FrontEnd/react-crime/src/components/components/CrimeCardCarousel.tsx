import React from "react";
import CrimeCard from "./CrimeCard";

import WallpaperImage from "C:/Users/kenny/Documents/my-crime-app/src/wallpaper.jpg"; // Image Path

interface CrimeCardCarouselProps {
  crimeData: CrimeData[];
}

interface CrimeData {
  id: number;
  typeID: number;
  description: string;
  reportDate: string;
  //reportDate: Date;
  //latitude: number;
  //longitude: number;
  address: string;
}

const CrimeCardCarousel: React.FC<CrimeCardCarouselProps> = ({ crimeData }) => {
  //mapping between typeID and corresponding title
  const titleMap: { [key: number]: string } = {
    0: "Theft",
    1: "Robbery",
    2: "Car Jacking",
    4: "Burglary",
    5: "Vandalism",
    6: "Assault",
    7: "Arson",
    8: "Abuse",
    9: "Illegal Drug Trade",
    10: "Kidnapping"

    /*
        <option value="0">Theft</option>
        <option value="1">Robbery </option>
        <option value="2">Car Jacking</option>
        <option value="3">Burglary</option>
        <option value="4">Vandalism</option>
        <option value="5">Assault</option>
        <option value="6">Arson</option>
        <option value="7">Abuse</option>
        <option value="8">Illegal Drug Trade</option>
        <option value="9">Kidnapping</option>
    */
  };

  return (
    <div className="crime-card-carousel-container">
    <div className="background-image">
      src={WallpaperImage}
    </div>
    <div className="crime-cards-scroll">
      <div className="crime-cards">
        {crimeData.map((crime) => (
          <CrimeCard
            key={crime.id}
            title={titleMap[crime.typeID]}
            description={crime.description}
            location={crime.address}
            reportDate={crime.reportDate}
          />
        ))}
      </div>
    </div>
  </div>
  );
};

export default CrimeCardCarousel;
