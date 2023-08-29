import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from "./components/Header";
import SignUp from "./components/SignUp";
import Home from "./components/Home";
import Login from "./components/Login"; // Import the Login component
import Footer from "./components/Footer";
import UserProfile from "./components/userProfile";
import Statistics from "components/Statistics";
import "./App.css";

const App: React.FC = () => {
  const [isLoggedIn, setLoggedIn] = React.useState(false);
  const [userEmail, setEmail] = React.useState("");
  // Function to update the isLoggedIn state
  const updateLoggedInState = (loggedIn: boolean) => {
    setLoggedIn(loggedIn);
  };
  const updateEmailState = (userEmail: string) => {
    setEmail(userEmail);
  };

  return (
    <BrowserRouter>
      <Header isLoggedIn={isLoggedIn} />
      <Routes>
        <Route path="/signup" element={<SignUp />} />
        <Route
          index
          path="/home"
          element={<Home isLoggedIn={isLoggedIn} userEmail={userEmail} />}
        />
        <Route
          path="/login"
          element={
            <Login
              updateLoggedInState={updateLoggedInState}
              updateEmailState={updateEmailState}
            />
          }
        />
        <Route
        path="/UserProfile"
        element={
          <UserProfile isLoggedIn={isLoggedIn} username={userEmail}/>
        }
        /> 
        {/* Define other routes here */}
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default App;
