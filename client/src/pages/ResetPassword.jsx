import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

function ResetPassword() {
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [message, setMessage] = useState("");

  const query = new URLSearchParams(useLocation().search);
  const token = decodeURIComponent(query.get("token"));
  const email = query.get("email");

  const navigate = useNavigate();

  const passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$/;

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!passwordRegex.test(password)) {
      alert(
        "Password must be at least 6 characters long and contain at least one number, one uppercase letter, and one lowercase letter."
      );
      return;
    }

    if (password !== confirmPassword) {
      alert(
        "Lösenordet och det upprepade lösenordet matchar inte, försök igen!"
      );
      return;
    }

    fetch("https://localhost:7072/api/Account/reset-password", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        password: password,
        confirmPassword: confirmPassword,
        email: email,
        token: token,
      }),
    })
      .then((response) => {
        if (!response.ok) {
          return response.json().then((data) => {
            throw new Error(data.message || "Something went wrong.");
          });
        }
        return response.json();
      })
      .then((data) => {
        setMessage(
          "Password has been successfully reset. You can now log in with your new password."
        );
        setTimeout(() => {
          navigate("/login"); // Navigera till login-sidan efter 2 sekunder
        }, 2000);
      })
      .catch((error) => {
        console.error("Error:", error);
        setMessage(
          error.message ||
            "An unexpected error occurred. Please try again later."
        );
      });
  };

  return (
    <div className="reset-password-container">
      <h2>Reset Password</h2>
      <form onSubmit={handleSubmit}>
        <div className="input-group">
          <label>New Password:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <div className="input-group">
          <label>Confirm Password:</label>
          <input
            type="password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Reset Password</button>
      </form>
      {message && <p>{message}</p>}
    </div>
  );
}

export default ResetPassword;
