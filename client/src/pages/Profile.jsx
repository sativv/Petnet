import { useState, useEffect, useContext, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { userContext } from "../App";
import profile1 from "../profile-images/profile1.jpg";
import badge from "../profile-images/verified-badge.png";
import pen from "../profile-images/pen.png";
import star from "../profile-images/star.png";

function Profile() {
  const { currentUser, setCurrentUser } = useContext(userContext);
  const [isEditing, setIsEditing] = useState(false);
  const [aboutMe, setAboutMe] = useState(currentUser?.aboutMe || "");
  const [reviews, setReviews] = useState([]);
  const reviewsRef = useRef(null); // Referens till recensionerna
  const nav = useNavigate();

  useEffect(() => {
    if (currentUser) {
      fetch(`http://localhost:5054/api/Account/${currentUser.id}/reviewsreceived`)
        .then((response) => response.json())
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
        body: JSON.stringify({ aboutMe }),
      });

      if (response.ok) {
        setCurrentUser((prevUser) => ({ ...prevUser, aboutMe }));
        setIsEditing(false); // Avsluta redigeringsläget
      } else {
        console.error("Failed to update About Me");
      }
    } catch (error) {
      console.error("Error during update:", error);
    }
  };

  const handleStarClick = () => {
    if (reviewsRef.current) {
      reviewsRef.current.scrollIntoView({ behavior: "smooth" });
    }
  };

  if (!currentUser) {
    nav("/login"); // Om ingen användare är inloggad, navigera till inloggningssidan
    return null;
  }

  return (
    <div className="profile-wrapper">
      <div className="profile-header-wrapper">
        <h1>Min profil</h1>
        <img src={pen} alt="pen-img" className="pen-img" onClick={handleEditClick} />
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
           
              <img src={star} alt="star" className="star-img" />
              <img src={star} alt="star" className="star-img" />
              <img src={star} alt="star" className="star-img" />
              <img src={star} alt="star" className="star-img" />
              <img src={star} alt="star" className="star-img" />
            </div>
          </div>
        )}
      </div>

      <div className="profile-aboutme-wrapper">
        <h2>Om mig</h2>
        {isEditing ? (
          <div>
            <textarea
              value={aboutMe}
              onChange={(e) => setAboutMe(e.target.value)}
              rows="4"
              cols="50"
            />
            <button onClick={() => setIsEditing(false)}>Avbryt</button>
            <button onClick={handleSaveClick}>Spara</button>
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

      <div className="reviews-container" ref={reviewsRef}>
        <h1>Recensioner</h1>
        <div className="review-form">
          <h2>Skriv en recension</h2>
          <form id="reviewForm">
            <textarea id="reviewText" placeholder="Skriv din recension här..." required></textarea>
            <button className="add-review-btn" type="submit">Skicka recension</button>
          </form>
        </div>
        <div className="reviews-list">
          {reviews.length > 0 ? (
            reviews.map((review) => (
              <div key={review.id} className="review-item">
                <div className="review-header">
                  <h3>{review.authorName}</h3>
                  <span className="review-date">{new Date(review.date).toLocaleDateString()}</span>
                </div>
                <p className="review-text">{review.text}</p>
              </div>
            ))
          ) : (
            <p>Inga recensioner ännu.</p>
          )}
        </div>
      </div>
    </div>
  );
}

export default Profile;


