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


        private static List<ProductViewModel> _products;
        public static List<ProductViewModel> GetProducts()
        {
            _products = new List<ProductViewModel>();
            Random randomPrice = new Random(1);

            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("386375d2-9d37-40c4-9b12-f0b3b00b652a"),
                Name = "Item One",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(1),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("d108b5d5-bf8c-4c7c-afb2-bdb993ae9518"),
                Name = "Item Two",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(1),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("fcb2a97f-9db1-48b8-aa4a-258ecef1fda0"),
                Name = "Item Three",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(1),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("f17e3d3f-c156-4798-8537-1f2cbddbb7e5"),
                Name = "Item Four",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(1),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("d959e514-5614-4b59-9036-351371b13520"),
                Name = "Item Five",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(1),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            //Farmer 2
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("c9965961-e54c-46c5-b448-f14ded8cc978"),
                Name = "Item One",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(2),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("2aacc27a-5ce2-4dbd-b553-a4eb36ccbb96"),
                Name = "Item Two",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(2),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("5abf954e-8330-4b3b-817f-2b4a307c0a9d"),
                Name = "Item Three",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(2),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("60b780ae-c4c6-4fad-9324-f6e68390c556"),
                Name = "Item Four",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(2),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });
            _products.Add(new ProductViewModel
            {
                ID = Guid.Parse("78168054-3900-41d3-9229-b43f7f432170"),
                Name = "Item Five",
                Desc = "This product was design and developed by Farmer who lives in our neighbourhood.",
                Price = Math.Round(randomPrice.Next(2, 10) + randomPrice.NextDouble(), 2),
                ProduceBy = FarmerViewModel.GetFarmer(2),
                SaleBy = new RetailerViewModel()
                {
                    ID = Guid.NewGuid(),
                    DisplayName = "Wholesale",
                    UserName = "wholesale"
                }
            });

            return _products;
        }

        public static ProductViewModel GetProduct(Guid ProductID)
        {
            GetProducts();

            return _products.Find(x => x.ID == ProductID);
        }
    }
}
