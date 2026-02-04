namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {
        public MainPage() // Costruttore della pagina
        {   
            // Inizializza i componenti grafici, permette di costruire i componenti della UI
            InitializeComponent();
        }

        private void BtnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreTesto = entConversione.Text;
            if(string.IsNullOrEmpty(valoreTesto))
            {
                return;
            }
            try
            {
                double franchi = Convert.ToDouble(valoreTesto);
                if(franchi > 0)
                {
                    double euro = franchi * 1.07;
                    lblRisultato.Text = string.Format("Risultato: {0:F2} €", euro);
                    lblRisultato.TextColor = Colors.White;
                }
                else
                {
                    VisualizzaErrore();
                }
            }
            catch (Exception ex)
            {
                VisualizzaErrore();
            }
        }

        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            entConversione.Text = "";
            entConversione.Focus();
            string textRisultato = lblRisultato.Text; 
            if(textRisultato != "Risultato: -" && textRisultato != "Pronto per convertire")
            {
                lblRisultato.Text = "Pronto per convertire";
            }
            lblRisultato.TextColor = Colors.White;
        }

        public void VisualizzaErrore()
        {
            lblRisultato.Text = "Inserire solo numeri positivi";
            lblRisultato.TextColor = Colors.Red;
        }
    }
}
