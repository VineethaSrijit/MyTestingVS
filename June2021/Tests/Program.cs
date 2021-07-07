using June2021.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace June2021
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"E:\Industry Connect\Automation Testing\Visual Studio\June 2021\June2021\");

            //page object for login page
            LoginPage loginObj = new LoginPage();
            loginObj.LoginActions(driver);

            //page object for home page
            HomePage homeObj = new HomePage();
            homeObj.GoToTMPage(driver);

            //page object for TM page
            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
            tmObj.EditTM(driver);
            tmObj.DeleteTM(driver);

        }
    }
}
