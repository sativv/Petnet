import { useState, useEffect, useContext } from "react";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { userContext } from "../App";
import "../App.css"


//TODO: Add forgotten password link

function Login() {
  const { currentUser, setCurrentUser } = useContext(userContext);
  const nav = useNavigate();

  const [formData, setFormData] = useState({
    username: "",
    password: "",
  });

  const getInfo = async () => {
    try {
      const response = await fetch("http://localhost:5054/manage/info", {
        method: "GET",
        credentials: "include",
      }).then((res) => res.json().then((json) => console.log(json)));
    } catch {
      <></>;
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    let payload = {
      email: formData.username,
      password: formData.password,
    };

    console.log(JSON.stringify(payload));
    try {
      const response = await fetch(
        "http://localhost:5054/login?useCookies=true",
        {
          method: "POST",
          credentials: "include",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(payload),
        }
      );

      if (response.ok) {
      }
    } catch (error) {
      console.error("Error during fetch:", error);
    }

    const response = await fetch("http://localhost:5054/api/Account/me", {
      method: "GET",
      credentials: "include",
    });
    const userData = await response.json();
    console.log(userData);
    setCurrentUser(userData);
    nav("/profile");
  };

  return (
    <div className="login-wrapper">
      <form className="loginForm" onSubmit={handleSubmit}>

        <h1>Logga in</h1>
        
        <div>
          <div className="login-text-wrapper">
            <label>Användarnamn</label>
          </div>
        <input
          type="text"
          name="username"
          placeholder="Email"
          className="login-input"
          value={FormData.username}
          onChange={(e) => {
            e.preventDefault();
            setFormData({
              username: e.target.value,
              password: formData.password,
            });
          }}
          required
        />
        </div>
        <div>
          <div className="login-text-wrapper">
        <label>Lösenord:</label>
        <Link>Glömt lösenord?</Link>
          </div>
        <input
          type="password"
          name="password"
          className="login-input"
          placeholder="Password"
          value={FormData.password}
          onChange={(e) => {
            e.preventDefault();
            setFormData({
              username: formData.username,
              password: e.target.value,
            });
          }}
          required
         />
        </div>
        <input type="submit" value="Logga in" className="login-button" />
        <Link to={"/register"} className="returnLink">
        Är du inte registrerad? Klicka <strong>här</strong>!
      </Link>
      </form>

      
    </div>
  );
}

export default Login;
