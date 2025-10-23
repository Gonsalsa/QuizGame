using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class PlayQuizViewModel :INotifyPropertyChanged
    {
        public Quiz Quiz { get; set; }
        public Questions CurrentQuestion { get; set; }
        public int SelectedAnswerIndex { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswerd { get; set; }
        public string ScoreText
        {
            get
            {
                int percent = 0;
                if(TotalAnswerd > 0)
                {
                    percent = (int)((double)CorrectAnswers / TotalAnswerd * 100);
                }
                return $"Rätt: {CorrectAnswers}/{TotalAnswerd} ({percent}%)";
            }
        }


        public PlayQuizViewModel()
        {
            Quiz = new Quiz("TestQuiz");
            Quiz.AddQuestion("Vad heter Sveriges huvudstad?", 0, "Stockholm", "Göteborg", "Malmö");
            Quiz.AddQuestion("Vilken färg har himmlen?", 2, "Röd", "Grön", "Blå");
            Quiz.AddQuestion("Hur många ben har en katt?", 1, "5", "4", "75");

            CurrentQuestion = Quiz.GetRandomQuestion();
            SelectedAnswerIndex = -1;
            OnPropertyChange("CurrentQuestion");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void NextQuestion(int selectedIndex)
        {
            TotalAnswerd++;
            if (CurrentQuestion.isCorrect(selectedIndex))
            {
                CorrectAnswers++;
            }

            CurrentQuestion = Quiz.GetRandomQuestion();
            OnPropertyChange("CurrentQuestion");
            OnPropertyChange("ScoreText");
        }

    }
}
