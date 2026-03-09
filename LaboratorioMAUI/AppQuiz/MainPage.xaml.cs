using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private static readonly string _filePath = Path.Combine(
        FileSystem.AppDataDirectory, "domande.txt");

        //Creiamo la lista delle domande
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score;
        private int _totalScore;
        public MainPage()
        {
            InitializeComponent();
            string[] domande = File.ReadAllLines(_filePath);
            foreach (string domanda in domande) 
            {
                string[] info = domanda.Split(";");
                if (info[0].Equals("TF"))
                {
                    int punteggio;
                    new TrueFalseQuestion(info[1], continuare) ;
                }
            }
            ShowQuestion();
        }
        
        private async void OnAnswer_Clicked(object sender, EventArgs e)
         {
            QuestionBase current = _questions[_currentIndex];
            // L'evento porta con se il sender che è il button
            var btn = (Button)sender;

            string userAnswer = null;

            if (current is TrueFalseQuestion)
            {
                // Trasforma command parameter in stringa e lo rende valore booleano
                userAnswer = btn.CommandParameter.ToString();
            } else if(current is OpenQuestion)
            {
                if (string.IsNullOrWhiteSpace(UserAnswer.Text))
                {
                    DisplayAlert("Errore", "Il campo della risposta non può essere vuoto.", "OK");
                    return;
                }
                userAnswer = UserAnswer.Text;
            }

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                await DisplayAlert("Esatto!", "Hai indovinato.", "OK");
            }
            else
            {
                await DisplayAlert("Errore", "Riprova alla prossima.", "OK");
            }
                _totalScore += _questions[_currentIndex].Points;
            _currentIndex++;
            ShowQuestion();
         }
        
        private void ShowQuestion()
        {
            if(_currentIndex < _questions.Count)
            {
                //Creo un oggetto Question che contiene la domanda corrente
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
     
                QuestionImage.Source = current.ImageName;
                if (current is TrueFalseQuestion)
                {
                    TrueButton.IsVisible = true;
                    FalseButton.IsVisible = true;
                    UserAnswer.IsVisible = false;
                    SendUserAnswer.IsVisible = false;
                }
                else if (current is OpenQuestion)
                {
                    UserAnswer.IsVisible = true;
                    SendUserAnswer.IsVisible = true;
                    TrueButton.IsVisible = false;
                    FalseButton.IsVisible = false;
                }
                ScoreLabel.Text = $"Punti: {_score.ToString()}"; //Cast in stringa
            }
            else
            {
                QuestionTextLabel.Text = $"Fine! Punteggio finale: {_score} su {_totalScore}";
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                DomandaLabel.IsVisible = false;
                ScoreLabel.IsVisible = false;
                QuestionImage.IsVisible = false;
                BtnResult.IsVisible = true;
                UserAnswer.IsVisible = false;
                SendUserAnswer.IsVisible = false;
            }
        }

        private void btnResult_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }

        private async void OnQuizFinished()
        {
            await Navigation.PushAsync(new ResultPage(_score));
        }
    }

}
