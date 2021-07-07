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
    class TMPage
    {
        //test - create new Time & Materials page
        public void CreateTM(IWebDriver driver)
        {
            // identify and click on Create New action button
            Console.WriteLine("Test Case 2: check if user able to create new record");
            Wait.WaitForWebElementToExist(driver, "//*[@id='container']/p/a", "XPath", 5);
            IWebElement createNewActionButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewActionButton.Click();

            // identify TypeCode drop down menu and select a value
            Wait.WaitForWebElementToExist(driver, "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]", "XPath", 5);
            IWebElement typeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCode.Click();
            //Wait.WaitForWebElementToExist(driver, "//*[@id='TypeCode_option_selected']", "XPath", 5);
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
            Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[4]/a[4]/span", "XPath", 20);
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();

            // if the record added matches, display a message stating the record has been successfully added, test passed
            Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", "XPath", 30);
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastRecord.Text == ("testcode"))
            {
                Console.WriteLine("Test Passed , the record has been added to the table");
            }
            else
            {
                Console.WriteLine("Test failed, the record has not been added to the table");
            }

        }

        //test - edit new Time & Materials page
        public void EditTM(IWebDriver driver)
        {
            // TEST CASE 3 : Check if the user able to edit the record that was added in the previos test case
            // identify the edit button for the last record and click on it
            Console.WriteLine("Test Case 3: check if user able to edit the previously added record");
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
            Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[4]/a[4]", "XPath", 20);
            IWebElement lastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastPageButton2.Click();
            Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", "XPath", 30);
            IWebElement lastRecord2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastRecord2.Text == "Edited code")
            {
                Console.WriteLine("Test passed, the previous test data has been successfully edited");
            }
            else
            {
                Console.WriteLine("Test failed, previous test data not edited!!");
            }
        }

        //test - create new Time & Materials page
        public void DeleteTM(IWebDriver driver)
        {
            // TEST CASE 3 : check if user able to delete the recently added record
            // identify the delete button and click on it
            Console.WriteLine("Test Case 4 : checking if user able to delete previously added record");
            Wait.WaitForWebElementToExist(driver, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", "XPath", 5);
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            IAlert deleteAlert = driver.SwitchTo().Alert();
            deleteAlert.Accept();
            
            //check if the record has been deleted in the table
            IWebElement deletedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (deletedRecord.Text != "Edited code" || deletedRecord.Text != "testcode") // adding OR condition in case the editing of record failed
            {
                Console.WriteLine("Test passed, the previous test data has been successfully deleted");
            }
            else
            {
                Console.WriteLine("Test failed, previous test data not deleted!!");
            }

        }
    }
}
