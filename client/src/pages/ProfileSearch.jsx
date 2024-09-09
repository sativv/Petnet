import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const ProfileSearch = () => {
  const [users, setUsers] = useState([]); 
  const [filteredUsers, setFilteredUsers] = useState([]); 
  const [error, setError] = useState(null); 
  const [showVerified, setShowVerified] = useState(false);

  const fetchUsers = async () => {
    try {
      const response = await fetch('http://localhost:5054/api/account/all-users');
      if (response.ok) {
        const data = await response.json();
        setUsers(data); 
        setFilteredUsers(data); 
        setError(null); 
      } else {
        setError('Failed to load users.');
      }
    } catch (err) {
      setError('Failed to fetch users. Please try again.');
    }
  };

  const filterUsers = () => {
    if (showVerified) {
      setFilteredUsers(users.filter(user => user.isVerified));
    } else {
      setFilteredUsers(users);
    }
  };

  const handleCheckboxChange = (event) => {
    setShowVerified(event.target.checked);
  };

  useEffect(() => {
    fetchUsers();
  }, []);


  useEffect(() => {
    filterUsers();
  }, [users, showVerified]);

  return (
    <div className="profile-search-container">
      <h2>Användarregister</h2>
      {error && <p className="error-message">{error}</p>}
      <div className="filter-checkbox">
        <label>
          <input
            type="checkbox"
            checked={showVerified}
            onChange={handleCheckboxChange}
          />
          Visa endast verifierade uppfödare 
        </label>
      </div>
      <ul className="user-list">
        {filteredUsers.map(user => (
          <li key={user.id} className="user-list-item">
            <Link to={`/profile/${user.id}`} className="user-link">
              <div className="user-info">
                <span className="user-name">{user.userName}</span>
                {user.isVerified && <span className="verified-badge">Verifierad</span>}
              </div>
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ProfileSearch;
