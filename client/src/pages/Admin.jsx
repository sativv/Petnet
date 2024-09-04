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
        <div></div>
    </div>
  )
}

export default Admin