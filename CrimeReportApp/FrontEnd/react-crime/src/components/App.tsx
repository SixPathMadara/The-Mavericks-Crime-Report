import React, { useEffect } from "react";
import { BrowserRouter, Route, Routes, useLocation } from "react-router-dom";
import Header from "./components/Header";
import SearchArea from "./components/SearchArea";
import SignUp from "./components/SignUp";
import Home from "./components/Home";
import Login from "./components/Login";
import Footer from "./components/Footer";
import EditUserDetails from "./components/UserEdit";

import "./App.css";
import "./Login.css";
import "./Register.css";
import "./Loading.css";
import "./Footer.css";
import "./SearchArea.css";
import "./Header.css";
import "./ReportingSection.css";
import "./CrimeCard.css";
import "./UserEdit.css";
import "@fortawesome/fontawesome-free/css/all.min.css";

interface ConditionalComponentsWrapperProps {
  children: React.ReactNode;
  isLoggedIn: boolean;
  userEmail: string;
  updateLoggedInState: (loggedIn: boolean) => void;
  updateEmailState: (userEmail: string) => void;
  onLogout: () => void; // Added logout function
}

const ConditionalComponentsWrapper: React.FC<ConditionalComponentsWrapperProps> = ({
  isLoggedIn,
  userEmail,
  updateLoggedInState,
  updateEmailState,
  onLogout,
}) => {
  const location = useLocation();

  const hideComponentsOnRoutes = ["/login", "/signup", "/UserEdit"];
  const shouldHideComponents = hideComponentsOnRoutes.includes(location.pathname);

  return (
    <div className="app-wrapper">
      <Header isLoggedIn={isLoggedIn} onLogout={onLogout} />
      {!shouldHideComponents && location.pathname === "/home" && (
        <div style={{ display: "flex", justifyContent: "center", alignItems: "center", minHeight: "calc(5vh - 200px)" }}>
          <SearchArea />
        </div>
      )}
      <div className="main-content">
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
          <Route path="/UserEdit" element={<EditUserDetails />} />
          {/* Define other routes here */}
        </Routes>
      </div>
      <Footer />
    </div>
  );
};

const App: React.FC = () => {
  const [isLoggedIn, setLoggedIn] = React.useState(false);
  const [userEmail, setEmail] = React.useState("");

  useEffect(() => {
    async function checkLogin() {
      try {
        const response = await fetch("https://localhost:5190/api/User/check");
        if (response.ok) {
          const data = await response.json();
          setEmail(data.loggedInUsername);
          setLoggedIn(true);
        }
      } catch (error) {
        console.error("Error checking login:", error);
      }
    }
    checkLogin();
  }, []);

  const handleLogout = async () => {
    try {
      const response = await fetch("https://localhost:5190/api/User/logout", {
        method: "POST",
      });

      if (response.ok) {
        setEmail("");
        setLoggedIn(false);
      }
    } catch (error) {
      console.error("Error logging out:", error);
    }
  };

  return (
    <BrowserRouter>
      <ConditionalComponentsWrapper
        isLoggedIn={isLoggedIn}
        userEmail={userEmail}
        updateLoggedInState={setLoggedIn}
        updateEmailState={setEmail}
        onLogout={handleLogout}
      >
      </ConditionalComponentsWrapper>
    </BrowserRouter>
  );
};

export default App;
