using EPAM_LAb_Rozetka.Models;
using System.Collections.Generic;

namespace EPAM_LAb_Rozetka.Utils
{
    class DataProvider
    {
        public static IEnumerable<Product> GetData()
        {
            Products products = XmlReader.ReadDataFromFiles();
            for (int i = 0; i < products.ProductsList.Count; i++)
            {
                yield return products.ProductsList[i];
            }
        }
    }
}
