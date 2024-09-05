import React, { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import "../App.css";
import { userContext } from "../App";

function Navbar() {
  const [isToggled, Toggle] = useState(false);
  const { currentUser } = useContext(userContext);
  const navigate = useNavigate();
  
  // Kontrollera om användaren är admin
  const isAdmin = currentUser?.isAdmin || false;

  // Hantera navigering till användarens profil
  const goToProfile = () => {
    if (currentUser) {
      navigate(`/profile/${currentUser.id}`); // Navigera till inloggad användares profil
    } else {
      navigate("/login"); // Om ingen är inloggad, navigera till inloggningssidan
    }
  };

  // Hantera toggle för burger-menyn
  const toggleBurger = () => {
    Toggle(!isToggled);
  };

  return (
    <nav className="navbarContainer">
      <div>
        <a href="/" className="navbarBrand">
          <img className="navLogo" src="/images/Logo.png" alt="Petnet Logo" />
          <h2>Petnet</h2>
        </a>
      </div>

      <div className={`navbarMenu ${isToggled ? "active" : ""}`}>
        <a href="/">Hemsida</a>
        <a href="/quiz">Quiz</a>
        <a href="/addpost">Ny annons</a>
        <a href="/profileSearch">Sök profil</a>
        <a href="/register">Registrering</a>
        <a href="/login">Logga in</a>
        {currentUser && (
          <button onClick={goToProfile}>Min profil</button>
        )}
        {isAdmin && <a href="/admin">Admin</a>}
      </div>

      <div className="burgerIcon" onClick={toggleBurger}>
        <div className="line1"></div>
        <div className="line2"></div>
        <div className="line3"></div>
      </div>
    </nav>
  );
}

export default Navbar;
