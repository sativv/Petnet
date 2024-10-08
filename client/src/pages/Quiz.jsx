import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useContext } from "react";
import { userContext } from "../App";

function Quiz() {
  const nav = useNavigate();
  const [counter, setCounter] = useState(0);
  const [animals, setAnimals] = useState([]);
  const [animal, setAnimal] = useState("");
  const [quizData, setQuizData] = useState(null);
  const [questionsData, setQuestionsData] = useState(null);
  const [optionsData, setOptionsData] = useState([]);
  const [active, setActive] = useState(null);

  const { currentUser } = useContext(userContext);

  useEffect(() => {
    const getQuiz = async () => {
      try {
        const res = await fetch("https://localhost:7072/Quiz/quiz/1");
        if (!res.ok) throw new Error("Failed to fetch quiz data");
        const data = await res.json();
        setQuizData(data);
      } catch (error) {
        console.error("Error fetching quiz data:", error);
      }
    };
    getQuiz();
  }, []);

  useEffect(() => {
    const getQuestionsAndOptions = async () => {
      if (quizData) {
        try {
          const resQuestions = await fetch(
            `https://localhost:7072/Quiz/questionsByQuiz/${quizData.quizId}`
          );
          if (!resQuestions.ok) throw new Error("Failed to fetch questions");
          const questions = await resQuestions.json();
          setQuestionsData(questions);

          // Hämtar options för alla questions
          const optionsPromises = questions.map((q) =>
            fetch(
              `https://localhost:7072/Quiz/optionsByQuestion/${q.questionId}`
            ).then((res) => res.json())
          );
          const optionsResults = await Promise.all(optionsPromises);
          //Blandar listan med options på måfå
          setOptionsData(optionsResults.flat().sort(() => Math.random() - 0.5));
          console.log(optionsResults);
        } catch (error) {
          console.error("Error fetching questions or options:", error);
        }
      }
    };
    getQuestionsAndOptions();
  }, [quizData]);

  function HandleSubmit(e) {
    e.preventDefault();
    if (animal !== "") {
      setAnimals([...animals, animal]);
      setCounter(counter + 1);
    }
    setAnimal("");

    if (animal === "" || animal === null) {
      alert("Oj då, du glömde att välja ett svarsalternativ!");
    }
  }

  /* Sortera listan med djur för att få fram vilket djur som passar bäst */
  const sortedAnimal = animals.sort();
  console.log("Sorted Animals:", sortedAnimal);

  // Räknar antalet valda djur
  const count = {};
  for (let i = 0; i < sortedAnimal.length; i++) {
    let ele = sortedAnimal[i];
    if (count[ele]) {
      count[ele] += 1;
    } else {
      count[ele] = 1;
    }
  }
  console.log("Count:", count);

  // Jämför mängderna valda djur för att hitta den högsta
  let majorityAnimal = null;
  let maxCount = 0;

  for (let animal in count) {
    if (count[animal] > maxCount) {
      maxCount = count[animal];
      majorityAnimal = animal;
    }
  }

  console.log("Majority Animal:", majorityAnimal);

  if (!quizData || !questionsData) {
    return <div>Loading...</div>;
  }

  // Funktion för att dela texten i stycken baserat på radbrytningar
  const splitTextIntoParagraphs = (text) => {
    return text.split(/\r?\n\r?\n/);
  };

  const text = quizData[majorityAnimal?.toLowerCase()] || "";
  const paragraphs = splitTextIntoParagraphs(text);

  async function HandleResult() {
    try {
      const url = `https://localhost:7072/api/Account/update/quizResultByUserId/${currentUser.id}`;

      const qResult = {
        QuizResult: majorityAnimal,
      };

      const response = await fetch(url, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(qResult),
      });

      const contentType = response.headers.get("Content-Type");
      if (contentType) {
        const result = await response.json();
        console.log("Update successful:", result);
      } else {
        const text = await response.text();
        console.error("Update failed. Response is not JSON:", text);
      }
    } catch (error) {
      console.error("An error occurred:", error);
    }
  }
  return (
    <div className="quiz">
      {counter === 0 ? (
        <div className="quiz-cont-start">
          <h1>QUIZ</h1>
          <h2>{quizData.title}</h2>
          <h5>{quizData.info}</h5>
          <button onClick={() => setCounter(1)}>Starta Quizet</button>
        </div>
      ) : counter > questionsData.length ? (
        <div className="quiz-cont-result">
          <img
            src={`../images/quizImages/${
              majorityAnimal !== null ? majorityAnimal : ""
            }.jpg`}
            alt={majorityAnimal}
          />
          <h2 id="majority-animal">
            <span>
              {majorityAnimal === "Dog"
                ? "Hund "
                : majorityAnimal === "Cat"
                ? "Katt "
                : majorityAnimal === "Rabbit"
                ? "Kanin "
                : majorityAnimal === "Bird"
                ? "Fågel "
                : majorityAnimal === "Aquarium"
                ? "Akvarium "
                : majorityAnimal === "Reptile"
                ? "Reptil "
                : ""}
            </span>
            skulle passa dig perfekt!
          </h2>
          {paragraphs.map((para, index) => (
            <p key={index}>{para}</p>
          ))}{" "}
          <img
            src={`../images/quizBadges/border/${
              majorityAnimal !== null ? majorityAnimal : ""
            }.svg`}
            alt={majorityAnimal}
          />
          {currentUser ? (
            <button
              onClick={() => {
                HandleResult();
                nav(`/profile/${currentUser.id}`);
              }}
            >
              Lägg till i min profil
            </button>
          ) : (
            <></>
          )}
        </div>
      ) : (
        <form className="quiz-cont-questions" onSubmit={HandleSubmit}>
          <h1>{questionsData[counter - 1]?.text}</h1>
          {optionsData
            .filter(
              (o) => o.questionId === questionsData[counter - 1]?.questionId
            )
            .map((o) => (
              <button
                className={active === o.optionId ? "active" : ""}
                key={`${o.questionId}.${o.optionId}`}
                type="button"
                onClick={() => {
                  setActive(active === o.optionId ? null : o.optionId);
                  setAnimal(
                    animal === "" || animal !== o.animal ? o.animal : ""
                  );
                }}
              >
                {o.option}
              </button>
            ))}
          <div className="counter-and-btn">
            <h5>
              {counter}/{questionsData.length}
            </h5>
            <button type="submit">Nästa</button>
          </div>
        </form>
      )}
    </div>
  );
}

export default Quiz;
