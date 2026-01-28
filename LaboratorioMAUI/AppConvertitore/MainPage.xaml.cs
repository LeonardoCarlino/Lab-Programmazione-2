using Java.Util.Concurrent;

namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {   
            // Inizializza i componenti grafici
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valorImporto = entConversione.Text;
            double franchi = Convert.ToDouble(valorImporto);

            double euro = franchi * 1.07;

            lblRisultato =
        }
    }

}
