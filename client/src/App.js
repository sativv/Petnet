import React, { useState, useEffect, createContext } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import "./App.css";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Profile from "./pages/Profile";
import ProtectedRoute from "./components/ProtectedRoute";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import ResetPassword from "./pages/ResetPassword";
import Quiz from "./pages/Quiz";
import AddPost from "./components/AddPost";
import ProfileSearch from "./pages/ProfileSearch";
import PostDetails from "./pages/PostDetails";
import Admin from "./pages/Admin";
import ContactFAQ from "./pages/ContactFAQ";
import BookMarkView from "./components/BookmarkView";

// create user context
export const userContext = createContext();

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  // create function to pass onto login page to set current user
  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch("http://localhost:5054/api/Account/me", {
        method: "GET",
        credentials: "include",
      });
      if (!response.ok) {
        setCurrentUser(null);
        return;
      }

      const userData = await response.json();
      setCurrentUser(userData);
    };

    fetchData();
  }, []);

  return (
    <>
      <userContext.Provider value={{ currentUser, setCurrentUser }}>
        <div className="App">
          <Router>
            <Navbar />
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/questions" element={<ContactFAQ />} />
              <Route
                path="/login"
                element={<Login setIsAuthenticated={setIsAuthenticated} />}
              />
              <Route path="/contact" element={<ContactFAQ />} />
              <Route path="/reset-password" element={<ResetPassword />} />
              <Route path="/register" element={<Register />} />
              <Route path="/profileSearch" element={<ProfileSearch />} />
              <Route path="/post/:postId" element={<PostDetails />} />
              <Route element={<ProtectedRoute />}>
                <Route path="/profile/:id" element={<Profile />} />
                <Route path="/quiz" element={<Quiz />} />
                <Route path="/admin" element={<Admin />} />
              </Route>
              <Route element={<ProtectedRoute />}>
                <Route path="/addpost" element={<AddPost />} />
                <Route path="/bookmarks" element={<BookMarkView />} />
              </Route>
            </Routes>
          </Router>
        </div>
        <Footer />
      </userContext.Provider>
    </>
  );
}

export default App;
