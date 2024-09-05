
import "../App.css";
import React, { useState, useContext } from "react";
import { userContext } from "../App";
import { useNavigate } from "react-router-dom";

function Navbar() {
  const [isToggled, Toggle] = useState(false);
    const { currentUser } = useContext(userContext); // Hämta den inloggade användaren
      const navigate = useNavigate();

  const toggleBurger = () => {
    Toggle(!isToggled);
  };


  const goToProfile = () => {
    if (currentUser) {
      navigate(`/profile/${currentUser.id}`); // Navigera till inloggad användares profil
    } else {
      navigate("/login"); // Om ingen är inloggad, navigera till inloggningssidan
    }
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

        {/* Lägg till länkar till nya sidor!  */}
        <a href="/addpost">Ny annons</a>
        <a href="/profileSearch">Sök profil</a>
        <a href="/register">Registrering</a>
        <a href="/login">Logga in</a>
                  <button onClick={goToProfile}>{currentUser?.email}</button>
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
