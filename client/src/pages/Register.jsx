import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

function Register() {
  const nav = useNavigate();
  const passwordRegex =
    /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[A-Za-z\d!@#$%^&*(),.?":{}|<>]{6,}$/;

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordAgain, setPasswordAgain] = useState("");
  const [isBreeder, setIsBreeder] = useState(false);
  const [organizationNumber, setOrganizationNumber] = useState("");
  const [organizationName, setOrganizationName] = useState("");
  const [buisnessContact, setBuisnessContact] = useState("");
  const [adress, setAdress] = useState("");
  const [postcode, setPostcode] = useState("");
  const [city, setCity] = useState("");
  const [phone, setPhone] = useState("");
  const [registration, setRegistration] = useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = new FormData();
    formData.append("email", email);
    formData.append("password", password);

    if (isBreeder) {
      formData.append("organizationNumber", organizationNumber);
      formData.append("organizationName", organizationName);
      formData.append("buisnessContact", buisnessContact);
      formData.append("adress", adress);
      formData.append("postcode", postcode);
      formData.append("city", city);
      formData.append("phone", phone);
      if (registration) {
        formData.append("registration", registration);
      }
    }

    if (email.length < 10) {
      alert("Email must be at least 10 characters long");
      return;
    }

    if (!passwordRegex.test(password)) {
      alert(
        "Password must be at least 6 characters long and contain at least one number"
      );
      return;
    }

    if (password !== passwordAgain) {
      alert(
        "Lösenordet och det upprepade lösenordet matchar inte, \nförsök igen!"
      );
      return;
    }

    const response = await fetch("http://localhost:5054/register", {
      method: "POST",
      body: formData,
    });

    if (!response.ok) {
      // Hantera fel här, t.ex. visa ett felmeddelande
      alert("Registration failed. Please try again.");
      return;
    }

    alert("Welcome, your account has been created!");
    nav("/login");
  };

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    setRegistration(file);

    // Förhandsvisning av uppladdade filer, fungerar endast med bildformat
    if (file && file.type.startsWith("image/")) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const preview = document.getElementById("preview");
        preview.src = e.target.result;
        preview.style.display = "block";
      };
      reader.readAsDataURL(file);
    } else {
      const preview = document.getElementById("preview");
      preview.style.display = "none";
    }
  };

  const handleCheckboxChange = () => {
    setIsBreeder((prev) => !prev);
  };

  return (
    <div className="register">
      <div className="register-cont">
        <div className="register-info">
          <div className="info-title">
            <label>Skapa konto</label>
            <span>
              Har du redan ett konto?{" "}
              <Link to="/Login">
                <span>Logga in</span> här
              </Link>
            </span>
          </div>

          <div className="info-check-breeder">
            <label>
              <input
                type="checkbox"
                checked={isBreeder}
                onChange={handleCheckboxChange}
              />
              Registrerad uppfödare
            </label>
          </div>
        </div>

        <div className="register-input">
          <form onSubmit={handleSubmit}>
            <label>E-mejl</label>
            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
            <label>Lösenord</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
            <label>Upprepa lösenord</label>
            <input
              type="password"
              value={passwordAgain}
              onChange={(e) => setPasswordAgain(e.target.value)}
              required
            />
            {isBreeder && (
              <>
                <label>Organisationsnummer</label>
                <input
                  type="text"
                  value={organizationNumber}
                  onChange={(e) => setOrganizationNumber(e.target.value)}
                  required
                />
                <label>Företagsnamn</label>
                <input
                  type="text"
                  value={organizationName}
                  onChange={(e) => setOrganizationName(e.target.value)}
                  required
                />
                <label>Kontaktperson</label>
                <input
                  type="text"
                  value={buisnessContact}
                  onChange={(e) => setBuisnessContact(e.target.value)}
                  required
                />
                <label>Adress</label>
                <input
                  type="text"
                  value={adress}
                  onChange={(e) => setAdress(e.target.value)}
                  required
                />
                <label>Postnummer</label>
                <input
                  type="text"
                  value={postcode}
                  onChange={(e) => setPostcode(e.target.value)}
                  required
                />
                <label>Ort</label>
                <input
                  type="text"
                  value={city}
                  onChange={(e) => setCity(e.target.value)}
                  required
                />
                <label>Telefonnummer</label>
                <input
                  type="tel"
                  value={phone}
                  onChange={(e) => setPhone(e.target.value)}
                  required
                />
                <label htmlFor="registration">Registreringsbevis</label>
                <input
                  name="registration"
                  type="file"
                  accept=".pdf, image/*"
                  onChange={handleFileChange}
                />
                <img
                  id="preview"
                  src=""
                  alt="Förhandsgranskning"
                  style={{ display: "none", maxWidth: "200px" }}
                />
              </>
            )}

            <input
              id="register-btn"
              type="submit"
              value="Registrera mig"
              className="submitBtn"
            />
          </form>
        </div>
      </div>
    </div>
  );
}

export default Register;
