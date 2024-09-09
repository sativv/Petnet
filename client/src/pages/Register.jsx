import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

function Register() {
  const nav = useNavigate();
  const passwordRegex =
    /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>])[A-Za-z\d!@#$%^&*(),.?":{}|<>]{6,}$/;
  const check10NumbersRegex = /^\d{10}$/;
  const check5NumbersRegex = /^\d{5}$/;
  const containsSwedishLetters = /[åäö]/i;

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

    // Lägg till registreringsdata
    formData.append("Email", email);
    formData.append("Password", password);
    formData.append("IsPrivateSeller", isBreeder ? "false" : "true");
    formData.append("IsVerified", isBreeder ? "false" : "");
    formData.append("OrganizationNumber", isBreeder ? organizationNumber : "");
    formData.append("OrganizationName", isBreeder ? organizationName : "");
    formData.append("BuisnessContact", isBreeder ? buisnessContact : "");
    formData.append("Adress", isBreeder ? adress : "");
    formData.append("Postcode", isBreeder ? postcode : "");
    formData.append("City", isBreeder ? city : "");
    formData.append("PhoneNumber", isBreeder ? phone : "");

    // Lägg till filen om den finns
    if (registration) {
      for (let i = 0; i < registration.length; i++) {
        formData.append("Files", registration[i]);
      }
    }

    if (email.length < 10 || containsSwedishLetters.test(email)) {
      alert(
        "Email måste innehålla minst 10 tecken och får inte innehålla å, ä, ö"
      );
      return;
    }

    //Mailadress uppfyller minikraven
    try {
      const emailResponse = await fetch(
        `https://localhost:7072/api/Account/check-email?email=${email}`
      );
      const data = await emailResponse.json();

      if (data.exists) {
        alert("Mejladressen används redan, var god välj en annan!");
        return;
      }
    } catch (error) {
      console.error("Error checking email:", error);
      alert(
        "Ett fel uppstod när vi försökte kolla tillgängligheten på din mejladress"
      );
      return;
    }

    if (!passwordRegex.test(password)) {
      alert(
        "Lösenordet måste vara minst 6 tecken långt och innehålla minst ett nummer och ett specialtecken!"
      );
      return;
    }

    if (password !== passwordAgain) {
      alert(
        "Lösenordet och det upprepade lösenordet matchar inte, \nförsök igen!"
      );
      return;
    }

    if (isBreeder) {
      if (!check10NumbersRegex.test(organizationNumber)) {
        alert(
          "Fältet innehåller bokstäver, specialtecken eller är inte 10 siffror långt, var god ange ett korrekt organisationsnummer!"
        );
        return;
      }

      if (!check5NumbersRegex.test(postcode)) {
        alert(
          "Fältet innehåller bokstäver, specialtecken eller är inte 5 siffror långt, var god ange ett korrekt postnummer!"
        );
        return;
      }

      if (!check10NumbersRegex.test(phone)) {
        alert(
          "Fältet innehåller inte 10 siffror, otillåtna bokstäver eller otillåtna specialtecken, var god ange ett korrekt telefonnummer!"
        );
        return;
      }

      // Kontrollera antal filer
      if (registration.length > 3) {
        alert(`Du kan ladda upp högst 3 filer!`);
        return;
      }
    }

    try {
      const response = await fetch(
        "https://localhost:7072/api/Account/register",
        {
          method: "POST",
          body: formData,
        }
      );

      if (!response.ok) {
        alert("Registration failed. Please try again.");
        return;
      }

      alert(
        "Välkommen, du är nu registrerad! Vänligen logga in med ditt nya konto "
      );

      nav("/login");
    } catch (e) {
      console.error("Error during registration:", e);
      alert("Ett fel uppstod vid registreringen. Vänligen försök igen.");
    }
  };

  const handleFileChange = (event) => {
    const MAX_FILE_SIZE_MB = 5; // Max filstorlek i megabyte

    const files = event.target.files; // FileList objekt
    setRegistration(files); // Spara alla valda filer i state

    const preview = document.getElementById("preview");
    preview.innerHTML = ""; // Rensa tidigare förhandsvisningar

    Array.from(files).forEach((file) => {
      // Kontrollera filstorlek
      if (file.size > MAX_FILE_SIZE_MB * 1024 * 1024) {
        alert(
          `${file.name} är för stor. Max storlek är ${MAX_FILE_SIZE_MB} MB.`
        );
        return;
      }

      // Förhandsvisning av PDF eller bild
      if (file && file.type === "application/pdf") {
        const reader = new FileReader();
        reader.onload = (e) => {
          const embed = document.createElement("embed");
          embed.src = e.target.result;
          embed.type = "application/pdf";
          preview.appendChild(embed);
        };
        reader.readAsDataURL(file);
      } else if (file && file.type.startsWith("image/")) {
        const reader = new FileReader();
        reader.onload = (e) => {
          const img = document.createElement("img");
          img.src = e.target.result;
          img.style.maxWidth = "200px";
          preview.appendChild(img);
        };
        reader.readAsDataURL(file);
      }
    });
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
              onChange={(e) => setEmail(e.target.value.trim())}
              required
            />
            <label>Lösenord</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value.trim())}
              required
            />
            <label>Upprepa lösenord</label>
            <input
              type="password"
              value={passwordAgain}
              onChange={(e) => setPasswordAgain(e.target.value.trim())}
              required
            />
            {isBreeder && (
              <>
                <label>Organisationsnummer</label>
                <input
                  type="text"
                  value={organizationNumber}
                  maxLength={10}
                  onChange={(e) =>
                    setOrganizationNumber(
                      e.target.value.replace(/\s+/g, "").trim()
                    )
                  }
                  required
                />
                <label>Företagsnamn</label>
                <input
                  type="text"
                  value={organizationName}
                  onChange={(e) => setOrganizationName(e.target.value.trim())}
                  required
                />
                <label>Kontaktperson</label>
                <input
                  type="text"
                  value={buisnessContact}
                  onChange={(e) => setBuisnessContact(e.target.value.trim())}
                  required
                />
                <label>Adress</label>
                <input
                  type="text"
                  value={adress}
                  onChange={(e) => setAdress(e.target.value.trim())}
                  required
                />
                <label>Postnummer</label>
                <input
                  type="text"
                  value={postcode}
                  maxLength={5}
                  onChange={(e) =>
                    setPostcode(e.target.value.replace(/\s+/g, "").trim())
                  }
                  required
                />
                <label>Ort</label>
                <input
                  type="text"
                  value={city}
                  onChange={(e) => setCity(e.target.value.trim())}
                  required
                />
                <label>Telefonnummer</label>
                <input
                  type="tel"
                  value={phone}
                  maxLength={10}
                  onChange={(e) =>
                    setPhone(e.target.value.replace(/\s+/g, "").trim())
                  }
                  required
                />
                <label htmlFor="registration">Registreringsbevis</label>
                <input
                  name="registration"
                  type="file"
                  accept=".pdf, image/*"
                  multiple
                  onChange={handleFileChange}
                  required
                />
                <div id="preview"></div>
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
