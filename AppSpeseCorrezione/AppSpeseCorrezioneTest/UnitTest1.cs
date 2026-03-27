using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppSpeseCorrezioneTest
{
    public class Tests
    {
        private WindowsDriver _driver;
        [SetUp]
        public void Setup()
        {
            // Oggetto che contiene le opzioni di APPIUM per accedere all'applicazione
            // Oggetto di  tipo AppiumOptions
            var options = new AppiumOptions();

            options.PlatformName = "Windows";
            options.AutomationName = "Windows";
            options.DeviceName = "WindowsPC";
            //Aggiungere !App alla fine
            options.App = "com.companyname.appspesecorrezione_9zz4h110yvjzm!App";

            // indica i driver da chiamare al Sistema Operativo
            options.AddAdditionalAppiumOption("ms:exprimental-webdriver", true);
            // Avvia l'App e attende 10s
            options.AddAdditionalAppiumOption("ms:waitForAppLaunch", "10");

            // Uniform Resource Indentifier
            var serverUri = new Uri ("http://127.0.0.1:4723/");
            _driver = new WindowsDriver(serverUri, options);
        }

        
        [Test]
        public void Test_verificaTitoloApp() {
            Assert.That(_driver.Title, Is.EqualTo("AppSpeseCorrezione").Or.Contain("LE MIE SPESE"));
        }

        [Test]
        public void Test_Inserimento()
        {
            // Aspettimo tre secondi che l'app sia caricata
            //Thread permette la programmazione parallela
            System.Threading.Thread.Sleep(3000);

            // Nella variabile inserisco l'elemento che ha l'automationId = EntNomeLista
            var inputNome = _driver.FindElement(MobileBy.AccessibilityId("EntNomeLista"));
            // Mettiamo il focus sull'entry
            inputNome.Click();
            // Puliamo l'entry
            inputNome.Clear();
            inputNome.SendKeys("Spesa Aprile");
            System.Threading.Thread.Sleep(3000);

            // Nella variabile inserisco l'elemento che ha l'automationId = EntNomeLista
            inputNome = _driver.FindElement(MobileBy.AccessibilityId("EntDescrizione"));
            // Mettiamo il focus sull'entry
            inputNome.Click();
            // Puliamo l'entry
            inputNome.Clear();
            inputNome.SendKeys("Parmigiano");
            System.Threading.Thread.Sleep(3000);

            // Nella variabile inserisco l'elemento che ha l'automationId = EntNomeLista
            inputNome = _driver.FindElement(MobileBy.AccessibilityId("EntImporto"));
            // Mettiamo il focus sull'entry
            inputNome.Click();
            // Puliamo l'entry
            inputNome.Clear();
            inputNome.SendKeys("1000");
            System.Threading.Thread.Sleep(3000);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit ();
            _driver?.Dispose ();
        }
    }
}