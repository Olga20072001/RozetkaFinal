using System;
using System.Collections.Generic;

namespace EPAM_LAb_Rozetka.Models
{
    [Serializable]
    public class Products
    {
        public List<Product> ProductsList { get; set; }
        public Products() { }
        public override string ToString()
        {
            if (ProductsList.Count == 0)
            {
                return "The list is empty";
            }
            else
            {
                foreach (var item in ProductsList)
                {
                    item.ToString();
                }
            }
            return base.ToString();
        }
    }
}
