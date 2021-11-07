using FluentAssertions;
using NUnit.Allure.Steps;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static monorail_web_v3.Commons.Waits;
using static monorail_web_v3.Test.Scripts.FunctionalTesting;

namespace monorail_web_v3.PageObjects.Commons
{
    public class MainScreen
    {
        private const string TermsOfServiceLink = "/disclosures/terms-of-use/Web";
        private const string PrivacyPolicyLink = "/disclosures/privacy-policy";
        private const string RatesLimitsFeesLink = "/rates-limits-fees";

        private const string InstagramLink = "https://www.instagram.com/vimvestapp/";
        private const string FacebookLink = "https://www.facebook.com/Vimvest/";
        private const string TwitterLink = "https://twitter.com/vimvest";
        private const string PinterestLink = "https://www.pinterest.com/vimvest/";

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer__socialMedia']//a[2]")]
        private IWebElement _facebookLink;

        [FindsBy(How = How.XPath,
            Using = "//button[@class='vim-header__sidenav-toggle']/svg-icon[contains(@src, 'menu')]")]
        private IWebElement _hamburgerMenu;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer__socialMedia']//a[1]")]
        private IWebElement _instagramLink;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Invest')]")]
        private IWebElement _investNavItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Money')]")]
        private IWebElement _moneyNavItem;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-footer']//svg-icon[contains(@src, 'monorail-logo')]")]
        private IWebElement _monorailLogo;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer__socialMedia']//a[4]")]
        private IWebElement _pinterestLink;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-footer']//a[contains(text(), 'Privacy Policy')]")]
        private IWebElement _privacyPolicyLink;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-footer']//a[contains(text(), 'Rates, Limits, Fees')]")]
        private IWebElement _ratesLimitsFeesLink;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-footer']//a[contains(text(), 'Terms of Service')]")]
        private IWebElement _termsOfServiceLink;

        [FindsBy(How = How.XPath, Using = "//div[@class='vim-footer__socialMedia']//a[3]")]
        private IWebElement _twitterLink;

        [FindsBy(How = How.XPath,
            Using = "//div[@class='vim-header']//span[contains(text(), 'Wishlist')]")]
        private IWebElement _wishlistNavItem;

        public MainScreen(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [AllureStep("Click '{0}'")]
        public MainScreen Click(IWebElement item)
        {
            Wait.Until(ElementToBeVisible(item));
            item.Click();
            return this;
        }

        [AllureStep("Expand side menu")]
        public MainScreen ExpandSideMenu()
        {
            Wait.Until(ElementToBeClickable(_hamburgerMenu));
            _hamburgerMenu.Click();
            return this;
        }

        [AllureStep("Click 'Invest'")]
        public MainScreen ClickInvest()
        {
            Wait.Until(ElementToBeClickable(_investNavItem));
            _investNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Money'")]
        public MainScreen ClickMoney()
        {
            Wait.Until(ElementToBeClickable(_moneyNavItem));
            _moneyNavItem.Click();
            return this;
        }

        [AllureStep("Click 'Wishlist'")]
        public MainScreen ClickWishlist()
        {
            Wait.Until(ElementToBeClickable(_wishlistNavItem));
            _wishlistNavItem.Click();
            return this;
        }

        [AllureStep("Check Main Screen")]
        public MainScreen CheckMainScreen()
        {
            Wait.Until(ElementToBeVisible(_wishlistNavItem));
            Wait.Until(ElementToBeVisible(_moneyNavItem));
            Wait.Until(ElementToBeVisible(_investNavItem));
            Wait.Until(ElementToBeVisible(_hamburgerMenu));
            Wait.Until(ElementToBeVisible(_monorailLogo));
            Wait.Until(ElementToBeVisible(_termsOfServiceLink));
            Wait.Until(ElementToBeVisible(_privacyPolicyLink));
            Wait.Until(ElementToBeVisible(_ratesLimitsFeesLink));
            Wait.Until(ElementToBeVisible(_instagramLink));
            Wait.Until(ElementToBeVisible(_facebookLink));
            Wait.Until(ElementToBeVisible(_twitterLink));
            Wait.Until(ElementToBeVisible(_pinterestLink));

            _termsOfServiceLink.GetAttribute("href").Should().Contain(TermsOfServiceLink);
            _privacyPolicyLink.GetAttribute("href").Should().Contain(PrivacyPolicyLink);
            _ratesLimitsFeesLink.GetAttribute("href").Should().Contain(RatesLimitsFeesLink);

            _instagramLink.GetAttribute("href").Should().Be(InstagramLink);
            _facebookLink.GetAttribute("href").Should().Be(FacebookLink);
            _twitterLink.GetAttribute("href").Should().Be(TwitterLink);
            _pinterestLink.GetAttribute("href").Should().Be(PinterestLink);
            return this;
        }
    }
}