import React, { useState } from "react";
import "../App.css";

function ForgetPasswordModal(props) {
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");

  function handleSubmit(e) {
    e.preventDefault();

    fetch(
      "https://localhost:7072/api/Account/forgot-password?email=" +
        encodeURIComponent(email),
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: "",
      }
    )
      .then((response) => {
        if (!response.ok) {
          return response.json().then((data) => {
            throw new Error(data.message || "Something went wrong.");
          });
        }
        return response.json();
      })
      .then((data) => {
        // Om requesten lyckades, visa ett meddelande till användaren
        setMessage(data.message || "Email sent to your email address.");
      })
      .catch((error) => {
        console.error("Error:", error);
        setMessage(
          error.message ||
            "An unexpected error occurred. Please try again later."
        );
      });
  }
  return (
    <>
      <div className="forget-password-modal-outer-container">
        <div className="forget-password-modal">
          <button
            className="forget-password-modal-close-btn"
            onClick={props.closeModal}
          >
            x
          </button>
          <h2> Glömt ditt lösenord? </h2>
          <p>
            Ange e-postadress så skickar vi en länk till dig så att du kan skapa
            ett nytt lösenord.
          </p>
          <form onSubmit={handleSubmit}>
            <div className="email-input-container">
              <label>Email: </label>
              <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
              />
            </div>
            <button type="submit">Skicka</button>
          </form>
          {message && <p>{message}</p>}
        </div>
      </div>
    </>
  );
}

export default ForgetPasswordModal;
