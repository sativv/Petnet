import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Post from "../components/Post";

function Home() {
  const nav = useNavigate();
  const [posts, setPosts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    var response = fetch("http://localhost:5054/api/post", {
      method: "GET",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((result) => setPosts(result))
      .then(setLoading(false));

    console.log(posts);
  }, []);

  return (
    <div>
      <div className="post-container">
        {loading && <p>Loading posts..</p>}
        {posts.map((post) => (
          <Post Post={post} />
        ))}
      </div>
    </div>
  );
}

export default Home;
