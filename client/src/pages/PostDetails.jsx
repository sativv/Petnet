import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

function PostDetails() {
  const { postId } = useParams();
  const [post, setPost] = useState(null);

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
        <div className="postInfo">
          <p>
            <strong>Breed:</strong> {post.animalBreed}
          </p>
          <p>
            <strong>Gender:</strong> {post.gender}
          </p>
          <p>
            <strong>Age:</strong> {post.age}
          </p>
        </div>
        <div className="postDetails">
          <h1 className="postTitle">{post.title}</h1>
          <p className="postDescription">{post.description}</p>
          <button className="contactButton">Ta Kontakt</button>
        </div>
      </div>
    </div>
  );
}

export default PostDetails;
