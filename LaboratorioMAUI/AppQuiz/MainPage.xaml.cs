using AppQuiz.Models;
using System.Runtime.CompilerServices;

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
            ReadQuestion();
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

        private void ReadQuestion()
        {
            if (!File.Exists(_filePath))
            {
                return;
            }
            string[] domande = File.ReadAllLines(_filePath);
            try
            {
                foreach (string domanda in domande)
                {
                    string[] info = domanda.Split(";");
                    if (info[0].Equals("TF"))
                    {
                        string frase = info[1];
                        int punteggio = int.Parse(info[2]);
                        bool risultato = bool.Parse(info[3]);
                        string logo = info[4];

                        _questions.Add(new TrueFalseQuestion(frase, punteggio, risultato, logo));
                    }
                    else if (info[0].Equals("OPEN"))
                    {
                        string frase = info[1];
                        int punteggio = int.Parse(info[2]);
                        string risposta = info[3];
                        string logo = info[4];

                        _questions.Add(new OpenQuestion(frase, punteggio, risposta, logo));
                    }
                }
            }
            catch (Exception ex) {
                DisplayAlert("Errore", "Impossibile leggere il file delle domande: " + ex.Message, "OK");
            }
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
                UserAnswer.Text = "";
                UserAnswer.Placeholder = "Scrivi la risposta...";
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
