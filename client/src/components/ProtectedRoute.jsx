import React, { useContext, useEffect, useState } from "react";
import { Navigate, Outlet } from "react-router-dom";
import { userContext } from "../App";

const ProtectedRoute = () => {
  const { currentUser, setCurrentUser } = useContext(userContext);
  const [loading, setLoading] = useState(true); // Loading state to see whether the fetch is complete or not

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5054/api/Account/me", {
          method: "GET",
          credentials: "include",
        });

        if (response.ok) {
          const userData = await response.json();
          setCurrentUser(userData);
        } else {
          setCurrentUser(null);
        }
      } catch (error) {
        console.error("Error fetching user data:", error);
        setCurrentUser(null);
      } finally {
        setLoading(false); // changes setLoading to false after the fetch is complete
      }
    };

    fetchData();
  }, [setCurrentUser]);

  if (loading) {
    // shows a small loading indicator while waiting for the fetch to complete
    return <div>Loading...</div>;
  }

  // After loading, run the return code
  return currentUser !== null ? <Outlet /> : <Navigate to="/login" />;
};

export default ProtectedRoute;
