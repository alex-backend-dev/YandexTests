using NUnit.Framework;
using YandexTests.TestClass;

namespace YandexTests
{
    [TestFixture]
    public class YandexTests : BaseTest
    {
        [Test]
        public void YandexLoginTest()
        {
            _homePage?.GoToYandexHomePage();
            _homePage?.YandexLog();

            Assert.IsTrue(_homePage?.YandexCorrectLoginByUrl(), $"URL is incorrect - test received {_driver?.Url}");
            Assert.IsTrue(_homePage?.YandexCorrectLoginByTitle(), $"Title is incorrect - test received {_driver?.Title}");
        }
    }
}