import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

function PostDetails() {
  const { postId } = useParams();
  const [post, setPost] = useState(null);
  const [isEditable, setIsEditable] = useState(false); // State to track if the form is editable

  const nav = useNavigate();

  const unlockEdit = () => {
    setIsEditable(true); // toggles/enables form fields
  };

  const deletePost = () => {
    // ask user to confirm before executing deletion
    const isConfirmed = window.confirm(
      "Är du säker på att du vill ta bort annonsen?"
    );

    if (isConfirmed) {
      const response = fetch(
        `https://localhost:7072/api/Post/RemovePost/${post.id}`,
        {
          method: "DELETE",
        }
      );

      if (response.ok) {
        // post was deleted, send user to homepage
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
  }, [postId]);

  if (!post) {
    return <div>Loading...</div>;
  }

  return (
    <div className="postCard">
      <div className="postImage">
        <img src={post.images[0]} alt={post.title} />
      </div>
      <div className="postContent">
        <form>
          <div className="postInfo">
            <label>
              <strong>Breed:</strong>
              <input
                type="text"
                value={post.animalBreed}
                disabled={!isEditable}
                onChange={(e) =>
                  setPost({ ...post, animalBreed: e.target.value })
                }
                className="postInput"
              />
            </label>
            <label>
              <strong>Gender:</strong>
              <input
                type="text"
                value={post.gender}
                disabled={!isEditable}
                onChange={(e) => setPost({ ...post, gender: e.target.value })}
                className="postInput"
              />
            </label>
            <label>
              <strong>Age:</strong>
              <input
                type="text"
                value={post.age}
                disabled={!isEditable}
                onChange={(e) => setPost({ ...post, age: e.target.value })}
                className="postInput"
              />
            </label>
          </div>
          <div className="postDetails">
            <h1 className="postTitle">
              <input
                type="text"
                value={post.title}
                disabled={!isEditable}
                onChange={(e) => setPost({ ...post, title: e.target.value })}
                className="postInput postTitleInput"
              />
            </h1>
            <p className="postDescription">
              <textarea
                value={post.description}
                disabled={!isEditable}
                onChange={(e) =>
                  setPost({ ...post, description: e.target.value })
                }
                className="postInput postDescriptionInput"
              />
            </p>
            <button type="button" className="contactButton">
              Ta Kontakt
            </button>
            {!isEditable && (
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
