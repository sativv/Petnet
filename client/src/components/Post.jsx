import { Link } from "react-router-dom";

function Post({ Post }) {
  return (
    <Link to={`/post/${Post.id}`}>
      <div className="adContainer">
        <div className="adImgContainer">
          <img className="adImg" src={Post.images[0]} alt="" />
        </div>
        <div className="adBottom">
          <h3>{Post.animalBreed}</h3>
          <p>Kön: {Post.gender}</p>
          <p>Färg: {Post.Color}</p>
        </div>
      </div>
    </Link>
  );
}

export default Post;
