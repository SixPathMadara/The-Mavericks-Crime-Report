import React, { useEffect, useState } from "react";
import CrimeCardCarousel from "./CrimeCardCarousel";
import ReportingSection from "./ReportingSection";
import LoadingComponent from "./Loading";

interface HomeProps {
  isLoggedIn: boolean;
  userEmail: string;
}
 
interface CrimeData {
  id: number;
  typeID: number;
  description: string;
  reportDate: string;
  latitude: number;
  longitude: number;
}

const Home: React.FC<HomeProps> = ({ isLoggedIn, userEmail }) => {
  const [crimeData, setCrimeData] = useState<CrimeData[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Function to fetch crime reports from the API
    const fetchCrimeReports = async () => {
      try {
        const response = await fetch("https://localhost:5190/api/CrimeReport");
        if (response.ok) {
          const data = await response.json();
          setCrimeData(data);
        } else {
          alert("Failed to fetch crime reports.");
        }
      } catch (error) {
        console.error("Error:", error);
        alert("An error occurred. Please try again later.");
      } finally {
        setLoading(false); // Move setLoading(false) here to set it after data is fetched
      }
    };

    // Call the fetchCrimeReports function
    fetchCrimeReports();
  }, []);

  return (
    <>
      {loading ? (
        <LoadingComponent />
      ) : (
        <CrimeCardCarousel key={crimeData.length} crimeData={crimeData} />
      )}
      {isLoggedIn && <ReportingSection userEmail={userEmail} />}
    </>
  );
};

export default Home;
