import React, { useState } from 'react'

function AddPost() {

    const [title, setTitle] = useState("");
    const [type, setType] = useState("");
    const [breed, setBreed] = useState("");
    const [gender, setGender] = useState("");
    const [img, setImg] = useState("");
    const [desc, setDesc] = useState("");


    const submitPost = (e) => {
        e.preventDefault();
        console.log(e);
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