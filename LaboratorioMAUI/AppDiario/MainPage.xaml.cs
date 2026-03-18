namespace AppDiario
{
    public partial class MainPage : ContentPage
    {
        string percorsoFile = Path.Combine(FileSystem.AppDataDirectory, "note.txt");
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSalvaClicked(object sender, EventArgs e)
        {
        }
        private void OnLeggiClicked(object sender, EventArgs e)
        {
        }
    }

}
