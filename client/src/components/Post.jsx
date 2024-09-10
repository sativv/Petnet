import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";

function Post({ Post }) {
  const [isDesktop, setIsDesktop] = useState(window.innerWidth > 768);
  const nav = useNavigate();
  const updateScreenSize = () => {
    setIsDesktop(window.innerWidth > 768);
  };

  useEffect(() => {
    window.addEventListener("resize", updateScreenSize);
    return () => window.removeEventListener("resize", updateScreenSize);
  });

  if (isDesktop) {
    return (
      <div onClick={() => nav(`/post/${Post.id}`)} className="bigAdContainer">
        <div className="bigAdImgContainer">
          <img className="adImg" src={Post.images[0]} alt="" />
        </div>
        <div className="bigAdSide">
          <h3>{Post.animalBreed}</h3>
          <p>Kön: {Post.gender}</p>
          <p>Födelsedatum: {Post.dateOfBirth}</p>
          <p>Ålder: {Post.age}</p>
          <p>Tidigast adoption: {Post.earliestDelivery}</p>
          <p>Beskrivning: {Post.description}</p>
        </div>
      </div>
    );
  } else {
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
}

export default Post;
