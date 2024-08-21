function Profile() {
  const Logout = () => {};

  return (
    <div>
      <h2>Hej du är inloggad</h2>

      <button onClick={Logout}>Logout</button>
    </div>
  );
}

export default Profile;
