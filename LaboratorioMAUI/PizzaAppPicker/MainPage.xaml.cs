using PizzaAppPicker.Models;

namespace PizzaAppPicker
{
    public partial class MainPage : ContentPage
    {
        List<Pizze> pizze;

        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            pizze = new List<Pizze>();
            pizze.Add(new Pizze("Margherita", 12.5f, "margherita.jpg", "impasto (farina, acqua, lievito, sale), salsa di pomodoro (spesso San Marzano DOP), mozzarella (fior di latte o bufala), basilico fresco e olio extravergine di oliva"));
            pizze.Add(new Pizze("Prosciutto", 19, "prosciutto.jpg", "impasto (farina, acqua, lievito, sale), salsa di pomodoro (spesso San Marzano DOP), mozzarella (fior di latte o bufala), basilico fresco e olio extravergine di oliva, prosciutto"));

            pickPizze.ItemsSource = pizze;
        }
    }

}
