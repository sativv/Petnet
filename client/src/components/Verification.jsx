import React from 'react'

function Verification({verification}) {
  return (
    <div>
        <p>Verification for {verification.sender}</p>
        <p>Time: {verification.time}</p>
        <p>DATA</p>
    </div>
  )
}

export default Verification