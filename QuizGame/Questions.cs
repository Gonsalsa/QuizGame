using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Questions
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }

        public Questions(string statment, int correctanswer, params string[] answers)
        {
            Statement = statment;
            Answers = answers;
            CorrectAnswer = correctanswer;
        }

        public bool isCorrect(int selectedIndex)
        {
            return selectedIndex == CorrectAnswer;
        }

    }
}
