import React, { useState, useEffect, useContext, useRef } from "react";
import { useNavigate, useParams, Link } from "react-router-dom";
import { userContext } from "../App";
import profile1 from "../profile-images/profile1.jpg";
import badge from "../profile-images/verified-badge.png";
import pen from "../profile-images/pen.png";
import star from "../profile-images/star.png";
import "../App.css";
import ReportProfileModal from "../components/ReportProfileModal";

function Profile() {
  const [showReportProfileModal, setReportProfileModal] = useState(false);
  const { currentUser, setCurrentUser } = useContext(userContext);
  const { id: profileId } = useParams();
  const [profile, setProfile] = useState(null);
  const [isEditing, setIsEditing] = useState(false);
  const [aboutMe, setAboutMe] = useState("");
  const [organizationNumber, setOrganizationNumber] = useState("");
  const [organizationName, setOrganizationName] = useState("");
  const [buisnessContact, setBuisnessContact] = useState("");
  const [adress, setAdress] = useState("");
  const [postcode, setPostcode] = useState("");
  const [city, setCity] = useState("");
  const [reviews, setReviews] = useState([]);
  const [newReview, setNewReview] = useState({ rating: 1, content: "" });
  const reviewsRef = useRef(null);
  const editRef = useRef(null); // New ref for the edit section
  const nav = useNavigate();

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const response = await fetch(
          `http://localhost:5054/api/Account/user/${profileId}`
        );
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const data = await response.json();
        setProfile(data);

        // Update local state with profile data
        setAboutMe(data.aboutMe || "");
        setOrganizationNumber(data.organizationNumber || "");
        setOrganizationName(data.organizationName || "");
        setBuisnessContact(data.buisnessContact || "");
        setAdress(data.adress || "");
        setPostcode(data.postcode || "");
        setCity(data.city || "");

        // Fetch reviews
        const reviewResponse = await fetch(
          `http://localhost:5054/Review/user/${profileId}/reviews`
        );
        if (reviewResponse.ok) {
          const reviewData = await reviewResponse.json();
          setReviews(reviewData);
        } else {
          console.error("Failed to fetch reviews");
        }
      } catch (error) {
        console.error("Error fetching profile:", error);
        nav("/login");
      }
    };

    fetchProfile();
  }, [profileId, nav]);

  const handleEditClick = () => {
    setIsEditing(true);
    if (editRef.current) {
      editRef.current.scrollIntoView({ behavior: "smooth" });
    }
  };

  const handleSaveClick = async () => {
    try {
      const response = await fetch(
        "http://localhost:5054/api/Account/me/about",
        {
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
        }
      );

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

  const calculateAverageRating = () => {
    if (reviews.length === 0) return 0;
    const totalRating = reviews.reduce((sum, review) => sum + review.rating, 0);
    return Math.round(totalRating / reviews.length);
  };

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

  const handleReviewChange = (e) => {
    const { name, value } = e.target;
    setNewReview((prev) => ({
      ...prev,
      [name]: name === "rating" ? parseInt(value, 10) : value,
    }));
  };

  const handleAddReview = async () => {
    if (newReview.rating < 1 || newReview.rating > 5) {
      alert("Rating must be between 1 and 5.");
      return;
    }

    try {
      const response = await fetch("http://localhost:5054/review/AddReview", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          content: newReview.comment,
          rating: newReview.rating,
          reviewerId: currentUser.id,
          reviewedSellerId: profileId,
        }),
      });

      if (response.ok) {
        const addedReview = await response.json();
        setReviews((prevReviews) => [...prevReviews, addedReview]);
        setNewReview({ rating: 1, comment: "" });
      } else {
        const errorText = await response.text();
        console.error(
          "Failed to add review:",
          response.status,
          response.statusText,
          errorText
        );
      }
    } catch (error) {
      console.error("Error adding review:", error);
    }
  };

  if (!currentUser) {
    nav("/login");
    return null;
  }

  const averageRating = calculateAverageRating();

  function CloseModal() {
    setReportProfileModal(false);
  }

  return (
    <>
      <div className="profile-wrapper">
        <div className="profile-header-wrapper">
          {profile?.id === currentUser.id ? (
            <img
              src={pen}
              alt="pen-img"
              className="pen-img"
              onClick={handleEditClick}
            />
          ) : (
            <Link
              className="report-profile-link"
              onClick={() => setReportProfileModal(true)}
            >
              Anmäl profil
            </Link>
          )}

          <h1>
            {profile?.id === currentUser.id ? "Min profil" : "Användarprofil"}
          </h1>

          <div className="profile-introduction-wrapper">
            <div className="profile-img-and-username">
              <img src={profile1} alt="profile1" className="profile-img" />
              <h2 className="username-profile">{profile?.email}</h2>
            </div>

            <div className="profile-introduction-wrapper">
              <div className="profile-img-and-username">
                <img src={profile1} alt="profile1" className="profile-img" />
                <h2>{profile?.email}</h2>
              </div>
              {(profile?.isVerified || profile?.isPrivateSeller) && (
                <div>
                  {profile?.isVerified && (
                    <div className="verified-badge-container">
                      <h3>Verifierad</h3>
                      <img src={badge} alt="badge" className="badge-img" />
                    </div>
                  )}
                  <div className="average-rating">
                    <h3>Genomsnittligt betyg: {averageRating}</h3>
                  </div>
                  <div className="rating-container" onClick={handleStarClick}>
                    {renderStars(averageRating)}
                  </div>
                  <div className="review-counter">
                    <span>Baserat på: {reviews.length} recensioner</span>
                  </div>
                </div>
              )}
            </div>

            <div className="profile-aboutme-wrapper" ref={editRef}>
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
                      <button onClick={() => setIsEditing(false)}>
                        Avbryt
                      </button>
                      <button onClick={handleSaveClick}>Spara</button>
                    </div>
                  </div>
                </div>
              ) : (
                <div>
                  <p>{aboutMe || "Ingen information tillgänglig."}</p>
                  {profile?.organizationNumber && (
                    <div>
                      <h3>Organisationsnummer:</h3>
                      <p>{profile.organizationNumber}</p>
                    </div>
                  )}
                  {profile?.organizationName && (
                    <div>
                      <h3>Organisationsnamn:</h3>
                      <p>{profile.organizationName}</p>
                    </div>
                  )}
                  {profile?.buisnessContact && (
                    <div>
                      <h3>Affärskontakt:</h3>
                      <p>{profile.buisnessContact}</p>
                    </div>
                  )}
                  {profile?.adress && (
                    <div>
                      <h3>Adress:</h3>
                      <p>{profile.adress}</p>
                    </div>
                  )}
                  {profile?.postcode && (
                    <div>
                      <h3>Postnummer:</h3>
                      <p>{profile.postcode}</p>
                    </div>
                  )}
                  {profile?.city && (
                    <div>
                      <h3>Stad:</h3>
                      <p>{profile.city}</p>
                    </div>
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
                      <p>
                        <strong>Betyg:</strong> {review.rating}
                      </p>
                      <p>
                        <strong>Kommentar:</strong> {review.content}
                      </p>
                    </li>
                  ))}
                </ul>
              ) : (
                <p>Inga recensioner.</p>
              )}

              {profile?.id !== currentUser.id && (
                <div className="add-review-form">
                  <h3>Lägg till en recension</h3>
                  <label>
                    Betyg:
                    <select
                      name="rating"
                      value={newReview.rating}
                      onChange={handleReviewChange}
                    >
                      {Array.from({ length: 5 }, (_, index) => (
                        <option key={index + 1} value={index + 1}>
                          {index + 1}
                        </option>
                      ))}
                    </select>
                  </label>
                  <label>
                    Kommentar:
                    <textarea
                      name="comment"
                      value={newReview.comment}
                      onChange={handleReviewChange}
                      rows="4"
                      cols="50"
                    />
                  </label>
                  <button onClick={handleAddReview}>Skicka Recension</button>
                </div>
              )}
            </div>
            {showReportProfileModal ? (
              <ReportProfileModal
                currentUserId={currentUser.id}
                userProfileId={profile.id}
                closeModal={CloseModal}
              />
            ) : null}
          </div>
        </div>
      </div>
    </>
  );
}

export default Profile;
