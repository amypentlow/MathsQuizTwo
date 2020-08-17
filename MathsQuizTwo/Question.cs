using System;

namespace MathsQuizTwo
{
    public enum Operator
    {
        Addition = '+', Subtraction = '-', Multiplication = '*', Division = '/', SquareRoot = '√', Power = '^'
    }
    public class Question
    {
        public static Random random = new Random();
        public double number1 { get; set; }
        public double number2 { get; set; }
        public Operator questionOperator { get; set; }
        public Answer answer { get; set; }
        public bool isValid { get; set; }
        public string difficultyLevel {get; set;}

        public Question(string difficultyLevel)
        {
            setDifficultyLevel(difficultyLevel);
            string[] operators = Enum.GetNames(typeof(Operator));
            number1 = random.Next(1, 10);
            number2 = random.Next(1, 10); 
            answer = new Answer(number1, number2, questionOperator);
            isValid = checkAnswerIsInt(answer.answer);
        }
        
        public string writeQuestion(double number1, double number2, Operator questionOperator)
        {
            if(questionOperator == Operator.SquareRoot)
            {
                return "What is " + (char)questionOperator + number1 + "?";
            }
            else
            {
                return "What is " + number1 + (char)questionOperator + number2 + "?";
            }
        }

        private static Operator getRandomOperator(Random random, int firstIndex, int lastIndex)
        {
            Array operators = Enum.GetValues(typeof(Operator));
            Operator[] difficultyValues = new Operator[lastIndex + 1];
            Array.Copy(operators, 0, difficultyValues, firstIndex, lastIndex+1);
            Operator randomOperator = (Operator)difficultyValues.GetValue(random.Next(difficultyValues.Length));
            return randomOperator;
        }
        public bool checkAnswerIsInt(double answer)
        {
            return ((answer % 1) == 0);
        }

        public void setDifficultyLevel(string difficultyLevel)
        {
            if(difficultyLevel == "easy")
            {
                this.questionOperator = getRandomOperator(random, 0, 1);
            }
            else if(difficultyLevel == "average")
            {
                this.questionOperator = getRandomOperator(random, 0, 3);
            }
            else
            {
                this.questionOperator = getRandomOperator(random, 0, 5);
            }
        }
    }
}