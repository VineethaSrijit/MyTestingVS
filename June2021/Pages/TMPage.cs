using June2021.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace June2021.Pages
{
    class TMPage
    {
        //test - create new Time & Materials page
        public void CreateTM(IWebDriver driver)
        {
            // identify and click on Create New action button
            Wait.WaitForWebElementToExist(driver, "//*[@id='container']/p/a", "XPath", 5);
            IWebElement createNewActionButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewActionButton.Click();

            // identify TypeCode drop down menu and select a value
            Wait.WaitForWebElementToExist(driver, "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span", "XPath", 5);
            IWebElement typeCode = driver.FindElement(By.XPath("//*//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCode.Click();
            Thread.Sleep(2500);
            //Wait.WaitForWebElementToExist(driver, "//*[@id='TypeCode_option_selected']", "XPath", 3);
            IWebElement material = driver.FindElement(By.XPath("//*[@id='TypeCode_option_selected']"));
            material.Click();

            // identify Code textbox and enter valid value other than blank
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("testcode");

            // identify Description textbox and enter value other than blank
            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("testdescription");

            // identify Price per unit textbox and enter numeric value 
            IWebElement pricePerUnit1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            pricePerUnit1.Click();
            IWebElement pricePerUnit2 = driver.FindElement(By.Id("Price"));
            pricePerUnit2.SendKeys("100");

            // identify Save action button and click on it
            IWebElement saveActionButton = driver.FindElement(By.Id("SaveButton"));
            saveActionButton.Click();

            // identify last page button and click on it
            Thread.Sleep(2500);
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[4]/a[4]/span", "XPath", 5);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();

            // check if the test passed
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", "XPath", 10);
            Thread.Sleep(1500);
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(lastRecord.Text.Equals("testcode"), "Test passed, the record has been successfully added to the table");
        }

        //test - edit new Time & Materials page
        public void EditTM(IWebDriver driver)
        {
            // TEST CASE 3 : Check if the user able to edit the record that was added in the previos test case
            // identify last page button and click on it
            Thread.Sleep(2000);
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[4]/a[4]/span", "XPath", 5);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();

            // identify the edit button for the last record and click on it
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //identify the code textbox and edit the values
            Wait.WaitForWebElementToExist(driver, "Code", "Id", 5);
            IWebElement codeEdited = driver.FindElement(By.Id("Code"));
            codeEdited.Clear();
            codeEdited.SendKeys("Edited code");
            Wait.WaitForWebElementToExist(driver, "SaveButton", "Id", 5);
            IWebElement saveActionButton2 = driver.FindElement(By.Id("SaveButton"));
            saveActionButton2.Click();

            // check if the previous record has been edited in the table
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[4]/a[4]", "XPath", 20);
            Thread.Sleep(2500);                                        
            IWebElement lastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton2.Click();
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", "XPath", 30);
            IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(editedRecord.Text == "Edited code", "Test passed, previous test data has been successfully edited");
        }

        //test - delete record from Time & Materials page
        public void DeleteTM(IWebDriver driver)
        {
            // TEST CASE 3 : check if user able to delete the recently added record
            // identify the delete button and click on it
            Thread.Sleep(2500);
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[4]/a[4]/span", "XPath", 5);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();
            Thread.Sleep(1500);
            //Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", "XPath", 5);
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            IAlert deleteAlert = driver.SwitchTo().Alert();
            deleteAlert.Accept();

            //check if the record has been deleted in the table
            Thread.Sleep(1500);
            IWebElement deletedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (deletedRecord.Text != "Edited code") 
            {
                Assert.Pass("Test passed, the previous test data has been successfully deleted");
            }
            else
            {
                Assert.Fail("Test failed, previous test data not deleted!!");
            }
        }
    }
}
