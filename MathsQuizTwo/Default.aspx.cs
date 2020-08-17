using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MathsQuizTwo
{
    public partial class Default : System.Web.UI.Page
    {
        List<double> correctAnswers = new List<double>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Quiz quiz = new Quiz();
            checkPlayAgain(quiz);
        }

        private void checkPlayAgain(Quiz quiz)
        {
            if (!IsPostBack || (string)Session["playAgain"] == "true")
            {
                Session["playAgain"] = "false";
                Submit.InnerText = "Submit";
                Session["correctAnswers"] = null;
                DifficultyTextBox.Visible = true;
                ScoreDisplay.InnerText = "";
                NumberOfQuestionsTextBox.Visible = true;
                hidden.Value = "stop";
                AskHowManyQuestions.InnerText = quiz.howManyQuestions();
                AskDifficulty.InnerText = quiz.askDifficultyLevel();
            }
            else
            {
                ifIsPostBack(quiz);
            }
        }

        private void ifIsPostBack(Quiz quiz)
        {
            if (Session["correctAnswers"] == null)
            {
                clearWindow();
                Session["numberOfQuestions"] = Request.Form["NumberOfQuestionsTextBox"];
                Session["difficultyLevel"] = Request.Form["difficultyTextBox"];
                List<Question> questions = quiz.generateQuestions(Convert.ToInt32(Session["numberOfQuestions"]), Session["difficultyLevel"].ToString());
                int index = 0;
                index = quiz.writeQuestions(questions, index, QuestionsAndTextBoxes, correctAnswers);
                Session["correctAnswers"] = correctAnswers;
            }
            else if (IsPostBack)
            {
                hidden.Value = "stop";
                QuestionsAndTextBoxes.Controls.Clear();
                Submit.InnerText = "Play Again";
                int score = quiz.calculateScore(quiz, AnswerStrings, Request);
                ScoreDisplay.InnerText = "You scored " + score + " out of " + Session["numberOfQuestions"] + "!";
                Session["playAgain"] = "true";
            }
        }

        private void clearWindow()
        {
            AskHowManyQuestions.InnerText = "";
            AskDifficulty.InnerText = "";
            NumberOfQuestionsTextBox.Visible = false;
            DifficultyTextBox.Visible = false;
        }
    }
}