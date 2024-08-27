import { useNavigate } from "react-router-dom";
import Post from "../components/Post";

function Home() {
  const nav = useNavigate();
  return (
    <div>
      <Post />
      <button onClick={() => nav("/login")}>
        Klicka på mig för att logga in
      </button>
    </div>
  );
}

export default Home;
