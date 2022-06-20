﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EPAM_LAb_Rozetka.PageObject
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        protected WebDriverWait wait;
        protected readonly long timeToWait = 30;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }

        public void WaitUntilElementExists(By element)
        {
            Thread.Sleep(2000);
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait)).Until(ExpectedConditions.ElementExists(element));
        }
    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, long timeToWait)
        {
            if (timeToWait > 0)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                    return wait.Until(drv => drv.FindElement(by));
                }
                catch (StaleElementReferenceException)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                    return wait.Until(drv => drv.FindElement(by));
                }
            }
            return driver.FindElement(by);
        }
        public static IList<IWebElement> FindElements(this IWebDriver driver, By by, long timeToWait)
        {
            if (timeToWait > 0)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                    return wait.Until(drv => drv.FindElements(by));
                }
                catch (StaleElementReferenceException)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                    return wait.Until(drv => drv.FindElements(by));
                }
            }
            return driver.FindElements(by);
        }
    }
}
