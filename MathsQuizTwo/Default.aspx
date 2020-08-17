<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MathsQuizTwo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maths Quiz!</title>
    <link href='https://fonts.googleapis.com/css?family=Merienda' rel='stylesheet'/>
    <link rel ="stylesheet" type="text/css" href ="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div  class="content">
            <div>
                <h1 class="text" id = "Title">Maths Quiz!</h1>
                <p class="text" id = "AskHowManyQuestions" runat ="server"></p>
                <input class="textBoxes" id="NumberOfQuestionsTextBox" type="text" name="text" runat="server" required/>
                <p class="text" id = "AskDifficulty" runat ="server"></p>
                <input class="textBoxes" id="DifficultyTextBox" type="text" name="difficultyText" runat="server" required />
            </div>
            <div>
                <p class="text" id="CountDownTimer" runat="server"></p>
                <div class ="text" id = "QuestionsAndTextBoxes" runat = "server"></div>
                <input type="hidden" name="hidden" id="hidden" runat="server" value="stop" />
                <button id ="Submit" type = "Submit" runat ="server">Submit</button>
            </div>
            <p id = "AnswerStrings" runat = "server"></p>
            <p class="text" id = "ScoreDisplay" runat = "server"></p>
        </div>
    </form>
    <script language = "javascript" src="timer.js"></script>
</body>
</html>
