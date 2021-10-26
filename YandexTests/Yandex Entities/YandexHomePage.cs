using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace YandexTests.HomePage
{
    public class YandexHomePage
    {
        private const string EnterFormXpath = "//div[contains(text(),'Войти')]";
        private const string LoginFormSelector = "#passp-field-login";
        private const string PasswordFormSelector = "#passp-field-passwd";
        private const string YandexHomePageSearchFormXpath = "//input[@id = 'text']";

        private const string LoginYandexCredentials = "ulyanitskyaleksandar";
        private const string PasswordYandexCredentials = "110411sss";
        private const string YandexByHomePageUrl = "https://yandex.by/";
        private const string YandexHomePageTitle = "Яндекс";

        private IWebDriver _driver;

        private IWebElement SearchResultEnter => _driver.FindElement(By.XPath(EnterFormXpath));
        private IWebElement SearchResultLogin => _driver.FindElement(By.CssSelector(LoginFormSelector));
        private IWebElement SearchResultPassword => _driver.FindElement(By.CssSelector(PasswordFormSelector));

        public YandexHomePage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        public void GoToYandexHomePage()
        {
            _driver.Navigate().GoToUrl(YandexByHomePageUrl);
        }

        public void ClickOnEnterForm()
        {
            SearchResultEnter.Click();
        }

        public void EnterLoginData(string data)
        {
            SearchResultLogin.SendKeys(data);
            SearchResultLogin.SendKeys(Keys.Enter);
        }

        public void EnterPasswordData(string data)
        {
            SearchResultPassword.SendKeys(data);
            SearchResultPassword.SendKeys(Keys.Enter);
        }

        public void YandexLog()
        {
            ClickOnEnterForm();
            EnterLoginData(LoginYandexCredentials);
            EnterPasswordData(PasswordYandexCredentials);
            IsElementVisible();
        }

        public bool YandexCorrectLoginByUrl() => _driver.Url.Contains(YandexByHomePageUrl);

        public bool YandexCorrectLoginByTitle() => _driver.Title.Contains(YandexHomePageTitle);

        /*
         Чтобы методы YandexCorrectLoginByUrl() и YandexCorrectLoginByTitle() сработали, создаю Waiter с явным ожиданием условия 
         появления одного из элементов страницы куда нас возвращает при вводе валидных данных. В данном случае, нас возвращает
         обратно на YandexHomePage, соответственно, обращаюсь к Xpath формы поиска, чтобы дать определенное время для прогрузки страницы
         и отработки методов, указанных выше.
        */
        public void IsElementVisible()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(YandexHomePageSearchFormXpath)));
        }
    }
}
