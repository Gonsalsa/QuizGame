using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class PlayQuizViewModel
    {
        public Quiz Quiz { get; set; }
        public Questions CurrentQuestion { get; set; }
        public int SelectedAnswerIndex { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswerd { get; set; }


        public PlayQuizViewModel()
        {
            Quiz = new Quiz("TestQuiz");
            Quiz.AddQuestion("Vad heter Sveriges huvudstad?", 0, "Stockholm", "Göteborg", "Malmö");
            Quiz.AddQuestion("Vilken färg har himmlen?", 2, "Röd", "Grön", "Blå");
            Quiz.AddQuestion("Hur många ben har en katt?", 1, "5", "4", "75");

            CurrentQuestion = Quiz.GetRandomQuestion();
            SelectedAnswerIndex = -1;
        }

        public void NextQuestion()
        {
            TotalAnswerd++;
            if (CurrentQuestion.isCorrect(SelectedAnswerIndex))
            {
                CorrectAnswers++;
            }

            SelectedAnswerIndex = -1;
            CurrentQuestion = Quiz.GetRandomQuestion();
        }

    }
}
