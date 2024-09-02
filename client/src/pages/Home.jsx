import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Post from "../components/Post";
import FilterSearch from "../components/FilterSearch";

function Home() {
  const nav = useNavigate();
  const [posts, setPosts] = useState([]);
  const [filteredPosts, setFilteredPosts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isFiltering, setIsFiltering] = useState(false);

  function searchByValue(array, string){
         return array.filter(o => {
               	return Object.keys(o).some(k => {
                         	if(typeof o[k] === 'string') return o[k].toLowerCase().includes(string.toLowerCase());
                               });
                            }); }

  function filterAndSearch(search, type, gender){
    let filtered = []
    let currentlyFiltering = false;
    // if(search === "" && type === "" && gender === ""){
      
    // }

    if(type !== ""){
      filtered = posts.filter((post) =>post.animalType === type);
      currentlyFiltering = true;
    }
    
    if(gender !== ""){
      filtered = (filtered.length > 0 ? filtered : posts).filter((post) => post.gender.toLowerCase() === gender.toLowerCase());
      currentlyFiltering = true;
    }

    if(search !== ""){
      filtered = searchByValue((filtered.length > 0 ? filtered : posts), search);
      currentlyFiltering = true;
    }
    console.log(filtered)
    setIsFiltering(currentlyFiltering)
    setFilteredPosts(filtered)
  }

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
        <FilterSearch filterAndSearch={filterAndSearch}/>
      <div className="post-container">
        {loading && <p>Loading posts..</p>}
        {isFiltering && filteredPosts.length <= 0 ? <p>Inga result</p> : <></>}
        {(filteredPosts && isFiltering ? filteredPosts : posts).map((post) => (
          <Post Post={post} key={post.id} />
        ))}
      </div>
    </div>
  );
}

export default Home;
