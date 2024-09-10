import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faStar, faStar as faRegStar } from "@fortawesome/free-solid-svg-icons";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

function PostDetails() {
  const { postId } = useParams();
  const [post, setPost] = useState(null);
  const [isEditable, setIsEditable] = useState(false);
  const [imageUrl, setImageUrl] = useState("");
  const [isFavorite, setIsFavorite] = useState(false);
  const [currentUserId, setCurrentUserId] = useState(null); // State to hold current user ID

  const nav = useNavigate();

  var datenow = new Date();
  var currentDate = datenow.toISOString().substring(0, 10);

  const unlockEdit = () => {
    setIsEditable(true);
    setImageUrl(post.images[0] || "");
  };

  const checkIfBookmarked = async () => {
    try {
      const response = await fetch(
        "https://localhost:7072/api/Account/me/bookmarks",
        {
          method: "GET",
          credentials: "include",
        }
      );
      if (response.ok) {
        const bookmarks = await response.json();

        const isBookmarked = bookmarks.includes(parseInt(postId));
        setIsFavorite(isBookmarked);
      } else {
        console.error("Failed to fetch bookmarks");
      }
    } catch (error) {
      console.error("Error checking bookmarks:", error);
    }
  };

  const fetchCurrentUser = async () => {
    try {
      const response = await fetch("https://localhost:7072/api/Account/me", {
        method: "GET",
        credentials: "include",
      });
      if (response.ok) {
        const userData = await response.json();
        setCurrentUserId(userData.id); // Save the logged-in user ID
      } else {
        console.error("Failed to fetch current user data");
      }
    } catch (error) {
      console.error("Error fetching user data:", error);
    }
  };

  const toggleFavorite = async () => {
    if (isFavorite) {
      try {
        const response = await fetch(
          `https://localhost:7072/api/Account/RemoveBookmark/${postId}`,
          {
            method: "DELETE",
            credentials: "include",
            headers: {
              "Content-Type": "application/json",
            },
          }
        );
        if (response.ok) {
          setIsFavorite(false);
        } else {
          alert("Failed to remove bookmark.");
        }
      } catch (error) {
        console.error("Error removing bookmark:", error);
      }
    } else {
      try {
        const response = await fetch(
          "https://localhost:7072/api/Account/AddBookmark",
          {
            method: "POST",
            credentials: "include",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(postId),
          }
        );
        if (response.ok) {
          setIsFavorite(true);
        } else {
          alert("Failed to add bookmark.");
        }
      } catch (error) {
        console.error("Error adding bookmark:", error);
      }
    }
  };

  const deletePost = async () => {
    const isConfirmed = window.confirm(
      "Är du säker på att du vill ta bort annonsen?"
    );

    if (isConfirmed) {
      const response = await fetch(
        `https://localhost:7072/api/Post/RemovePost/${post.id}`,
        {
          method: "DELETE",
          credentials: "include",
        }
      );

      if (response.ok) {
        nav("/");
      }
    }
  };

  useEffect(() => {
    const fetchPost = async () => {
      try {
        const response = await fetch(
          `https://localhost:7072/api/Post/SinglePost/${postId}`
        );

        if (!response.ok) {
          throw new Error("Failed to fetch post data");
        }

        const data = await response.json();
        setPost(data);
      } catch (error) {
        console.error(error.message);
      }
    };

    fetchPost();
    checkIfBookmarked();
    fetchCurrentUser(); // Fetch current user info
  }, [postId]);

  const handleSaveChanges = async (e) => {
    e.preventDefault();

    if (
      post.title === "" ||
      post.description === "" ||
      post.animalBreed === "" ||
      post.gender === "" ||
      post.age === "" ||
      post.animalType === "" ||
      post.birthdate === "" ||
      post.earliestAdoption === ""
    ) {
      alert("Alla fält måste vara ifyllda!");
      return;
    }

    const updatedImages = [...post.images];
    updatedImages[0] = imageUrl;

    post.applicationUser = {};

    try {
      const response = await fetch(
        `https://localhost:7072/api/Post/UpdatePost/${post.id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ ...post, images: updatedImages }),
        }
      );

      if (response.ok) {
        setIsEditable(false);
        alert("Annonsen har uppdaterats!");
        window.location.reload();
      } else {
        alert("Något gick fel vid uppdateringen av annonsen.");
      }
    } catch (error) {
      console.error(error.message);
    }
  };

  if (!post) {
    return <div>Loading...</div>;
  }

  return (
    <div className="postCard">
      <div className="postImage">
        <img src={post.images[0]} alt={post.title} />
        <div className="favoriteIcon favoriteDiv" onClick={toggleFavorite}>
          <p>Spara Annons</p>
          <FontAwesomeIcon
            icon={isFavorite ? faStar : faRegStar}
            color={isFavorite ? "gold" : "gray"}
            size="2x"
            className="favIcon"
          />
        </div>
        <a href="/profile/{post.applicationUserId}">{post.applicationUserId}</a>
      </div>
      <div className="postContent">
        <form onSubmit={handleSaveChanges}>
          <div className="postInfo">{/* Your post details inputs here */}</div>
          <div className="postDetails">
            <h1 className="postTitle">
              <input
                type="text"
                value={post.title}
                disabled={!isEditable}
                onChange={(e) => setPost({ ...post, title: e.target.value })}
                className="postInput postTitleInput add-textarea"
              />
            </h1>
            <p className="postDescription">
              <textarea
                value={post.description}
                disabled={!isEditable}
                onChange={(e) =>
                  setPost({ ...post, description: e.target.value })
                }
                className="postInput postDescriptionInput add-textarea"
              />
            </p>

            <button type="button" className="contactButton">
              Ta Kontakt
            </button>
            {!isEditable && currentUserId === post.applicationUserId && (
              <div className="actionButtons">
                <button
                  type="button"
                  className="editButton postBtn"
                  onClick={unlockEdit}
                >
                  Redigera Annons
                </button>
                <button
                  type="button"
                  className="deleteButton postBtn"
                  onClick={deletePost}
                >
                  Ta Bort Annons
                </button>
              </div>
            )}
            {isEditable && (
              <div className="actionButtons">
                <button type="submit" className="editButton postBtn">
                  Spara Ändringar
                </button>
              </div>
            )}
          </div>
        </form>
      </div>
    </div>
  );
}

export default PostDetails;
