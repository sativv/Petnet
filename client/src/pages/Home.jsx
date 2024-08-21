import { useNavigate } from "react-router-dom";

function Home() {
  const nav = useNavigate();
  return (
    <div>
      <button onClick={() => nav("/login")}>
        Klicka på mig för att logga in
      </button>
    </div>
  );
}

export default Home;
