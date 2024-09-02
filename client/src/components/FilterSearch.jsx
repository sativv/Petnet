import React, { useEffect, useState } from 'react'

function FilterSearch({filterAndSearch}) {

    const [animalType, setAnimalType] = useState("")
    const [gender, setGender] = useState("");
    const [search, setSearch] = useState("")


    useEffect(() => {
        
        filterAndSearch(search, animalType, gender)
    }, [search, gender, animalType])

  return (
    <div className="filter-search">
        <input type="search" name="" id="" className='search' placeholder='Sök' value={search} onChange={e => setSearch(e.target.value)}/>

    <div className='filter-container'>


        <div className='filter-box'>
        <label htmlFor="type">Djurtyp</label>
        <select className='filter-input' defaultValue={""} value={animalType} name="type" id="" size={7} onChange={e => setAnimalType(e.target.value)}>
            <option value="">Alla</option>
            <option value="Hund">Hund</option>
            <option value="Katt">Katt</option>
            <option value="Fågeö">Fågel</option>
            <option value="Gnagare">Gnagare</option>
            <option value="Akvarium">Akvarium</option>
            <option value="Reptil">Reptil</option>
        </select>
        </div>
        <div  className='filter-box'>
        <label htmlFor="gender">Kön</label>
        <select className='filter-input' defaultValue={""} value={gender} name="gender" id="" size={3} onChange={e =>setGender(e.target.value)}>
            <option value="">Båda</option>
            <option value="Hane">Hane</option>
            <option value="Hona">Hona</option>
        </select>
        </div>
    </div>

    </div>
  )
}

export default FilterSearch