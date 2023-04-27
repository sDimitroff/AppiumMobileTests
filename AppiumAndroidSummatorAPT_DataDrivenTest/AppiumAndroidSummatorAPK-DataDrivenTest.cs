using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;

namespace AppiumAndroidSummatorAPK
{
    internal class AppiumAndroidSummatorAPK_DataDrivenTest
    {

        private const string appiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\com.example.androidappsummator.apk";
        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;


        [OneTimeSetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);

            //Use this option to run physical device when ADB Emulator is not turned off
           //options.AddAdditionalCapability("deviceName", "(FF89ZJ8HD");
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumUrl), options);


        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();

        }

        [TestCase("5","2","7")]
        [TestCase("5","3","8")]
        [TestCase("5","text","error")]
        public void CalculateTwoPositiveNumbers(string firstInput, string secondInput, string resultFieldNumber)
        {
            //Arrange
            var firstInputNumber = driver.FindElementById("com.example.androidappsummator:id/editText1");
            var secondInputNumber = driver.FindElementById("com.example.androidappsummator:id/editText2");
            var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

            firstInputNumber.Clear();
            secondInputNumber.Clear();

            //Act
            firstInputNumber.SendKeys(firstInput);
            secondInputNumber.SendKeys(secondInput);
            calcButton.Click();

            var result = resultField.Text;


            //Assertion
            Assert.That(resultFieldNumber, Is.EqualTo(result));

        }


    }
}
