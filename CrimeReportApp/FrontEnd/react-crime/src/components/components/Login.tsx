import React, { useState, ChangeEvent, FormEvent } from "react";
import LoadingComponent from "./Loading";
import { NavLink, useNavigate } from "react-router-dom";

interface LoginProps {
  updateLoggedInState: (loggedIn: boolean) => void;
  updateEmailState: (userEmail: string) => void;
} 

const Login: React.FC<LoginProps> = ({
  updateLoggedInState,
  updateEmailState,
}) => {
  const [loading, setLoading] = useState(false);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setLoading(true);

    const formData = new FormData();
    formData.append("email", email);
    formData.append("password", password);

    try {
      const response = await fetch(
        "https://localhost:5190/api/User/login/loginByEmail",
        {
          method: "POST",
          body: formData,
        }
      );

      if (response.ok) {
        // Successful login
        updateLoggedInState(true);
        updateEmailState(email);

        // Update URL and navigate to the home page
        navigate("/home");
      } else {
        // Failed login
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
    <div className="Login_Container_Center">
      {loading && <LoadingComponent/>}
      <div className="Login_Border">
        <form onSubmit={handleLogin}>
          <h1>Log In</h1>
          <div className="Login_Users">
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
          <div className="Login_Users">
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
          <div className="Login_Users">
            <button type="submit">Log In</button>
            <NavLink to="/signup" className="sign-up-link">
              Not Registered? Sign Up Here
            </NavLink>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;