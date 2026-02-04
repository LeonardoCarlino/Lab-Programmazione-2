using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

namespace AppEquation
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        public void ValidazionePreventiva(object sender, EventArgs a)
        {
            string strA = EntA.Text;
            string strB = EntB.Text;
            string strC = EntC.Text;

            if (string.IsNullOrWhiteSpace(strA) || string.IsNullOrWhiteSpace(strB) || string.IsNullOrWhiteSpace(strC))
            {
                LblRisultato.Text = "C'è almeno un campo vuoto";
                LblRisultato.TextColor = Colors.Orange;
                return;
            }
            RisolviEquazione(strA, strB, strC);
        }
        public void RisolviEquazione(string strA, string strB, string strC)
        {
            try
            {
                double numA = Convert.ToDouble(strA);
                double numB = Convert.ToDouble(strB);
                double numC = Convert.ToDouble(strC);

                if(numA == 0)
                {
                    throw new ArgumentOutOfRangeException("Il valore a deve essere diverso da 0");
                }
                double delta = Math.Pow(numB, 2) - 4 * numA * numC;

                if(delta > 0)
                {
                    double x1 = (-numB + Math.Sqrt(delta))/(2*numA);  
                    double x2 = (-numB - Math.Sqrt(delta))/(2*numA);
                    LblRisultato.Text = string.Format("Risultato: S{x1 = {0:F2}, x2 = {1:F2}}", x1, x2);
                    LblRisultato.TextColor = Colors.Green;
                }
                else if (delta == 0)
                {
                    double x1 = (-numB + Math.Sqrt(delta)) / (2 * numA);
                    LblRisultato.Text = string.Format("Risultato: S{{0:F2}}", x1);
                    LblRisultato.TextColor = Colors.Blue;
                } 
                else
                {
                    LblRisultato.Text = "Nessun risultato reale";
                    LblRisultato.TextColor = Colors.Red;
                }


            } 
            catch (ArgumentOutOfRangeException are)
            {
                LblRisultato.Text = string.Format("Errore: " + are.Message);
                LblRisultato.TextColor = Colors.Red;
            }
            catch (Exception e)
            {
                LblRisultato.Text = "Errore: Controllare i valori di input";
                LblRisultato.TextColor = Colors.Red;
            }



        }
    }
}
