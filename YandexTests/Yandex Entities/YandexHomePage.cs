using OpenQA.Selenium;
using YandexTests.Yandex_Entity;
using System;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace YandexTests.HomePage
{
    public class YandexHomePage
    {
        private IWebDriver _driver;

        private IWebElement SearchResultEnter => _driver.FindElement(By.XPath(YandexHomePageSettings.EnterFormXpath));
        private IWebElement SearchResultLogin => _driver.FindElement(By.CssSelector(YandexHomePageSettings.LoginFormSelector));
        private IWebElement SearchResultPassword => _driver.FindElement(By.CssSelector(YandexHomePageSettings.PasswordFormSelector));

        public YandexHomePage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        public void GoToYandexHomePage()
        {
            _driver.Navigate().GoToUrl(YandexHomePageSettings.YandexByHomePageUrl);
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
            EnterLoginData(YandexHomePageSettings.LoginYandexCredentials);
            EnterPasswordData(YandexHomePageSettings.PasswordYandexCredentials);
            IsElementVisible();
        }

        public bool YandexCorrectLoginByUrl() => _driver.Url.Contains(YandexHomePageSettings.YandexByHomePageUrl);

        public bool YandexCorrectLoginByTitle() => _driver.Title.Contains(YandexHomePageSettings.YandexHomePageTitle);

        /*
         Чтобы методы YandexCorrectLoginByUrl() и YandexCorrectLoginByTitle() сработали, создаю Waiter с явным ожиданием условия 
         появления одного из элементов страницы куда нас возвращает при вводе валидных данных. В данном случае, нас возвращает
         обратно на YandexHomePage, соответственно, обращаюсь к Xpath формы поиска, чтобы дать определенное время для прогрузки страницы
         и отработки методов, указанных выше.
        */
        public void IsElementVisible()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(YandexHomePageSettings.YandexHomePageSearchFormXpath)));
        }
    }
}
