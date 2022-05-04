using System;

namespace EPAM_LAb_Rozetka.Models
{
    [Serializable]
    public class Product
    {
        public string searchProduct { get; set; }
        public string brand { get; set; }
        public int productIndex { get; set; }
        public string price { get; set; }

        public override string ToString()
        {
            return "\t" + searchProduct + "\t" + brand + "\t" + productIndex + "\t" + price;
        }
    }
}
