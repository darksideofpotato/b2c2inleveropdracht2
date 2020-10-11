using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2einleveropdracht.Classes
{
    public class Brand
    {
        private int brandId;
        private int countryId;
        private string brandName;

        public Brand(int _brandId, int _countryId, string _brandName)
        {
            this.brandId = _brandId;
            this.countryId = _countryId;
            this.brandName = _brandName;
        }
    }
}