import React, { useState, ChangeEvent, FormEvent } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import LoadingComponent from "./Loading";

const SignUp: React.FC = () => {
  //Grab user information
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  //other things
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSignUp = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setLoading(true);

    // Validate form data here (e.g., check if passwords match)
    if (password !== confirmPassword) {
      alert("Passwords do not match.");
      setLoading(false);
      return;
    }

    const formData = new FormData();
    formData.append("name", name);
    formData.append("surname", surname);
    formData.append("username", username);
    formData.append("email", email);
    formData.append("password", password);

    // Log the form data to verify its content
    console.log("Form Data:", Object.fromEntries(formData));

    try {
      // Make a POST request to your backend API's /registerByEmail endpoint
      const response = await fetch(
        "https://localhost:5190/api/User/register/registerByEmail",
        {
          method: "POST",
          body: formData,
        }
      );

      if (response.ok) {
        // Registration successful
        // Redirect the user to a login page or display a success message
        navigate("/login");
      } else {
        // Registration failed
        // Display an error message to the user
        const errorMessage = await response.text();
        alert(errorMessage);
      }
    } catch (error) {
      // Handle any errors that occurred during the API call
      console.error("Error:", error);
      alert("An error occurred. Please try again later.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container_Register">
      {loading && <LoadingComponent />}
      <div className="default_border">
        <form onSubmit={handleSignUp}>
          <h1>Sign Up</h1>
          <div className="users">
            <input
              type="text"
              name="name"
              value={name}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setName(e.target.value)
              }
              required
            />
            <label>Name</label>
          </div>
          <div className="users">
            <input
              type="text"
              name="surname"
              value={surname}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setSurname(e.target.value)
              }
              required
            />
            <label>Surname</label>
          </div>
          <div className="users">
            <input
              type="text"
              name="username"
              value={username}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setUsername(e.target.value)
              }
              required
            />
            <label>UserName</label>
          </div>
          <div className="users">
            <input
              type="text"
              name="email"
              value={email}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setEmail(e.target.value)
              }
              required
            />
            <label>Email</label>
          </div>
          <div className="users">
            <input
              type="password"
              name="password"
              value={password}
              onChange={(e: ChangeEvent<HTMLInputElement>) =>
                setPassword(e.target.value)
              }
              required
            />
            <label>Password</label>
          </div>
          <div className="users">
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

          <div className="users">
            <button type="submit">Sign Up</button>
            {/* Use NavLink instead of anchor tag */}
            <NavLink to="/login" className="sign-up-link">
              Have an account already? Login here.
            </NavLink>
          </div>
        </form>
      </div>
    </div>
  );
};

export default SignUp;
