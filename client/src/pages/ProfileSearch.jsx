import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';


const ProfileSearch = () => {
  const [users, setUsers] = useState([]); // Håller alla användare
  const [error, setError] = useState(null); // Håller felmeddelanden

  // Funktion för att hämta alla användare
  const fetchUsers = async () => {
    try {
      const response = await fetch('http://localhost:5054/api/account/all-users');
      if (response.ok) {
        const data = await response.json();
        setUsers(data); // Spara användarna i state
        setError(null); // Rensa tidigare felmeddelanden
      } else {
        setError('Failed to load users.');
      }
    } catch (err) {
      setError('Failed to fetch users. Please try again.');
    }
  };

  // Hämta användarna när komponenten laddas
  useEffect(() => {
    fetchUsers();
  }, []);

  return (
    <div className="profile-search-container">
      <h2>Användarregister</h2>
      {error && <p className="error-message">{error}</p>}
      <ul className="user-list">
        {users.map(user => (
          <li key={user.id} className="user-list-item">
            <Link to={`/profile/${user.id}`} className="user-link">
              <div className="user-info">
                <span className="user-name">{user.userName}</span>
   
              </div>

            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ProfileSearch;
