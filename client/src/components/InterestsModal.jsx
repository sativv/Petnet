import { useState, useEffect } from "react";
import { Link, useParams } from "react-router-dom";

function InterestsModal({ isOpen, onClose }) {
  const [users, setUsers] = useState([]);
  const [interests, setInterests] = useState([]);
  const { postId } = useParams();
  const [filteredUsers, setFilteredUsers] = useState([]);

  const checkInterests = async () => {
    try {
      const response = await fetch("https://localhost:7072/api/Interest", {
        method: "GET",
        credentials: "include",
      });
      if (response.ok) {
        const recievedInterests = await response.json();
        setInterests(recievedInterests);
      } else {
        console.error("Failed to fetch interests");
      }
    } catch (error) {
      console.error("Error checking interests", error);
    }
  };

  const fetchUsers = async () => {
    try {
      const response = await fetch(
        "http://localhost:5054/api/account/all-users"
      );
      if (response.ok) {
        const data = await response.json();
        setUsers(data);
      } else {
      }
    } catch (err) {}
  };

  const filterUsersByInterests = () => {
    const matchingUsers = users.filter((user) =>
      interests.some(
        (interest) =>
          interest.postId === parseInt(postId) &&
          interest.applicationUserId === user.id
      )
    );
    setFilteredUsers(matchingUsers);
  };

  useEffect(() => {
    if (isOpen) {
      fetchUsers();
      checkInterests();
    }
  }, [isOpen]);

  useEffect(() => {
    if (users.length > 0 && interests.length > 0) {
      filterUsersByInterests();
      console.log(filteredUsers);
    }
  }, [users, interests]);

  if (!isOpen) return null;

  return (
    <div className="intModalContainer">
      <div className="intModal">
        <ul className="user-list">
          {filteredUsers.map((user) => (
            <li key={user.id} className="user-list-item">
              <Link to={`/profile/${user.id}`} className="user-link">
                <div className="user-info">
                  <span className="user-name">{user.userName}</span>
                  {user.isVerified && (
                    <span className="verified-badge">Verifierad</span>
                  )}
                </div>
              </Link>
            </li>
          ))}
        </ul>
        <button className="intCloseBtn" onClick={onClose}>
          Stäng
        </button>
        <div className="intModalContent"></div>
      </div>
    </div>
  );
}

export default InterestsModal;
