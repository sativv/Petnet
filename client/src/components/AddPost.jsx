import React, { useState, useContext } from 'react'
import { userContext } from "../App";
import { useNavigate } from "react-router-dom";

function AddPost() {

    const nav = useNavigate();

    const { currentUser, setCurrentUser } = useContext(userContext);
    const [title, setTitle] = useState("");
    const [type, setType] = useState("");
    const [breed, setBreed] = useState("");
    const [gender, setGender] = useState("");
    const [img, setImg] = useState("");
    const [desc, setDesc] = useState("");


    


    const submitPost = async (e) => {
        e.preventDefault();
        console.log(e);

        const payload = {
            "title": title,
            "description": desc,
            "images": [
              img
            ],
            "gender": gender,
            "dateOfBirth": null,
            "animalType": type,
            "animalBreed": breed,
            "age": 0,
            "isAdoptionReady": true,
            "earliestDelivery": null,
            "applicationUser": {},
            "applicationUserId": currentUser.id
        }
        try{

            const response = await fetch('http://localhost:5054/api/Post/AddPost', {
                method: "POST",
                credentials: "include",
                headers:{
                            "Content-Type": "application/json"
                        },
                body: JSON.stringify(payload)
            })

            if(response.ok ){
                const responseBody = await response.json();

                nav(`/post/${responseBody.id}`)
            }
        }
        catch(err)
        {
            console.log(err)
        }

    }


  return (
    <div>
        <h3>Ladda upp annons</h3>
        <form onSubmit={submitPost} className="add-post-form">
            <label htmlFor="title">Title</label>
            <input className='login-input ' type="text" name="" id="title" required value={title} onChange={(e) => setTitle(e.target.value)}/>

            <label htmlFor="type">Animal type</label>
            <input className='login-input' type="text" name="" id="type" required value={type} onChange={(e) => setType(e.target.value)}/>

            <label htmlFor="breed">Breed</label>
            <input className='login-input' type="text" name="" id="breed" required value={breed} onChange={(e) => setBreed(e.target.value)}/>


            <label htmlFor="gender">Gender</label>
            <select className='login-input text-center' name="" id="gender" required value={gender} onChange={(e) => setGender(e.target.value)}>
                <option disabled selected value> -- select an option -- </option>
                <option value="Male">Male</option>
                <option value="Female">Female</option>
                <option value="Mixed">Mixed</option>
                <option value="N/A">N/A</option>
                
            </select>
            

            <label htmlFor="img">Image link</label>
            <input className='login-input' type="url" name="" id="img" required value={img} onChange={(e) => setImg(e.target.value)}/>

            <label htmlFor="desc">Description</label>
            <textarea className='login-input' type="text" name="" id="desc" required value={desc} onChange={(e) => setDesc(e.target.value)}/>

            <button className='login-button' style={{marginTop:"20px"}}> Submit</button>

        </form>
    </div>
  )
}

export default AddPost