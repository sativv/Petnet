import { type } from "@testing-library/user-event/dist/type";
import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

function Quiz() {
  const nav = useNavigate();
  const [counter, setCounter] = useState(0);
  const [animals, setAnimals] = useState([]);
  const [animal, setAnimal] = useState("");
  const [quizData, setQuizData] = useState({});
  const [questionsData, setQuestionsData] = useState([]);
  const [optionsData, setOptionsData] = useState([]);

  useEffect(() => {
    const getQuiz = async () => {
      try {
        const res = await fetch("https://localhost:7072/Quiz/quiz/1");
        if (!res.ok) throw new Error("Failed to fetch quiz data");
        const data = await res.json();
        setQuizData(data);
        console.log(data);
      } catch (error) {
        console.error("Error fetching quiz data:", error);
      }
    };
    getQuiz();
  }, []);

  useEffect(() => {
    if (quizData.QuizId) {
      console.log("question fetch started");

      const getQuestions = async () => {
        try {
          const res = await fetch(
            `https://localhost:7072/Quiz/questions by quiz/${quizData.QuizId}`
          );
          if (!res.ok) throw new Error("Failed to fetch questions");
          const data = await res.json();
          setQuestionsData(data);

          const options = data.map((q) =>
            fetch(
              `https://localhost:7072/Quiz/options by question/${q.QuestionId}`
            ).then((res) => res.json())
          );
          const optionsResults = await Promise.all(options);
          setOptionsData(optionsResults.flat());
        } catch (error) {
          console.error("Error fetching questions or options:", error);
        }
      };
      getQuestions();

      console.log(questionsData);
    }
  }, [quizData]);

  function HandleSubmit(e) {
    e.preventDefault();
    setAnimals([...animals, animal]);
    setCounter(counter + 1);
  }

  /*Sortera listan med djur för att få fram vilken djur som passar bäst*/
  const majorityAnimal = Object.entries(
    animals.reduce((acc, animal) => {
      acc[animal] = (acc[animal] || 0) + 1;
      return acc;
    }, {})
  ).sort((a, b) => b[1] - a[1])[0]?.[0];

  return (
    <div className="quiz">
      {counter === 0 ? (
        <div className="quiz-cont">
          <h1>QUIZ</h1>
          <h2>{quizData.title}</h2>
          <h5>{quizData.info}</h5>
          <button onClick={() => setCounter(counter + 1)}>Starta Quizet</button>
        </div>
      ) : counter > questionsData.length && questionsData.length !== 0 ? (
        <div className="quiz-cont">
          <img
            src={`../images/quizImages/${
              majorityAnimal !== null ? majorityAnimal : ""
            }.jpg`}
            alt={majorityAnimal}
          />
          <h2>{majorityAnimal} skulle passa dig perfekt!</h2>
          <button onClick={() => nav("/someRoute")}>Gå tillbaka</button>
        </div>
      ) : (
        <form className="quiz-cont" onSubmit={HandleSubmit}>
          <h1>{questionsData[counter].text}</h1>
          {optionsData.map((o) => (
            <button
              key={`${o.QuestionId}.${o.OptionId}`}
              type="button"
              onClick={() =>
                setAnimal(animal === "" || animal !== o.Animal ? o.Animal : "")
              }
            >
              {o.Option}
            </button>
          ))}
          <div className="counter-and-btn">
            <h5>
              {counter + 1}/{questionsData.length}
            </h5>
            <button type="submit">Nästa</button>
          </div>
        </form>
      )}
    </div>
  );
}

export default Quiz;
