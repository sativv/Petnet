import { useState } from "react";
import { useNavigate } from "react-router-dom";

function Register() {
  const nav = useNavigate();
  const passwordRegex =
    /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[A-Za-z\d!@#$%^&*(),.?":{}|<>]{6,}$/;

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  // const newUser = {
  //   username: username,
  //   password: password,
  // };

  const handleSubmit = async (event) => {
    event.preventDefault();

    const newUser = {
      email: email,
      password: password,
    };

    if (email.length < 10) {
      alert("Email must be at least 10 characters long");
      return;
    }

    if (!passwordRegex.test(password)) {
      alert(
        "Password must be at least 6 characters long asnd contain at least one number"
      );
      return;
    }

    const response = await fetch("http://localhost:5054/register", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newUser),
    });

    if (!response.ok) {
      // DID NOT WORKING
    }

    alert("Welcome, your account has been created!");
    nav("/login");
  };
  return (
    <div>
      <h2>Registration</h2>

      <form onSubmit={handleSubmit}>
        <label>Email:</label>
        <input
          type="text"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
          className="emailInput"
        />
        <label>Password:</label>
        <input
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
          className="passwordInput"
        />
        <input type="submit" value="Create Account" className="submitBtn" />
      </form>
    </div>
  );
}

export default Register;
