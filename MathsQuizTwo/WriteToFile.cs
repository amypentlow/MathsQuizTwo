using System;
using System.Collections.Generic;
using System.IO;

namespace MathsQuizTwo
{
    public class WriteToFile
    {
        public void writeToFile(List<string> writeAnswers)
        {
            TextWriter textWriter = new StreamWriter(@"C:/Users/amy.pentlow/source/repos/MathsQuizTwo/MathsQuizTwo/Results.txt", true);
            textWriter.WriteLine(DateTime.Now);
            foreach(string answerString in writeAnswers)
            {
                textWriter.WriteLine(answerString);
            }
            textWriter.WriteLine("----------------------------------------------------------------------");
            textWriter.Close();
        }
    }
}