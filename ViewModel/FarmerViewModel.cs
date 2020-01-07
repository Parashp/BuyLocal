using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class FarmerViewModel
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }


        private static List<FarmerViewModel> _farmers;
        public static List<FarmerViewModel> GetFarmers()
        {
            _farmers = new List<FarmerViewModel>();
            _farmers.Add(new FarmerViewModel()
            {
                ID = Guid.Parse("d20a91a4-d575-4a90-ab10-c7324222517c"),
                UserName="farmer1",
                DisplayName="Farmer One"
            });
            _farmers.Add(new FarmerViewModel()
            {
                ID = Guid.Parse("9ec65c06-37c6-4297-943d-bcf43efcd3b8"),
                UserName = "farmer2",
                DisplayName = "Farmer Two"
            }); ;
            _farmers.Add(new FarmerViewModel()
            {
                ID = Guid.Parse("9e0c752c-f587-44b0-b7bf-b3fd3c277100"),
                UserName = "farmer3",
                DisplayName = "Farmer Three"
            }); ;
            _farmers.Add(new FarmerViewModel()
            {
                ID = Guid.Parse("5afff8c2-c899-449f-ac98-054048db9d01"),
                UserName = "farmer4",
                DisplayName = "Farmer Four"
            }); ;
            return _farmers;
        }

        public static FarmerViewModel GetFarmer(int i)
        {
            GetFarmers();
            return _farmers[i];
        }

        public static FarmerViewModel GetFarmer(Guid ID)
        {
            GetFarmers();
            return _farmers.Find(x=> x.ID==ID);
        }

        public static FarmerViewModel GetFarmer(string userName)
        {
            GetFarmers();
            return _farmers.Find(x => x.UserName == userName);
        }
    }
}
