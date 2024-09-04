import React, { useContext } from 'react'
import { userContext } from '../App'
import { useNavigate } from 'react-router-dom';



function Admin() {
    const {currentUser} = useContext(userContext)
    const nav = useNavigate();

    if(!currentUser.isAdmin){
            nav("/");
    }

  return (
    <div>
        <p>Admin page</p>
        <p>Anmälningar</p>
        <div className='report-container'>

        </div>
        <p>Verifikationer</p>
        <div className="verification-container"></div>
    </div>
  )
}

export default Admin