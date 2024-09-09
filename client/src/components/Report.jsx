import React, { useState } from "react";

function Report({ report }) {
  console.log(report);
  const [isEditable, setIsEditable] = useState(false);
  const [adminComment, setAdminComment] = useState(report.adminComment);

  const unlockEdit = () => {
    setIsEditable(true);
  };

  const saveEdit = () => {
    setIsEditable(false);

    fetch(`https://localhost:7072/api/Report/${report.reportId}`, {
      method: "PATCH",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ adminComment: adminComment }),
    });
  };
  return (
    <div className="report-card">
      <p>
        User reported:{" "}
        <a href={"/profile/" + report.reportedUserId}>
          {report.reportedUserId}
        </a>
      </p>
      <p>Reporter: {report.sendedReportUserId}</p>
      <p>Time: {report.timeReported}</p>
      <p>Reason: {report.reasonOfReport ? report.reasonOfReport : "N/A"}</p>
      <div>
        <label htmlFor="adminComment">Admin comment: </label>
        <input
          type="text"
          name="adminComment"
          id=""
          className="postInput"
          value={adminComment || ""}
          disabled={!isEditable}
          onChange={(e) => setAdminComment(e.target.value)}
        />
      </div>
      {!isEditable && (
        <button style={{ alignSelf: "center" }} onClick={unlockEdit}>
          Add / Edit comment
        </button>
      )}
      {isEditable && (
        <button style={{ alignSelf: "center" }} onClick={saveEdit}>
          Spara
        </button>
      )}
    </div>
  );
}

export default Report;
