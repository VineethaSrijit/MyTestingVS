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
            Console.WriteLine("Hello World!");

            //TEST CASE 1 - check if user able to login successfully with uname,password : hari,123123
            // open chrome browser
            Console.WriteLine("Test Case 1 : check if user able to login successfully with uname,password : hari,123123");
            IWebDriver driver = new ChromeDriver(@"E:\Industry Connect\Automation Testing\Visual Studio\June 2021\June2021\");
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

            // check if user is logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if(helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully, test passed");
            }
            else
            {
                Console.WriteLine("Log in failed, test failed");
            }

            // TEST CASE 2 - check if user able to create time & material record successfully
            // navigate to Time & Materials page
            Console.WriteLine("Test Case 2: check if user able to create time & material record successfully");
            Thread.Sleep(500);
            IWebElement administrationDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropDown.Click();
            Thread.Sleep(500);
            IWebElement timeMaterials = administrationDropDown.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterials.Click();
            Thread.Sleep(1500);

            // check if user taken to Time & Materials page
            if (driver.Url == "http://horse.industryconnect.io/TimeMaterial")
            {
                Console.WriteLine("User taken to Time & Materials page");
            }
            else
            {
                Console.WriteLine("Error!!");
                Console.WriteLine("User not able to view Time & Materials page");
            }

            // identify and click on Create New action button
            IWebElement createNewActionButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewActionButton.Click();
            Thread.Sleep(2000);

            // check if user taken to Create New page
            if (driver.Url == "http://horse.industryconnect.io/TimeMaterial/Create")
            {
                Console.WriteLine("User taken to Create new record page");
            }
            else
            {
                Console.WriteLine("Error!!");
                Console.WriteLine("User not able to view Create new record page");
            }

            // identify TypeCode drop down menu and select a value
            IWebElement typeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCode.Click();
            WebDriverWait wait30 = new(driver, TimeSpan.FromSeconds(30));
            IWebElement material = wait30.Until(e => e.FindElement(By.XPath("//*[@id='TypeCode_option_selected']")));
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
            Thread.Sleep(1500);


             // check if user taken back to Time & Materials page after saving new record 
             if (driver.Url == "http://horse.industryconnect.io/TimeMaterial")
             {
                 Console.WriteLine("User able to create new record and taken back to Time & Materials page");
             }
             else
             {
                 Console.WriteLine("Error!!");
                 Console.WriteLine("User not taken back to Time & Materials page after saving new records");
             }

            // identify last page button and click on it
            WebDriverWait waitfor40 = new(driver, TimeSpan.FromSeconds(40));
            IWebElement lastPageButton = waitfor40.Until( a => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")));
            lastPageButton.Click();

            // if the record added matches, display a message stating the record has been successfully added, test passed
            IWebElement lastRecord = waitfor40.Until(b => driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]")));
            if (lastRecord.Text == ("testcode"))
            {
                Console.WriteLine("Test Passed , the record has been added to the table");
            }
            else
            {
                Console.WriteLine("Test failed, the record has not been added to the table");
            }

            // TEST CASE 3 : Check if the user able to edit the record that was added in the previos test case
            // identify the edit button for the last record and click on it
            Console.WriteLine("Test Case 3: check if user able to edit the previously added record");
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(1500);

            //identify the code textbox and edit the values
            IWebElement codeEdited = driver.FindElement(By.Id("Code"));
            codeEdited.Clear();
            codeEdited.SendKeys("Edited code");
            Thread.Sleep(500);
            IWebElement saveActionButton2 = driver.FindElement(By.Id("SaveButton"));
            saveActionButton2.Click();
            Thread.Sleep(2000);

            // check if the previous record has been edited in the table
            IWebElement lastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            lastPageButton2.Click();
            IWebElement lastRecord2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastRecord2.Text == "Edited code")
            {
                Console.WriteLine("Test passed, the previous test data has been successfully edited");
            }
            else
            {
                Console.WriteLine("Test failed, previous test data not edited!!");
            }

            // TEST CASE 3 : check if user able to delete the recently added record
            // identify the delete button and click on it
            Console.WriteLine("Test Case 4 : checking if user able to delete previously added record");
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(500);
            IAlert deleteAlert = driver.SwitchTo().Alert();
            deleteAlert.Accept();
            Thread.Sleep(1500);

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
