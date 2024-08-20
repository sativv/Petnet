import { useState, useEffect } from "react";
import { Link } from "react-router-dom";

function Login() {
  const [users, setUsers] = useState([]);
  const [formData, setFormData] = useState({
    username: "",
    password: "",
  });

  // useEffect(() => {
  //   fetch("http://localhost:3000/users")
  //     .then((r) => r.json())
  //     .then((userData) => {
  //       setUsers(userData);
  //     });
  // }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    let payload = {
      email: formData.username,
      password: formData.password
    }

    console.log(JSON.stringify(payload))
    try {
        const response = await fetch("http://localhost:5054/login?useCookies=true", {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.error('Error during fetch:', error);
    }
    // if (users.length === 0) {
    //   // User data is still loading
    //   return;
    // }

    // const user = users.find((user) => user.username === formData.username);

    // if (!user) {
    //   // user not found
    //   // show error message
    //   return;
    // }
    // if (user.password !== formData.password) {
    //   // incorrect pssword
    //   // show error message
    //   return;
    // }

    // Login successful
    //navigate to user page / homepage
  };


  return (
    <div>
      <form className="loginForm" onSubmit={handleSubmit}>
        <h1>Log in</h1>
        <label>Username:</label>
        <input
          type="text"
          name="username"
          className="unInput"
          value={FormData.username}
          onChange={(e) => {
            e.preventDefault();
            setFormData({username: e.target.value, password: formData.password})
          }}
          required
        ></input>
        <label>Password:</label>
        <input
          type="password"
          name="password"
          className="pasInput"
          value={FormData.password}
          onChange={(e) => {
            e.preventDefault();
            setFormData({username: formData.username, password: e.target.value})
          }}
          required
        ></input>
        <input type="submit" value="Login" className="loginBtn" />
      </form>

      <Link to={"/register"} className="returnLink">
        Don't have an account? Press here to sign up!
      </Link>
    </div>
  );
}

export default Login;
