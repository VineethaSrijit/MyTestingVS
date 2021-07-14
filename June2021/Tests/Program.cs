using June2021.Pages;
using June2021.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
namespace June2021
{
    [TestFixture]
    class Program : CommonDriver
    {
            [SetUp]
            public void LoginSteps()
            {
                driver = new ChromeDriver(@"E:\Industry Connect\Automation Testing\Visual Studio\June 2021\June2021\");
                //page object for login page
                LoginPage loginObj = new LoginPage();
                loginObj.LoginActions(driver);

                //page object for home page
                HomePage homeObj = new HomePage();
                homeObj.GoToTMPage(driver);
            }

            [Test]
            public void CreateTMTest()
            {
                TMPage tmObj = new TMPage();
                tmObj.CreateTM(driver);
            }

            [Test]
            public void EditTMTest()
            {
                TMPage tmObj = new TMPage();
                tmObj.EditTM(driver);
            }

            [Test]
            public void DeleteTMTest()
            {
                TMPage tmObj = new TMPage();
                tmObj.DeleteTM(driver);
            }

            [TearDown]
            public void CloseTestRun()
            {
            driver.Quit();



            }
    }
}
