using June2021.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace June2021.Pages
{
    class HomePage
    {
        //functions to navigate to the Time and Materials page
        public void GoToTMPage(IWebDriver driver)
        {
            Wait.WaitForWebElementToExist(driver, "/html/body/div[3]/div/div/ul/li[5]/a", "XPath", 5);
            IWebElement administrationDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropDown.Click();
            Wait.WaitForWebElementToExist(driver, "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", "XPath", 5);
            IWebElement timeMaterials = administrationDropDown.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterials.Click();
        }
    }
}
