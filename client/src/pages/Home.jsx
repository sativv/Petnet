import { useNavigate } from "react-router-dom";

function Home() {
  const nav = useNavigate();
  return (
    <div>
      <h2>Hej</h2>

      <button onClick={() => nav("/login")}>Press me to Login</button>
    </div>
  );
}

export default Home;
