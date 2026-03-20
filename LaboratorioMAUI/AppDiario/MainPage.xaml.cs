using AppDiario.Models;

namespace AppDiario
{
    public partial class MainPage : ContentPage
    {   
        // Appdata - Local - Packages -
        // prende il path e aggiunge il file txt
        string percorsoFile = Path.Combine(FileSystem.AppDataDirectory, "note.txt");
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSalvaClicked(object sender, EventArgs e)
        {
            Nota nuovaNota = new Nota(); // Creo una nuova nota
            nuovaNota.Titolo = entTitolo.Text; //Leggo l'entry
            nuovaNota.Testo = entTesto.Text; // Leggo l'entry
            if (string.IsNullOrEmpty(nuovaNota.Titolo))
            {
                // Messaggio allerta + Testo + OK
                await DisplayAlert("Errore ", "Inserisci almeno il titolo", "OK");
                return; // esce dal metodo
            }

            // Il metodo DaOggettoARiga ritorna una stringa composta dagli attributi della Nota (Titolo; Testo)
            string rigaDaScrivere = nuovaNota.DaOggettoARiga();

            //La classe file mette a disposizione il metodo per appendere il testo  
            File.AppendAllText(percorsoFile, rigaDaScrivere + Environment.NewLine);

            // Pulisco gli entry
            entTitolo.Text = "";
            entTesto.Text = "";

            await DisplayAlert("Fatto", "Nota salvata correttamente", "OK");
        }

        private void OnLeggiClicked(object sender, EventArgs e)
        {   
            // IMPORTANTISSIMO verificare che il file esista
            if (File.Exists(percorsoFile))
            {   
                // Dichiaro e inizializzo un array che viene popolato con le righe del TXT
                // Ogni riga equivale ad un elemento dell'araay
                string[] righe = File.ReadAllLines(percorsoFile);
                ediDisplay.Text = "";

                // Usiamo il foreach per ciclare l'array delle righe
                foreach(string riga in righe)
                {
                    Nota n = Nota.DaRigaAOggetto(riga);

                    if(n != null)
                    {
                        ediDisplay.Text = ediDisplay.Text + "TITOLO: " + n.Titolo + "\n";
                        ediDisplay.Text = ediDisplay.Text + "TESTO: " + n.Testo + "\n";
                        ediDisplay.Text = ediDisplay.Text + "----------------------\n";
                    }
                }
            }
            else
            {
                ediDisplay.Text = "Il file è vuoto o non esiste ancora.";
            }
        }
    }
}
