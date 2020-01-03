using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class ProductViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<string> Images { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        public int AvailableQty { get; set; }
        public int SoldQty { get; set; }

        public FarmerViewModel ProduceBy { get; set; }
        public RetailerViewModel SaleBy { get; set; }

        public static List<ProductViewModel> GetProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            Random randomPrice = new Random(1);

            for (int i = 1; i < 15; i++)
            {
                var product = new ProductViewModel
                {
                    ID = Guid.NewGuid(),
                    Name = "Item " + i.ToString(),
                    Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                    Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(),2),
                    ProduceBy = new FarmerViewModel()
                    {
                        ID = Guid.NewGuid(),
                        UserName = "farmerOne",
                        DisplayName = "Good Farmer",
                        Address = "Local"
                    },
                    SaleBy = new RetailerViewModel()
                    {
                        ID = Guid.NewGuid(),
                        DisplayName = "Wholesale",
                        UserName = "wholesale"
                    }
                };

                products.Add(product);
            }
            return products;
        }
    }
}
