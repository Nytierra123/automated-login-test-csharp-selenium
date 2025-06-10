using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.ClassName("radius")).Click();

            System.Threading.Thread.Sleep(2000); // Wait for the page to load

            if (driver.Url.Contains("/secure"))
                Console.WriteLine("✅ Login Test Passed.");
            else
                Console.WriteLine("❌ Login Test Failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❗ Error: " + ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}

