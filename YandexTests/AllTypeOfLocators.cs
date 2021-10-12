using OpenQA.Selenium;
using System.Collections.Generic;

namespace YandexTests
{
    public class AllTypeOfLocators
    {
        private IWebDriver _driver;

        private const string YandexHomePageSearchFormXpath = "//input[@id = 'text']";
        private const string YandexHomePageSearchFormClassName = "search2__input";
        private const string YandexHomePageLinksTagName = "a";
        private const string YandexHomePageSearchFormCssLocator = "[id*= 'text']";
        private const string YandexHomePageLinkLinkText = "в мире";
        private const string YandexHomePageLinkPartialLinkText = "в мир";
        private const string YandexHomePageBlockOfNewsID = "wd-_topnews-1";
        private const string YandexHomePageBlockOfNewsName = "msid";

        /*
         Были выбраны рандомные элементы на YandexHomePage и написаны к ним разные локаторы
        */

        private IWebElement SearchYandexHomePageFormByXpath => _driver.FindElement(By.XPath(YandexHomePageSearchFormXpath));
        private IWebElement SearchYandexHomePageFormByClassName => _driver.FindElement(By.ClassName(YandexHomePageSearchFormClassName));
        private IList<IWebElement> SearchYandexHomePageLinksByTagName => _driver.FindElements(By.TagName(YandexHomePageLinksTagName));
        private IWebElement SearchYandexHomePageFormByCssLocator => _driver.FindElement(By.XPath(YandexHomePageSearchFormCssLocator));
        private IWebElement SearchYandexHomePageLinkByLinkText => _driver.FindElement(By.LinkText(YandexHomePageLinkLinkText));
        private IWebElement SearchYandexHomePageLinkByPartialLinkText => _driver.FindElement(By.LinkText(YandexHomePageLinkPartialLinkText));
        private IWebElement SearchYandexHomePageLinkByID => _driver.FindElement(By.LinkText(YandexHomePageBlockOfNewsID));
        private IList<IWebElement> SearchYandexHomePageBlockOfNewsNameByName => _driver.FindElements(By.Name(YandexHomePageBlockOfNewsName));
    }
}
