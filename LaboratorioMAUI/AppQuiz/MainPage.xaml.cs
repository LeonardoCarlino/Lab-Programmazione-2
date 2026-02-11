using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        //Creiamo la lista delle domande
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score;
        private int _totalScore;
        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio ad oggetti?", 10, true, "csharp_logo.png"));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 15, false, "python_logo.png"));
            ShowQuestion();
        }
        
        private void OnAnswer_Clicked(object sender, EventArgs e)
         {
            // L'evento porta con se il sender che è il button
            var btn = (Button)sender;
            // Trasforma command parameter in stringa e lo rende valore booleano
            bool userAnwer = bool.Parse(btn.CommandParameter.ToString());

            if (_questions[_currentIndex].CheckAnswer(userAnwer))
            {
                _score += _questions[_currentIndex].Points;
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
            }
        }
    }

}
