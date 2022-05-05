using EPAM_LAb_Rozetka.BusinessObject;
using EPAM_LAb_Rozetka.Models;
using EPAM_LAb_Rozetka.Utils;
using NUnit.Framework;
using System;

namespace EPAM_LAb_Rozetka.Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    public class CheckSumInTheCartTest:BaseTest
    {

        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetData))]
        public void CheckSumInTheCart(Product product)
        {
            logger.Info("'CheckSumInTheCart' test start");
            logger.Info($"Search Product: { product.searchProduct}, Brand: {product.brand}, Product Index {product.productIndex}, Price: {product.price}");
            HomeObject homeObject = new HomeObject(driver);
            SearchResultObject searchResultObject = new SearchResultObject(driver);
            ProductObject productObject = new ProductObject(driver);
            CartObject cartObject = new CartObject(driver);
            double currentSum=0;
            try
            {
                homeObject.SearchByKeyword(product.searchProduct);
                searchResultObject.GetProduct(product.brand, product.productIndex);
                productObject.BuyProduct();
                currentSum = cartObject.GetTotalSumFromPage();
            }
            catch(Exception e)
            {
                logger.Error(DateTime.Now.ToString() + "\n" + e.Message.ToString() + e.TargetSite.Name.ToString());
            }
            finally
            {
                Assert.Greater(currentSum, Convert.ToDouble(product.price));
                logger.Info("Test finished");
            }
        }
    }
}
