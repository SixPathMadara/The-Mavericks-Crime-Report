import React, { useState, ChangeEvent, FormEvent, useEffect } from "react";
import { NavLink } from "react-router-dom";
import LoadingComponent from "./Loading";

const EditUserDetails: React.FC = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [profilePicture, setProfilePicture] = useState<File | null>(null);
  const [loading, setLoading] = useState(false);

  const [userData, setUserData] = useState<any>(null);

  useEffect(() => {
    async function fetchUserData() {
      try {
        const response = await fetch(
          "https://localhost:5190/api/User/GetLoggedInUserData",
          {
            method: "GET",
            headers: {
              // Add any required headers here
            },
          }
        );

        if (response.ok) 
        {
          const userData = await response.json();
          setUserData(userData);
          setUsername(userData.username);
          setEmail(userData.email);
        } 
        else 
        {
          console.error("Error fetching user data");
        }
      } 
      catch (error) 
      {
        console.error("Error:", error);
      }
    }

    fetchUserData();
  }, []);

  


  const handleUpdateDetails = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setLoading(true);

    if (password !== confirmPassword) {
      alert("Passwords do not match.");
      setLoading(false);
      return;
    }

    const formData = new FormData();
    formData.append("username", username);
    formData.append("email", email);
    formData.append("password", password);
    if (profilePicture) 
    {
      formData.append("profilePicture", profilePicture);
    }

    try {
      const response = await fetch(
        "https://localhost:5190/api/User/updateUser", // Update with the correct API endpoint
        {
          method: "POST",
          body: formData,
        }
      );

      if (response.ok) {
        alert("Details updated successfully!");
      } else {
        const errorMessage = await response.text();
        alert(errorMessage);
      }
    } catch (error) {
      console.error("Error:", error);
      alert("An error occurred. Please try again later.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="EditUser_Container">
      {loading && <LoadingComponent />}
      <div className="Register_Border">
        <div className="ProfilePicture">
          {/* Display circular profile picture icon */}
          <div className="ProfilePictureIcon"><i className="fas fa-user"></i></div>
          <input
            type="file"
            accept="image/*"
            onChange={(e: ChangeEvent<HTMLInputElement>) =>
              setProfilePicture(e.target.files ? e.target.files[0] : null)
            }
          />
        </div>

        {/* Display the user's name and surname in the h1 */}
        <h1>{userData ? `${userData.user.firstName} ${userData.user.lastName}` : "Loading..."}</h1>


        <form onSubmit={handleUpdateDetails}>
          <div className="Register_Users">
            <input
              type="text"
              name="username"
              value={username}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setUsername(e.target.value)
              }
              required
            />
            <label>New Username</label>
          </div>
          <div className="Register_Users">
            <input
              type="text"
              name="email"
              value={email}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setEmail(e.target.value)
              }
              required
            />
            <label>New Email</label>
          </div>
          <div className="Register_Users">
            <input
              type="password"
              name="newPassword"
              value={password}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setPassword(e.target.value)
              }
              required
            />
            <label>New Password</label>
          </div>
          <div className="Register_Users">
            <input
              type="password"
              name="confirmPassword"
              value={confirmPassword}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setConfirmPassword(e.target.value)
              }
              required
            />
            <label>Confirm Password</label>
          </div>

          <div className="Edit_Users">
            <button type="submit">Update Details</button>
            <NavLink to="/home" className="profile-link">
              Go back to profile
            </NavLink>
          </div>
        </form>
      </div>
    </div>
  );
};

export default EditUserDetails;
