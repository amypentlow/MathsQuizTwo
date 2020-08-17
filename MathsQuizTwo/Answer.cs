using System;

namespace MathsQuizTwo
{
    public class Answer
    {
        public double answer { get; set; }

        public Answer(double number1, double number2, Operator questionOperator) {
            this.answer = generateAnswer(number1, number2, questionOperator);
        }

        public double generateAnswer(double number1, double number2, Operator questionOperator)
        {
            switch (questionOperator)
            {
                case Operator.Addition:
                    return number1 + number2;
                case Operator.Subtraction:
                    return number1 - number2;
                case Operator.Multiplication:
                    return number1 * number2;
                case Operator.Division:
                    return number1 / number2;
                case Operator.SquareRoot:
                    return Math.Sqrt(number1);
                case Operator.Power:
                    return Math.Pow(number1, number2);
            }
            return 0;
        }
    }
}