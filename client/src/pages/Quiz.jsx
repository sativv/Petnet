// import { type } from "@testing-library/user-event/dist/type";
// import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";

// function Quiz() {
//   const nav = useNavigate();
//   const [counter, setCounter] = useState(0);
//   const [animals, setAnimals] = useState([]);
//   const [animal, setAnimal] = useState("");
//   const [quizData, setQuizData] = useState({});
//   const [questionsData, setQuestionsData] = useState([]);
//   const [optionsData, setOptionsData] = useState([]);

//   async () => {
//     await fetch("url här")
//       .then((res) => res.json())
//       .then((data) => setQuizData(data));
//   };

//   const questions = async () => {
//     await fetch("url hämta questions med quizid")
//       .then((res) => res.json())
//       .then((data) => setQuestionsData(data));
//   };

//   const options = async () => {
//     await fetch("url hämta alla options med questionid")
//       .then((res) => res.json())
//       .then((data) => setOptionsData(data));
//   };

//   useEffect(() => {
//     if (counter > 0) {
//       questions();
//       options();
//     }
//   }, [counter]);

//   function HandleSuubmit(e) {
//     e.preventDefault();
//     setAnimals([...animals, animal]);
//     setCounter(counter + 1);
//   }

//   return (
//     <div className="quiz">
//       counter === 0 ? (
//       <div className="quiz-cont">
//         <h1>QUIZ</h1>
//         <h2>{quiz.Title}</h2>
//         <h5>{quiz.Info}</h5>
//         <button onClick={() => setCounter(counter + 1)}>Starta Quizet</button>
//       </div>
//       ) : counter > questionsData.length ? (
//       <div className="quiz-cont">
//         {/*Sortera listan med djur för att få fram vilken djur som passar bäst*/}
//         {setAnimal(animals.reduce((acc, animal) => {}))}

//         <img src="" alt="" />
//         <h1>QUIZ</h1>
//         <h2>{quiz.Title}</h2>
//         <h5>{quiz.Info}</h5>
//         <button onClick={counter++}>Starta Quizet</button>
//       </div>{" "}
//       ) :
//       <form className="quiz-cont" onSubmit={HandlaSubmit()}>
//         <h1>{question.Text}</h1>
//         {foreach(option in options)(
//           <button
//             key={`${option.QuestionId}.${option.OptionId}`}
//             onClick={() =>
//               setAnimal(
//                 animal === "" || animal !== option.Animal ? option.Animal : ""
//               )
//             }
//           >
//             {option.Option}
//           </button>
//         )}
//         <div className="counter-and-btn">
//           <h5>
//             {counter}/{questionsData.length}
//           </h5>
//           <button type="submit">Nästa</button>
//         </div>
//       </form>
//     </div>
//   );
// }

// export default Quiz;
