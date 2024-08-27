function Post({ Post }) {
  return (
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
  );
}

export default Post;
