using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2021.Pages
{
    class LoginPage
    {
        //functions that allow users to login successfully to TurnUp portal
        public void LoginActions(IWebDriver driver)
        {
            
            //TEST CASE 1 - check if user able to login successfully with uname,password : hari,123123
            // open chrome browser
            Console.WriteLine("Test Case 1 : check if user able to login successfully with uname,password : hari,123123");
            driver.Manage().Window.Maximize();

            // launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // identify username textbox and enter valid username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            // identify password textbox and enter valid password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // identify login action button and click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();
        }
    }
}
