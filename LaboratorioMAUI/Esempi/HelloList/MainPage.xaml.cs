using HelloList.Models;

namespace HelloList
{
    public partial class MainPage : ContentPage
    {
        // Lista di frutta
        List<Frutto> frutti;

        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            frutti = new List<Frutto>();
            frutti.Add(new Frutto("mela", "Italia"));
            frutti.Add(new Frutto("kiwi", "Groelandia"));
            frutti.Add(new Frutto("ananas", "Svizzera"));

            //frutti.Remove("Mela"); // rimuoviamo la mela
            //frutti.Insert(1, "Banana"); // Si colloca all'indice 1
            //frutti.RemoveAt(1);

            // popolato l'item source del picker
            pickFrutti.ItemsSource = frutti;
        }

        private void pickFrutti_SelectedIndexChanged(object sender, EventArgs e)
        {
            Frutto selectFruit = (Frutto)pickFrutti.SelectedItem;
            entProvenienza.Text = selectFruit.Provenienza;
        }
    }

}
