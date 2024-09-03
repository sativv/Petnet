import React, { useState, useContext } from 'react'
import { userContext } from "../App";
import { useNavigate } from "react-router-dom";

function AddPost() {

    const nav = useNavigate();

    var datenow = new Date();
    var currentDate = datenow.toISOString().substring(0,10);

    const { currentUser, setCurrentUser } = useContext(userContext);
    const [title, setTitle] = useState("");
    const [type, setType] = useState("");
    const [breed, setBreed] = useState("");
    const [gender, setGender] = useState("");
    const [img, setImg] = useState("");
    const [desc, setDesc] = useState("");
    const [dateOfBirth, setDateOfBirth] = useState("");
    const [earliestDelivery, setEarliestDelivery] = useState(currentDate)
    const [errorMsg, setErrorMsg] = useState("");


    

    const calcAge = (birthdate) => {
        var birthdate = new Date(birthdate);
        var current = new Date();

        var diff = current - birthdate;
        return Math.floor(diff/31536000000);
    }

    const submitPost = async (e) => {
        e.preventDefault();
        console.log(e);


        let errMsg = "";
        if(title === ""){
            errMsg = errMsg + "Please fill out the title \n";
        }
        if(desc === ""){
            errMsg = errMsg + "Please fill out the description \n";
        }
        if(img === ""){
            errMsg = errMsg + "Please add a picture url \n";
        }
        if(gender === ""){
            errMsg = errMsg + "Please select a gender \n";
        }
        if(type === ""){
            errMsg = errMsg + "Please fill out the type of animal \n";
        }
        if(breed === ""){
            errMsg = errMsg + "Please fill out the breed \n";
        }

        if(errMsg !== ""){
            alert(errMsg);
            return;
        }



        const payload = {
            "title": title,
            "description": desc,
            "images": [
              img
            ],
            "gender": gender,
            "dateOfBirth": dateOfBirth,
            "animalType": type,
            "animalBreed": breed,
            "age": (calcAge(dateOfBirth) < 0 ? "0" : calcAge(dateOfBirth)),
            "isAdoptionReady": (currentDate === earliestDelivery),
            "earliestDelivery": earliestDelivery,
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
            <label htmlFor="title">Titel</label>
            <input className='login-input ' type="text" name="" id="title" required value={title} onChange={(e) => setTitle(e.target.value)}/>

            <label htmlFor="type">Djurtyp</label>
            {/* <input className='login-input' type="text" name="" id="type" required value={type} onChange={(e) => setType(e.target.value)}/> */}

            <select className='login-input text-center'  name="" id="type" required value={type} onChange={(e) => setType(e.target.value)}>
                <option value="">Typ av djur</option>
                <option value="Hund">Hund</option>
                <option value="Katt">Katt</option>
                <option value="Fågel">Fågel</option>
                <option value="Gnagare">Gnagare</option>
                <option value="Akvarium">Akvarium</option>
                <option value="Reptil">Reptil</option>
                <option value="N/A">N/A</option>
                
            </select>

            <label htmlFor="breed">Ras</label>
            <input className='login-input' type="text" name="" id="breed" required value={breed} onChange={(e) => setBreed(e.target.value)}/>


            <label htmlFor="gender">Kön</label>

            <select className='login-input text-center'  name="" id="gender" required value={gender} onChange={(e) => setGender(e.target.value)}>
                <option value="">Kön</option>
                <option value="Hane">Hane</option>
                <option value="Hona">Hona</option>
                <option value="Båda">Båda</option>
                <option value="N/A">N/A</option>
                
            </select>
            <label htmlFor="">Födelsedatum</label>
            <input className='login-input text-center' type="date" name="" id="" value={dateOfBirth} onChange={(e) => setDateOfBirth(e.target.value)}/>

            <label htmlFor="">Tidigast adoption</label>
            <input className='login-input text-center' type="date" name="" id="" value={earliestDelivery} onChange={(e) => setEarliestDelivery(e.target.value)} min={currentDate}/>


            <label htmlFor="img">Bildlänk</label>
            <input className='login-input' type="url" name="" id="img" required value={img} onChange={(e) => setImg(e.target.value)} />

            <label htmlFor="desc">Beskrivning</label>
            <textarea className='login-input add-textarea' type="text" name="" id="desc" required value={desc} onChange={(e) => setDesc(e.target.value)}/>

            <button className='login-button' style={{marginTop:"20px"}}> Submit</button>

        </form>
    </div>
  )
}

export default AddPost