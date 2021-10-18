using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using YandexTests.HomePage;
using System;

namespace YandexTests.TestClass
{
    public class BaseTest
    {
        protected IWebDriver? _driver;
        protected YandexHomePage? _homePage;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _homePage = new YandexHomePage(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void CloseDriver()
        {
            _driver?.Quit();
        }
    }
}
