import { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import { userContext } from "../App";
import profile1 from "../profile-images/profile1.jpg";
import pen from "../profile-images/pen.png";
import verifiedBadge from "../profile-images/verified-badge.png"; 

function Profile() {
  const { currentUser, setCurrentUser } = useContext(userContext);
  const [isEditing, setIsEditing] = useState(false);
  const [aboutMe, setAboutMe] = useState(currentUser?.aboutMe || "");
  const nav = useNavigate();

  const handleEditClick = () => {
    setIsEditing(true);
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
        <img src={profile1} alt="profile1" className="profile-img"/>
        <h2>{currentUser.email}</h2>
        {currentUser.IsVerified && (
          <img src={verifiedBadge} alt="verified-badge" className="verified-badge" />
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
            <button onClick={async () => {
              try {
                const response = await fetch("http://localhost:5054/api/Account/updateAboutMe", {
                  method: "POST",
                  credentials: "include",
                  headers: {
                    "Content-Type": "application/json",
                  },
                  body: JSON.stringify({ aboutMe }),
                });

                if (response.ok) {
                  const updatedUser = await response.json();
                  setCurrentUser(updatedUser);
                  setIsEditing(false);
                } else {
                  console.error("Failed to update About Me");
                }
              } catch (error) {
                console.error("Error during update:", error);
              }
            }}>Spara</button>
          </div>
        ) : (
          <p>{aboutMe || "Ingen information tillgänglig."}</p>
        )}
      </div>
     <button onClick={Logout}>Logout</button>
    </div>
  );
}

export default Profile;
