using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;

namespace MathsQuizTwo
{
    public class Quiz
    {
        public List<Question> generateQuestions(int numberofQuestions, string difficultyLevel)
        {
            List<Question> questions = new List<Question>();
            for (int index = 0; index < numberofQuestions; index++)
            {
                string questionString;
                Question question = new Question(difficultyLevel);
                if(question.isValid)
                {
                    questionString = question.writeQuestion(question.number1, question.number2, question.questionOperator);
                    questions.Add(question);
                }
                else
                {
                    index--;
                }
            }
            return questions;
        }

        public string howManyQuestions()
        {
            return "How many questions would you like to answer?";
        }

        public string askDifficultyLevel()
        {
            return "Please enter a difficulty (easy, average, difficult)";
        }

        public bool compareAnswers(double answer, double userAnswer)
        {
            return answer == userAnswer;
        }

        public int writeQuestions(List<Question> questions, int index, HtmlGenericControl QuestionsAndTextBoxes, List<double> correctAnswers)
        {
            foreach (Question question in questions)
            {
                HtmlGenericControl questionControl = new HtmlGenericControl("p");
                questionControl.InnerText = question.writeQuestion(question.number1, question.number2, question.questionOperator);
                HtmlInputText questionTextBox = new HtmlInputText();
                QuestionsAndTextBoxes.Controls.Add(questionControl);
                questionControl.Attributes["class"] = "text";
                QuestionsAndTextBoxes.Controls.Add(questionTextBox);
                questionTextBox.Attributes["class"] = "textBoxes";
                questionTextBox.Name = "T" + index.ToString();
                questionTextBox.ID = "T" + index.ToString();
                correctAnswers.Add(question.answer.answer);
                index++;
            }
            return index;
        }

        public int calculateScore(Quiz quiz, HtmlGenericControl answerStrings, HttpRequest request)
        {
            int index = 0;
            int score = 0;
            List<string> writeAnswers = new List<string>();
            foreach (string answer in request.Form)
            {
                if (answer.StartsWith("T"))
                {
                    HtmlGenericControl writeAnswer = new HtmlGenericControl("p");
                    List<double> correctAnswers = (List<double>)HttpContext.Current.Session["correctAnswers"];
                    if (quiz.compareAnswers(correctAnswers[index], Convert.ToDouble(request.Form[answer])))
                    {
                        score += 1;
                    }

                    string answerComparison = "Your answer was " + Convert.ToDouble(request.Form[answer]) + ". The correct answer was " + correctAnswers[index] + ".";
                    writeAnswer.InnerText = answerComparison;
                    answerStrings.Controls.Add(writeAnswer);
                    writeAnswers.Add(answerComparison);
                    writeAnswer.Attributes["class"] = "text";
                    index++;
                }
            }
            WriteToFile fileWriter = new WriteToFile();
            fileWriter.writeToFile(writeAnswers);
            return score;
        }
    }
}