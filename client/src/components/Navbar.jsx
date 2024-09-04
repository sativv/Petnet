import React, { useContext, useState } from "react";
import "../App.css";
import { userContext } from "../App";

function Navbar() {
  const [isToggled, Toggle] = useState(false);
  const { currentUser} = useContext(userContext);
  let isAdmin = false;
  const toggleBurger = () => {
    Toggle(!isToggled);
  };

  if(currentUser !== null){
    isAdmin = currentUser.isAdmin;
  }
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
        <a href="/Profile">Profil</a>
        <a href="/register">Registrering</a>
        <a href="/login">Logga in</a>
        {isAdmin ? <a href="/admin">Admin</a> : <></>}
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
