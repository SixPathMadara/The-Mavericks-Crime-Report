import React, { useState } from "react";
import LoadingComponent from "./Loading";

interface ReportingSectionProps {
  userEmail: string;
}

const ReportingSection: React.FC<ReportingSectionProps> = ({ userEmail }) => {
  const [crimeType, setCrimeType] = useState("");
  const [description, setDescription] = useState("");
  const [latitude, setLatitude] = useState("");
  const [longitude, setLongitude] = useState("");
  //const [address, setAddress] = useState("");
  const [date, setDate] = useState(""); // You can initialize it with the current date if needed
  const [loading, setLoading] = useState(false);

  // Function to fetch user ID from the API using email
  const fetchUserID = async (email: string) => {
    try {
      const response = await fetch(
        `https://localhost:5190/api/User/email/${email}`
      );
      if (response.ok) {
        const data = await response.json();
        return data.id; // Assuming the API returns the user ID in the 'id' field
      } else {
        alert("Failed to fetch user ID.");
        return null;
      }
    } catch (error) {
      console.error("Error:", error);
      alert("An error occurred while fetching user ID.");
      return null;
    }
  };

  
  const getLocation = () => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          setLatitude(position.coords.latitude.toString());
          setLongitude(position.coords.longitude.toString());
        },
        (error) => {
          console.error("Error getting location:", error);
          alert("Failed to fetch your location automatically.");
        }
      );
    } else {
      alert("Geolocation is not supported by your browser.");
    }
  };

  const handleLocationInput = async () => {
    const manualAddress = prompt("Enter your location address:");
    
    if (manualAddress) {
      try {
        const apiKey = 'YOUR_GOOGLE_MAPS_API_KEY';
        const geocodingUrl = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(manualAddress)}&key=${apiKey}`;
        
        const response = await fetch(geocodingUrl);
        const data = await response.json();
        
        if (data.status === 'OK' && data.results.length > 0) {
          const location = data.results[0].geometry.location;
          
          setLatitude(location.lat.toString());
          setLongitude(location.lng.toString());
          //setAddress(manualAddress);
        } else {
          alert('Geocoding failed. Please check the address and try again.');
        }
      } catch (error) {
        console.error('Geocoding error:', error);
        alert('An error occurred during geocoding. Please try again later.');
      }
    }
  };
  

  const handleFormSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setLoading(true);
    // Fetch the user ID
    const userID = await fetchUserID(userEmail);

    if (userID === null) {
      // Unable to fetch user ID, handle the error
      return;
    }

    // Prepare the data to be sent to the API
    const crimeReportData = {
      id: -1,
      userID,
      typeID: parseInt(crimeType),
      description,
      reportDate: date, // Format the date as needed before sending to the API
      latitude: parseFloat(latitude),
      longtitude: parseFloat(longitude),
      //address: parseFloat(address)
      //address
    };

    // Make the API call to submit the crime report
    // You can use fetch or any other library to make the API call
    // For now, just print the data to the console
    console.log(crimeReportData);

    try {
      const response = await fetch("https://localhost:7116/api/CrimeReport", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(crimeReportData),
      });

      if (response.ok) {
        // Crime report submitted successfully
        alert("Crime report submitted successfully!");
      } else {
        // Crime report submission failed
        const errorMessage = await response.text();
        alert(errorMessage);
      }
    } catch (error) {
      // Handle any errors that occurred during the API call
      console.error("Error:", error);
      alert(
        "An error occurred while submitting the crime report. Please try again later."
      );
    } finally {
      setLoading(false);
    }

    // Clear the form fields after submission
    setCrimeType("");
    setDescription("");
    setLatitude("");
    setLongitude("");
    //setAddress("");
    setDate("");
  };

  return (
    <div className="reporting-section">
      {loading && <LoadingComponent />}
      <h3 className="reporting-title">Report a Crime</h3>
      <form className="reporting-form" onSubmit={handleFormSubmit}>
        <select
          className="reporting-input"
          value={crimeType}
          onChange={(e) => setCrimeType(e.target.value)}
          required
        >
          <option value="">Select Crime Type</option>
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
          {/* Add other crime types as needed */}
        </select>
        <textarea
          className="reporting-textarea"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder="Description"
          required
        >

        </textarea>


        <input
          type="text"
          className="reporting-input"
          value={latitude}
          onChange={(e) => setLatitude(e.target.value)}
          placeholder="Latitude"
          required
        />

        <input
          type="text"
          className="reporting-input"
          value={longitude}
          onChange={(e) => setLongitude(e.target.value)}
          placeholder="Longitude"
          required
        />

        <input
          type="button"
          className="reporting-button"
          value="Get My Location"
          onClick={getLocation}
        />
        <input
          type="button"
          className="reporting-button"
          value="Enter Location Manually"
          onClick={handleLocationInput}
        />

        <input
          type="date"
          className="reporting-input"
          value={date}
          onChange={(e) => setDate(e.target.value)}
          required
        />

        {/* Add file input for attaching files (optional) */}
        <button type="submit" className="reporting-button">
          Submit
        </button>

      </form>
    </div>
  );
};

export default ReportingSection;




