import React from "react";
import { NavLink } from "react-router-dom";

import logoImage from "../VimbaLogo_resized.svg"; // Image Path

interface HeaderProps {
  isLoggedIn: boolean;
  onLogout: () => void; // Add the onLogout prop
}

const Header: React.FC<HeaderProps> = ({ isLoggedIn, onLogout }) => {
  const handleLogout = () => {
    // Call the onLogout function passed from the parent component
    onLogout();
  };

  return (
    <header>
      <nav>
        <ul>
          <li>
            <NavLink to="/home">
              <i className="fas fa-home"></i> Home
            </NavLink>
          </li>
          {isLoggedIn && (
            <li>
              <NavLink to="/UserEdit">
                <i className="fas fa-user"></i> User
              </NavLink>
            </li>
          )}
          {isLoggedIn && (
            <li>
              <NavLink to="#">
                <i className="fas fa-chart-bar"></i> Statistics
              </NavLink>
            </li>
          )}
          {isLoggedIn ? (
            <li>
              {/* Change the NavLink to a button */}
              <button onClick={handleLogout}>
                <NavLink to="/home">
                <i className="fas fa-sign-out-alt"></i> Logout
                </NavLink>
              </button>
            </li>
          ) :
           (
            <>
              <li>
                <NavLink to="/login">
                  <i className="fas fa-sign-in-alt"></i> Login
                </NavLink>
              </li>
              <li>
                <NavLink to="/signup">
                  <i className="fas fa-user-plus"></i> Sign Up
                </NavLink>
              </li>
            </>
          )}
          <li className="logo-container">
            <img
              src={logoImage}
              alt="Logo"
              className="logo"
              style={{ width: "60px" }}
            />
          </li>
        </ul>
      </nav>
    </header>
  );
};

export default Header;
