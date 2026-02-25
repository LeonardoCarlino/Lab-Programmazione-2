namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	int _score = 0;
	public ResultPage(int score)
	{
		_score = score;
		InitializeComponent();
		ShowGUI();
	}

	private void ShowGUI()
	{
        lblScore.Text = _score.ToString();
	}

    private void btnPlayAgain_Clicked(object sender, EventArgs e)
    {
        OnPlayAgainPressed();
    }

    private async void OnPlayAgainPressed()
    {
        // Richiamiamo il metodo PushAsync e gli passiamo il nuovo oggetto result
        // Attendiamo senza bloccare la pagina grazie ad await e async
        await Navigation.PushAsync(new MainPage());
    }
}