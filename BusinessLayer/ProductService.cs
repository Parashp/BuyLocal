using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class ProductService
    {
        BuyLocalContext _db = null;
        public ProductService(BuyLocalContext db)
        {
            _db = db;
        }
    }
}
