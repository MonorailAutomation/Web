﻿using System;
using OpenQA.Selenium;

namespace monorail_web_v3.Commons
{
    public static class Waits
    {
        public static Func<IWebDriver, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return driver => element is {Displayed: true, Enabled: true} ? element : null;
        }

        public static Func<IWebDriver, IWebElement> ElementToBeVisible(IWebElement element)
        {
            return driver => element is {Displayed: true} ? element : null;
        }
    }
}