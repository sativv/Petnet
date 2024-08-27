import React, { useState } from "react";
import "../App.css";

function Navbar() {
  const [isToggled, Toggle] = useState(false);

  const toggleBurger = () => {
    Toggle(!isToggled);
  };

  return (
    <nav className="navbarContainer">
      <div className="navbarBrand">
        <img className="navLogo" src="/images/Logo.png" alt="" />
        <h2>Petnet</h2>
      </div>

      <div className={`navbarMenu ${isToggled ? "active" : ""}`}>
        <a href="/">Hemsida</a>
        {/* Lägg till länkar till nya sidor!  */}
        <a href="/addpost">Ny annons</a>
        <a href="/Profile">Profil</a>
        <a href="/register">Registrering</a>
        <a href="/login">Logga in</a>
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
