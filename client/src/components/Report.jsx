import React from 'react'

function Report({report}) {
  return (
    <>
    <p>User reported: {report.reported}</p>
    <p>Reporter {report.sender}</p>
    <p>Time: {report.time}</p>
    <p>Reason: {report.reason}</p>


    </>
  )
}

export default Report