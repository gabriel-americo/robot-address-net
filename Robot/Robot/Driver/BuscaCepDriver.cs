using EasyAutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Data;

namespace Robot.Driver
{
    public class BuscaCepDriver : Web
    {
        public BuscaCepDriver() 
        {
           this.StartBrowser();
        }

        public EasyReturn.Web StartBrowser(TypeDriver typeDriver = TypeDriver.GoogleChorme, string pathCache = null)
        {
            try
            {
                switch (typeDriver)
                {
                    case TypeDriver.GoogleChorme:
                        {
                            var sc = ChromeDriverService.CreateDefaultService();
                            sc.HideCommandPromptWindow = true;
                            ChromeOptions c = new ChromeOptions();
                            c.AddArgument("--start-maximized");
                            c.AddArgument("--user-data-dir=~/.config/google-chrome");
                            c.AddArgument("--headless");
                            c.AddArgument("--no-sandbox");
                            c.AddArgument("--disable-gpu");
                            c.AddArgument("--ddisable-dev-shm-usage");
                            driver = new ChromeDriver(sc, c);
                            break;
                        }
                }

                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = true
                };
            }
            catch (Exception ex)
            {
                return new EasyReturn.Web
                {
                    driver = driver,
                    Sucesso = false,
                    Error = ex.Message.ToString()
                };
            }
        }

        public void BuscarCep(AddressModel address)
        {
            Navigate("https://buscacepinter.correios.com.br/app/endereco/index.php");

            AssignValue(TypeElement.Id, "endereco", address.CEP).element.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            var result = GetTableData(TypeElement.Id, "resultado-DNEC");

            foreach (DataRow row in result.table.Rows)
            {
                address.Logradouro = row[0].ToString();
                address.Bairro = row[1].ToString();
                address.UF = row[2].ToString();
            }
        }
    }
}
