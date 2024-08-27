function Post({ Post }) {
  return (
    <div className="adContainer">
      <div className="adImgContainer">
        <img className="adImg" src={Post.Image} alt="" />
      </div>
      <div className="adBottom">
        <h3>{Post.AnimalBreed}</h3>
        <p>{Post.Gender}</p>
        <p>{Post.Color}</p>
      </div>
    </div>
  );
}

export default Post;
