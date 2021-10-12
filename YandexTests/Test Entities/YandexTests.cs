using NUnit.Framework;
using YandexTests.TestClass;

namespace YandexTests
{
    public class YandexTests : TestSettings
    {
        [Test]
        public void YandexLogin()
        {
            _homePage?.GoToYandexHomePage();
            _homePage?.YandexLog();
            
            Assert.IsTrue(_homePage?.YandexCorrectLoginByUrl());
            Assert.IsTrue(_homePage?.YandexCorrectLoginByTitle());
        }
    }
}