import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faHouse,
  faBurger,
  faCartShopping,
  faUser,
  faEnvelope,
} from "@fortawesome/free-solid-svg-icons";
import { faInstagram, faLinkedin } from "@fortawesome/free-brands-svg-icons";

function Footer() {
  return (
    <div className="footerContainer">
      <div className="footerLeftColumn">
        <h2>Petnet Info</h2>
        <div className="brandDiv">
          <FontAwesomeIcon icon={faEnvelope} className="brandIcon" />

          <h3>Petnet@gmail.com</h3>
        </div>
        <div className="brandDiv">
          <FontAwesomeIcon icon={faInstagram} className="brandIcon" />
          <h3>@Petnet</h3>
        </div>
        <div className="brandDiv">
          <FontAwesomeIcon icon={faLinkedin} className="brandIcon" />
          <h3>PetnetSE</h3>
        </div>
      </div>
      <div className="footerRightColumn">
        <h2>Länkar</h2>
        <h3>Hemsida</h3>
        <h3>Hemsida</h3>
        <h3>Hemsida</h3>
      </div>
    </div>
  );
}

export default Footer;
