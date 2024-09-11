import { useEffect, useState } from "react";
import Post from "../components/Post";

function BookMarkView() {
  const [posts, setPosts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [ownPosts, setOwnPosts] = useState([]);

  useEffect(() => {
    const fetchBookmarks = async () => {
      try {
        // Fetch the bookmark IDs first
        const bookmarksResponse = await fetch(
          "https://localhost:7072/api/Account/me/bookmarks",
          {
            method: "GET",
            credentials: "include",
          }
        );

        if (!bookmarksResponse.ok) {
          throw new Error("Failed to fetch bookmarks");
        }

        const bookmarkIds = await bookmarksResponse.json();

        if (bookmarkIds.length === 0) {
          setLoading(false);
          return; // No bookmarks, don't fetch posts
        }

        const postsResponse = await fetch(
          "https://localhost:7072/api/Post/AllPostByIds",
          {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(bookmarkIds),
          }
        );

        if (!postsResponse.ok) {
          throw new Error("Failed to fetch posts");
        }

        const postsData = await postsResponse.json();
        setPosts(postsData);
      } catch (error) {
        console.error(error.message);
      } finally {
        setLoading(false);
      }
    };
    const fetchOwnPosts = async () => {
      try {
        const ownPostsResponse = await fetch(
          "https://localhost:7072/api/Post/Own",
          {
            method: "GET",
            credentials: "include",
          }
        );

        if (!ownPostsResponse.ok) {
          throw new Error("Failed to fetch own posts");
        }

        const posts = await ownPostsResponse.json();
        setOwnPosts(posts);
      } catch (error) {
        console.log(error.message);
      }
    };
    fetchOwnPosts();
    fetchBookmarks();
  }, []);

  if (loading) {
    return <p>Loading bookmarks...</p>;
  }

  return (
    <div className="post-container main-content">
      <h2>Dina skapade annonser</h2>
      {ownPosts.length > 0 ? (
        ownPosts.map((post) => <Post key={post.id} Post={post} />)
      ) : (
        <p>Du har inga skapade annonser</p>
      )}

      <h2>Dina Sparade Annonser</h2>
      {posts.length > 0 ? (
        posts.map((post) => <Post key={post.id} Post={post} />)
      ) : (
        <p>Du har inga bokmärken</p>
      )}
    </div>
  );
}

export default BookMarkView;
