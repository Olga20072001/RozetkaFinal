using EPAM_LAb_Rozetka.Models;
using EPAM_LAb_Rozetka.PageObject.Pages;
using EPAM_LAb_Rozetka.Utils;
using NUnit.Framework;
using System;

namespace EPAM_LAb_Rozetka.Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    public class CheckSumInTheCartTest:BaseTest
    {

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.TestData))]
        public void CheckSumInTheCart(Product product)
        {
            logger.Info("'CheckSumInTheCart' test start");
            logger.Info($"Search Product: { product.searchProduct}, Brand: {product.brand}, Product Index {product.productIndex}, Price: {product.price}");
            try
            {
                HomePage homePage = new HomePage(driver);
                homePage.SearchByKeyword(product.searchProduct);

                SearchResultPage searchResultPage = new SearchResultPage(driver);
                searchResultPage.SearchBrandName(product.brand);
                searchResultPage.OrderBy();
                searchResultPage.getItemByIndex(product.productIndex);

                ProductPage productPage = new ProductPage(driver);
                productPage.ClickBuyButton();
                productPage.ClickCartButton();

                CartPage cartPage = new CartPage(driver);

                Assert.Greater(cartPage.GetTotalSumFromPage(), Convert.ToDouble(product.price));

                logger.Info("Test finished");
            }
            catch(Exception e)
            {
                logger.Error(e.Message.ToString());
            }
        }
    }
}
