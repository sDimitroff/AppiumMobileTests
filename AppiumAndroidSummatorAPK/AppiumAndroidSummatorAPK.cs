using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumAndroidSummatorAPK
{
    public class AppiumAndroidSummatorAPK
    {
        private const string appiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\com.example.androidappsummator.apk";
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;
       

        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions () { PlatformName = "Android"};
            options.AddAdditionalCapability("app", appLocation);

            this.driver = new AndroidDriver<AndroidElement> (new Uri(appiumUrl), options);
            
            
        }

        [OneTimeTearDown]  
        public void TearDown () 
        {
        driver.Quit ();
        
        }

        [Test]
        public void CalculateTwoPositiveNumbers()
        {
            //Arrange
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInput.Clear();
            secondInput.Clear();

            //Act
            firstInput.SendKeys("5");
            secondInput.SendKeys("2");
            calcButton.Click();

            var resultFieldNumber = resultField.Text;
           

            //Assertion
            Assert.That(resultFieldNumber, Is.EqualTo("7"));

        }

        [Test]
        public void CalculateInvalidValues()
        {
            //Arrange
            var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInput.Clear();
            secondInput.Clear();
           
            //Act
            firstInput.SendKeys("5");
            secondInput.SendKeys("number");
            calcButton.Click();

            var resultFieldNumber = resultField.Text;


            //Assertion
            Assert.That(resultFieldNumber, Is.EqualTo("error"));

        }
    }
}