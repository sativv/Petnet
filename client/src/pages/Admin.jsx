import React, { useContext, useEffect, useState } from "react";
import { userContext } from "../App";
import { useNavigate } from "react-router-dom";
import Report from "../components/Report";

function Admin() {
  const { currentUser } = useContext(userContext);
  const nav = useNavigate();
  const [reports, setReports] = useState([]);
  const [loadingReports, setLoadingReports] = useState(true);

  useEffect(() => {
    var response = fetch("http://localhost:5054/api/Report", {
      method: "GET",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((result) => setReports(result))
      .then(setLoadingReports(false));
  }, []);

  if (!currentUser.isAdmin) {
    nav("/");
  }

  return (
    <div>
      <p>Admin page</p>
      <p>Anmälningar</p>
      <div className="report-container">
        {reports.map((report) => (
          <Report report={report} />
        ))}
      </div>

      <p>Verifikationer</p>
      <div className="verification-container"></div>
    </div>
  );
}

export default Admin;
