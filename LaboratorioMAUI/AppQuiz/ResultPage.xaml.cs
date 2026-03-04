namespace AppQuiz;

public partial class ResultPage : ContentPage
{
    //Percorso dove leggere e salvare il file txt
    private static readonly string _filePath = Path.Combine(
        FileSystem.AppDataDirectory, "bestscore.txt");

	int _score = 0;
	public ResultPage(int score)
	{
		_score = score;
        SaveBestScore(score);
		InitializeComponent();
		ShowGUI(score);
	}

	private void ShowGUI(int score)
	{
        lblScore.Text = _score.ToString();

        lblBestScore.Text = "🏆 Miglior Punteggio: " + LoadBestScore().ToString();
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
    private void SaveBestScore(int score)
    {
        // Allochiamo lo score estrapolato dal file txt nella variabile best
        int best = LoadBestScore();


        // Se lo score del giocatore è maggiore di quello salvato 
        if(score > best)
        {
            try
            {
                File.WriteAllText(_filePath, score.ToString());
            }
            catch (Exception ex) 
            {
                DisplayAlert("Errore", "Impossibilie salvare il punteggio: " + ex.Message, "OK");
            }
        }
    }

    private int LoadBestScore()
    {
        if (!File.Exists(_filePath))
        {
            return 0;
        }

        //È buona abitudine gestire l'eccezione R/W!
        try
        {
            //Leggere il contenuto del file txt
            string content = File.ReadAllText(_filePath);

            //Variabile locale per contenere il best score
            int best;

            if (int.TryParse(content, out best))
            {
                return best;
            }
            else
            {
                DisplayAlert("Errore", "Il file del punteggio non esiste.", "OK");
                return 0;

            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Errore", "Impossibile leggere il punteggio: " + ex.Message, "OK");
            return 0;
        }
    }
}