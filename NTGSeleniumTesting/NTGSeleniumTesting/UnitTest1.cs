using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NTGSeleniumTesting
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:3001/customer-details-page";
            Console.WriteLine("Opened Page " + driver.Url);
        }

        //====================================First name=========================================
        [Test]
        public void Parametrized_test_invalid_firstName()
        {
            //testing invalid values
            //alert: error in first name
            string[] testValues = { "a", "aa123", "aa*aaa", "-aa", "aa-", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabb", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbb" };

            driver.FindElement(By.Id("lastName")).SendKeys("AAA");
            driver.FindElement(By.Id("address")).SendKeys("AAA");
            driver.FindElement(By.Id("postalCode")).SendKeys("4000");
            driver.FindElement(By.Id("city")).SendKeys("Roskilde");
            driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
            Console.WriteLine("Entered values");

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("firstName")).SendKeys(item);

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                IAlert alert1 = driver.SwitchTo().Alert();
                Console.WriteLine("Switched to alert");
                Assert.AreEqual(alert1.Text, "error in first name");
                alert1.Accept();
                driver.FindElement(By.Id("firstName")).Clear();
            }

            //testing double dash in first name
            //aler: repeated dash in first name
            driver.FindElement(By.Id("firstName")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert2 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert2.Text, "repeated dash in first name");
            alert2.Accept();
            driver.FindElement(By.Id("firstName")).Clear();

            //testing empty object
            //alert: empty first name

           // driver.FindElement(By.Id("firstName")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert3 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert3.Text, "empty first name");
            alert3.Accept();
        }

        [Test]
        public void parametrized_test_valid_firstName()
        {
            string[] testValues = {"aa", "aaa", "aaaø", "aaa-aaa", "aaa-aaa-aaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("firstName")).SendKeys(item);
                driver.FindElement(By.Id("lastName")).SendKeys("AAA");
                driver.FindElement(By.Id("address")).SendKeys("AAA");
                driver.FindElement(By.Id("postalCode")).SendKeys("4000");
                driver.FindElement(By.Id("city")).SendKeys("Roskilde");
                driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
                Console.WriteLine("Entered values");

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                Assert.AreEqual(driver.Url, "http://localhost:3001/delivery-details-page");
                driver.Url = "http://localhost:3001/customer-details-page";
                Console.WriteLine("Opened Page " + driver.Url);
            }

        }

        //====================================Last name=========================================
        [Test]
        public void Parametrized_test_invalid_LastName()
        {
            //testing invalid values
            //alert: error in last name
            string[] testValues = { "a", "aa123", "aa*aaa", "-aa", "aa-", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabb", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbb" };

            driver.FindElement(By.Id("firstName")).SendKeys("AAA");
            driver.FindElement(By.Id("address")).SendKeys("AAA");
            driver.FindElement(By.Id("postalCode")).SendKeys("4000");
            driver.FindElement(By.Id("city")).SendKeys("Roskilde");
            driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
            Console.WriteLine("Entered values");

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("lastName")).SendKeys(item);

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                IAlert alert1 = driver.SwitchTo().Alert();
                Console.WriteLine("Switched to alert");
                Assert.AreEqual(alert1.Text, "error in last name");
                alert1.Accept();
                driver.FindElement(By.Id("lastName")).Clear();
            }

            //testing double dash in last name
            //aler: repeated dash in last name
            driver.FindElement(By.Id("lastName")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert2 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert2.Text, "repeated dash in last name");
            alert2.Accept();
            driver.FindElement(By.Id("lastName")).Clear();

            //testing empty object
            //alert: empty first name

            // driver.FindElement(By.Id("lastName")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert3 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert3.Text, "empty last name");
            alert3.Accept();
        }

        [Test]
        public void parametrized_test_valid_LastName()
        {
            string[] testValues = { "aa", "aaa", "aaaø", "aaa-aaa", "aaa-aaa-aaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("lastName")).SendKeys(item);
                driver.FindElement(By.Id("firstName")).SendKeys("AAA");
                driver.FindElement(By.Id("address")).SendKeys("AAA");
                driver.FindElement(By.Id("postalCode")).SendKeys("4000");
                driver.FindElement(By.Id("city")).SendKeys("Roskilde");
                driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
                Console.WriteLine("Entered values");

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                Assert.AreEqual(driver.Url, "http://localhost:3001/delivery-details-page");
                driver.Url = "http://localhost:3001/customer-details-page";
                Console.WriteLine("Opened Page " + driver.Url);
            }

        }

        //====================================Address=========================================
        [Test]
        public void Parametrized_test_invalid_Address()
        {
            //testing invalid values
            //alert: error in address
            string[] testValues = { "a", "aa*aaa", "-aa", "aa-", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabb", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbb" };

            driver.FindElement(By.Id("firstName")).SendKeys("AAA");
            driver.FindElement(By.Id("lastName")).SendKeys("AAA");
            driver.FindElement(By.Id("postalCode")).SendKeys("4000");
            driver.FindElement(By.Id("city")).SendKeys("AAA");
            driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
            Console.WriteLine("Entered values");

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("address")).SendKeys(item);

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                IAlert alert1 = driver.SwitchTo().Alert();
                Console.WriteLine("Switched to alert");
                Assert.AreEqual(alert1.Text, "error in address");
                alert1.Accept();
                driver.FindElement(By.Id("address")).Clear();
            }

            //testing double dash in address
            //aler: repeated dash in address
            driver.FindElement(By.Id("address")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert2 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert2.Text, "repeated dash in address");
            alert2.Accept();
            driver.FindElement(By.Id("address")).Clear();

            //testing empty object
            //alert: empty address

            // driver.FindElement(By.Id("address")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert3 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert3.Text, "empty address");
            alert3.Accept();
        }

        [Test]
        public void parametrized_test_valid_address()
        {
            string[] testValues = { "aa", "aaa", "aaaø", "aaa-aaa", "aaa-aaa-aaa", "aa123", "aaa-aaa,1.", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("address")).SendKeys(item);
                driver.FindElement(By.Id("firstName")).SendKeys("AAA");
                driver.FindElement(By.Id("lastName")).SendKeys("AAA");
                driver.FindElement(By.Id("postalCode")).SendKeys("4000");
                driver.FindElement(By.Id("city")).SendKeys("AAA");
                driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
                Console.WriteLine("Entered values");

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                Assert.AreEqual(driver.Url, "http://localhost:3001/delivery-details-page");
                driver.Url = "http://localhost:3001/customer-details-page";
                Console.WriteLine("Opened Page " + driver.Url);
            }

        }

        //====================================Postal Code=========================================
        [Test]
        public void Parametrized_test_invalid_postalCode()
        {
            //testing invalid values
            //alert: error in postal code
            string[] testValues = { "0", "1", "500", "1299", "1300", "9991", "9992", "10000", "400a"};

            driver.FindElement(By.Id("firstName")).SendKeys("AAA");
            driver.FindElement(By.Id("lastName")).SendKeys("AAA");
            driver.FindElement(By.Id("address")).SendKeys("AAA");
            driver.FindElement(By.Id("city")).SendKeys("Roskilde");
            driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
            Console.WriteLine("Entered values");

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("postalCode")).SendKeys(item);

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                IAlert alert1 = driver.SwitchTo().Alert();
                Console.WriteLine("Switched to alert");
                Assert.AreEqual(alert1.Text, "error in postal code");
                alert1.Accept();
                driver.FindElement(By.Id("postalCode")).Clear();
            }

            //testing empty object
            //alert: empty postal code

            // driver.FindElement(By.Id("postalCode")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert2 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert2.Text, "empty postal code");
            alert2.Accept();
        }

        [Test]
        public void parametrized_test_valid_postalCode()
        {
            string[] testValues = {  "1301", "1302", "5000", "9989", "9990" };

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("postalCode")).SendKeys(item);
                driver.FindElement(By.Id("firstName")).SendKeys("AAA");
                driver.FindElement(By.Id("lastName")).SendKeys("AAA");
                driver.FindElement(By.Id("address")).SendKeys("AAA");
                driver.FindElement(By.Id("city")).SendKeys("Roskilde");
                driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
                Console.WriteLine("Entered values");

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                Assert.AreEqual(driver.Url, "http://localhost:3001/delivery-details-page");
                driver.Url = "http://localhost:3001/customer-details-page";
                Console.WriteLine("Opened Page " + driver.Url);
            }

        }


        //====================================City=========================================
        [Test]
        public void Parametrized_test_invalid_City()
        {
            //testing invalid values
            //alert: error in city
            string[] testValues = { "a", "aa123", "aa*aaa", "-aa", "aa-", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabb", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbb" };

            driver.FindElement(By.Id("firstName")).SendKeys("AAA");
            driver.FindElement(By.Id("lastName")).SendKeys("AAA");
            driver.FindElement(By.Id("address")).SendKeys("AAA");
            driver.FindElement(By.Id("postalCode")).SendKeys("4000");
            driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
            Console.WriteLine("Entered values");

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("city")).SendKeys(item);

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                IAlert alert1 = driver.SwitchTo().Alert();
                Console.WriteLine("Switched to alert");
                Assert.AreEqual(alert1.Text, "error in city");
                alert1.Accept();
                driver.FindElement(By.Id("city")).Clear();
            }

            //testing double dash in city
            //aler: repeated dash in city
            driver.FindElement(By.Id("city")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert2 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert2.Text, "repeated dash in city");
            alert2.Accept();
            driver.FindElement(By.Id("city")).Clear();

            //testing empty object
            //alert: empty first name

            // driver.FindElement(By.Id("city")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert3 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert3.Text, "empty city");
            alert3.Accept();
        }

        [Test]
        public void parametrized_test_valid_city()
        {
            string[] testValues = { "aa", "aaa", "aaaø", "aaa-aaa", "aaa-aaa-aaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" };

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("city")).SendKeys(item);
                driver.FindElement(By.Id("firstName")).SendKeys("AAA");
                driver.FindElement(By.Id("lastName")).SendKeys("AAA");
                driver.FindElement(By.Id("address")).SendKeys("AAA");
                driver.FindElement(By.Id("postalCode")).SendKeys("4000");
                driver.FindElement(By.Id("phoneNumber")).SendKeys("12345678");
                Console.WriteLine("Entered values");

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                Assert.AreEqual(driver.Url, "http://localhost:3001/delivery-details-page");
                driver.Url = "http://localhost:3001/customer-details-page";
                Console.WriteLine("Opened Page " + driver.Url);
            }

        }

        //====================================Phone Number=========================================
        [Test]
        public void Parametrized_test_invalid_phoneNumber()
        {
            //testing invalid values
            //alert: error in phone number
            string[] testValues = { "1234", "1234567", "1234567a", "123456789", "12345678910"};

            driver.FindElement(By.Id("firstName")).SendKeys("AAA");
            driver.FindElement(By.Id("lastName")).SendKeys("AAA");
            driver.FindElement(By.Id("address")).SendKeys("AAA");
            driver.FindElement(By.Id("city")).SendKeys("Roskilde");
            driver.FindElement(By.Id("postalCode")).SendKeys("4000");
            Console.WriteLine("Entered values");

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("phoneNumber")).SendKeys(item);

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                IAlert alert1 = driver.SwitchTo().Alert();
                Console.WriteLine("Switched to alert");
                Assert.AreEqual(alert1.Text, "error in phone number");
                alert1.Accept();
                driver.FindElement(By.Id("phoneNumber")).Clear();
            }

            //testing empty object
            //alert: empty phone number

            // driver.FindElement(By.Id("phoneNumber")).SendKeys("aaa--aaa");

            driver.FindElement(By.Id("confirmButton")).Click();
            Console.WriteLine("Button clicked");

            IAlert alert2 = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.AreEqual(alert2.Text, "empty phone number");
            alert2.Accept();
        }

        [Test]
        public void parametrized_test_valid_phoneNumber()
        {
            string[] testValues = { "12345678" };

            foreach (var item in testValues)
            {
                driver.FindElement(By.Id("phoneNumber")).SendKeys(item);
                driver.FindElement(By.Id("firstName")).SendKeys("AAA");
                driver.FindElement(By.Id("lastName")).SendKeys("AAA");
                driver.FindElement(By.Id("address")).SendKeys("AAA");
                driver.FindElement(By.Id("city")).SendKeys("Roskilde");
                driver.FindElement(By.Id("postalCode")).SendKeys("4000");
                Console.WriteLine("Entered values");

                driver.FindElement(By.Id("confirmButton")).Click();
                Console.WriteLine("Button clicked");

                Assert.AreEqual(driver.Url, "http://localhost:3001/delivery-details-page");
                driver.Url = "http://localhost:3001/customer-details-page";
                Console.WriteLine("Opened Page " + driver.Url);
            }

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}