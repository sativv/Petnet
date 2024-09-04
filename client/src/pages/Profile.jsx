import { useState, useEffect, useContext, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { userContext } from "../App";
import profile1 from "../profile-images/profile1.jpg";
import badge from "../profile-images/verified-badge.png";
import pen from "../profile-images/pen.png";
import star from "../profile-images/star.png"; // Samma stjärnbild för både fyllda och tomma stjärnor

function Profile() {
  const { currentUser, setCurrentUser } = useContext(userContext);
  const [isEditing, setIsEditing] = useState(false);
  const [aboutMe, setAboutMe] = useState(currentUser?.aboutMe || "");
  const [organizationNumber, setOrganizationNumber] = useState(currentUser?.organizationNumber || "");
  const [organizationName, setOrganizationName] = useState(currentUser?.organizationName || "");
  const [buisnessContact, setBuisnessContact] = useState(currentUser?.buisnessContact || "");
  const [adress, setAdress] = useState(currentUser?.adress || "");
  const [postcode, setPostcode] = useState(currentUser?.postcode || "");
  const [city, setCity] = useState(currentUser?.city || "");
  const [reviews, setReviews] = useState([]);
  const reviewsRef = useRef(null);
  const nav = useNavigate();

  useEffect(() => {
    if (currentUser) {
      fetch(`http://localhost:5054/Review/user/${currentUser.id}/reviews`)
        .then((response) => {
          if (!response.ok) {
            throw new Error("Network response was not ok");
          }
          return response.json();
        })
        .then((data) => setReviews(data))
        .catch((error) => console.error("Error fetching reviews:", error));
    }
  }, [currentUser]);

  const handleEditClick = () => {
    setIsEditing(true);
  };

  const handleSaveClick = async () => {
    try {
      const response = await fetch("http://localhost:5054/api/Account/me/about", {
        method: "PATCH",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          aboutMe,
          organizationNumber,
          organizationName,
          buisnessContact,
          adress,
          postcode: parseInt(postcode, 10),
          city,
        }),
      });

      if (response.ok) {
        setCurrentUser((prevUser) => ({
          ...prevUser,
          aboutMe,
          organizationNumber,
          organizationName,
          buisnessContact,
          adress,
          postcode: parseInt(postcode, 10),
          city,
        }));
        setIsEditing(false);
      } else {
        console.error("Failed to update user information");
      }
    } catch (error) {
      console.error("Error during update:", error);
    }
  };

  // Funktion för att beräkna medelvärdet och avrunda till heltal
  const calculateAverageRating = () => {
    if (reviews.length === 0) return 0; // Om inga recensioner finns, returnera 0
    const totalRating = reviews.reduce((sum, review) => sum + review.rating, 0);
    const average = totalRating / reviews.length;
    return Math.round(average); // Avrunda till närmaste heltal
  };

  // Funktion för att generera stjärnor baserat på betyg
  const renderStars = (rating) => {
    return Array.from({ length: 5 }, (_, index) => (
      <img
        key={index}
        src={star}
        alt="star"
        className={`star-img ${index < rating ? "filled" : "empty"}`}
      />
    ));
  };

  const handleStarClick = () => {
    if (reviewsRef.current) {
      reviewsRef.current.scrollIntoView({ behavior: "smooth" });
    }
  };

  if (!currentUser) {
    nav("/login");
    return null;
  }

  const averageRating = calculateAverageRating(); // Använd funktionen för att få det avrundade medelvärdet

  return (
    <div className="profile-wrapper">
      <div className="profile-header-wrapper">
        <img src={pen} alt="pen-img" className="pen-img" onClick={handleEditClick} />
        <h1>Min profil</h1>
        <p>Här kan du se dina recensioner och redigera dina uppgifter</p>
      </div>

      <div className="profile-introduction-wrapper">
        <img src={profile1} alt="profile1" className="profile-img" />
        <h2>{currentUser.email}</h2>
        
        {(currentUser.isVerified || currentUser.isPrivateSeller) && (
          <div>
            {currentUser.isVerified && (
              <div className="verified-badge-container">
                <h3>Verifierad</h3>
                <img src={badge} alt="badge" className="badge-img" />
              </div>
            )}
            <div className="review-counter">
              <span>{reviews.length} recensioner</span>
            </div>
            <div className="rating-container" onClick={handleStarClick}>
              {renderStars(averageRating)} {/* Visa stjärnor baserat på medelvärdet */}
            </div>
            <div className="average-rating">
              <h3>Genomsnittligt betyg: {averageRating}</h3>
            </div>
          </div>
        )}
      </div>

      <div className="profile-aboutme-wrapper">
        <h2>Om mig</h2>
        {isEditing ? (
          <div className="edit-mode">
            <textarea
              value={aboutMe}
              onChange={(e) => setAboutMe(e.target.value)}
              rows="4"
              cols="50"
            />
            <div className="edit-fields-wrapper">
              <h3>Uppfödaruppgifter</h3>
              <label>
                Organisationsnummer:
                <input
                  type="text"
                  value={organizationNumber}
                  onChange={(e) => setOrganizationNumber(e.target.value)}
                />
              </label>
              <label>
                Organisationsnamn:
                <input
                  type="text"
                  value={organizationName}
                  onChange={(e) => setOrganizationName(e.target.value)}
                />
              </label>
              <label>
                Affärskontakt:
                <input
                  type="text"
                  value={buisnessContact}
                  onChange={(e) => setBuisnessContact(e.target.value)}
                />
              </label>
              <label>
                Adress:
                <input
                  type="text"
                  value={adress}
                  onChange={(e) => setAdress(e.target.value)}
                />
              </label>
              <label>
                Postnummer:
                <input
                  type="number"
                  value={postcode}
                  onChange={(e) => setPostcode(e.target.value)}
                />
              </label>
              <label>
                Stad:
                <input
                  type="text"
                  value={city}
                  onChange={(e) => setCity(e.target.value)}
                />
              </label>
              <div className="edit-buttons">
                <button onClick={() => setIsEditing(false)}>Avbryt</button>
                <button onClick={handleSaveClick}>Spara</button>
              </div>
            </div>
          </div>
        ) : (
          <p>{aboutMe || "Ingen information tillgänglig."}</p>
        )}
      </div>

      <div className="profile-details-wrapper">
        {currentUser.quizResult && (
          <div>
            <h3>Quiz Resultat</h3>
            <p>{currentUser.quizResult}</p>
          </div>
        )}

        {currentUser.organizationNumber && (
          <div>
            <h3>Uppfödaruppgifter</h3>
            <p>Organisationsnummer: {currentUser.organizationNumber}</p>
            {currentUser.organizationName && (
              <p>Organisationsnamn: {currentUser.organizationName}</p>
            )}
            {currentUser.buisnessContact && (
              <p>Affärskontakt: {currentUser.buisnessContact}</p>
            )}
            {currentUser.adress && (
              <p>Adress: {currentUser.adress}</p>
            )}
            {currentUser.postcode && (
              <p>Postnummer: {currentUser.postcode}</p>
            )}
            {currentUser.city && (
              <p>Stad: {currentUser.city}</p>
            )}
          </div>
        )}
      </div>

      <div className="profile-reviews-wrapper" ref={reviewsRef}>
        <h2>Recensioner</h2>
        {reviews.length > 0 ? (
          <ul>
            {reviews.map((review) => (
              <li key={review.id}>
                <p>Betyg: {review.rating}</p>
                <p>{review.comment}</p>
              </li>
            ))}
          </ul>
        ) : (
          <p>Inga recensioner ännu.</p>
        )}
      </div>
    </div>
  );
}

export default Profile;
