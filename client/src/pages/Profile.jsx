import { useNavigate } from "react-router-dom";

function Profile() {
  const nav = useNavigate();
  const Logout = () => {
    const response = fetch("http://localhost:5054/api/account/logout", {
      method: "POST",
      credentials: "include",
    });

    nav("/");
  };

  return (
    <div>
      <h2>Hej du är inloggad</h2>

      <button onClick={Logout}>Logout</button>
    </div>
  );
}

export default Profile;
