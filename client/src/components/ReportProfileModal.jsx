import React, { useState } from "react";
import "../App.css";

function ReportProfileModal(props) {
  const [reasonOfReport, setReasonOfReport] = useState("");
  const [message, setMessage] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    const reportData = {
      reportId: 0,
      reasonOfReport: reasonOfReport,
      adminComment: "",
      sendedReportUserId: props.currentUserId,
      reportedUserId: props.userProfileId,
      timeReported: new Date().toISOString(),
    };

    try {
      const response = await fetch("https://localhost:7072/api/Report", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(reportData),
      });

      if (response.ok) {
        setMessage("Rapporten har skickats!");
        setReasonOfReport("");
      } else {
        setMessage("Misslyckades med att skicka rapport.");
      }
    } catch (error) {
      setMessage("Ett fel uppstod vid anslutning till servern.");
      console.error("Error:", error);
    }
  }

  return (
    <>
      <div className="report-profile-modal-outer-container">
        <div className="report-profile-modal">
          <button
            className="report-profile-modal-close-btn"
            onClick={props.closeModal}
          >
            x
          </button>
          <h2 className="report-profile-modal-header">Anmäl profil</h2>
          <form onSubmit={handleSubmit}>
            <div className="input-report-container">
              <label>Anledning till anmälan: </label>
              <textarea
                name="reason"
                value={reasonOfReport}
                onChange={(e) => setReasonOfReport(e.target.value)}
              ></textarea>
            </div>
            <button className="report-profile-submit-button" type="submit">
              Skicka
            </button>
          </form>
          {message && <p>{message}</p>}
        </div>
      </div>
    </>
  );
}

export default ReportProfileModal;
